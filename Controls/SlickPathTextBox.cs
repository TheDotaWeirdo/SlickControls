using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using System.IO;
using System.Text.RegularExpressions;
using SlickControls.Classes;
using SlickControls.Forms;
using SlickControls.Enums;
using static System.Environment;

namespace SlickControls.Controls
{
	public partial class SlickPathTextBox : SlickTextBox, IValidationControl
	{
		public SlickPathTextBox() : base()
		{
			InitializeComponent();
			TB.PreviewKeyDown += TextBoxPreviewKeyDown;
			TB.KeyPress += HandleKeyInput;
			TB.TextChanged += AutoCompletePath;
			ValidationCustom = Directory.Exists;
			IconClicked += SlickPathTextBox_IconClicked;
			FileDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory);
		}

		[Category("Behavior")]
		public bool Folder { get; set; } = true;

		[Category("Behavior")]
		public string[] FileExtensions { get; set; } = new string[0];

		private void SlickPathTextBox_IconClicked(object sender, EventArgs e)
		{
			if (Folder)
			{
				if (ModifierKeys.HasFlag(Keys.Control))
				{
					FileDialog.FileName = "";
					FileDialog.Filter = "Shortcut|*.lnk";

					if (FileDialog.ShowDialog() == DialogResult.OK)
						Text = Directory.GetParent(FileDialog.FileName.GetShortcutPath()).FullName;
				}
				else if (folderDialog.ShowDialog() == DialogResult.OK)
					Text = folderDialog.SelectedPath;
			}
			else
			{
				FileDialog.FileName = "";
				FileDialog.Filter = "File|" + FileExtensions.ListStrings(x => $"*{x};");
				FileDialog.Filter = FileDialog.Filter.Substring(0, FileDialog.Filter.Length - 1);

				if (FileDialog.ShowDialog() == DialogResult.OK)
					Text = FileDialog.FileName;
			}
		}

		protected override void OnCreateControl()
		{
			Image = Properties.Resources.Tiny_Search;

			base.OnCreateControl();
		}

		public override bool ValidInput
		{
			get
			{
				if (DesignMode)
					return true;

				if (string.IsNullOrWhiteSpace(Text))
					return false;

				if (!Folder)
					return File.Exists(Text) && FileExtensions.Any(e => Text.EndsWith(e, StringComparison.CurrentCultureIgnoreCase));

				if (Directory.Exists(Text))
					return true;

				if (DialogResult.Yes == MessagePrompt.Show($"The folder: '{Text}' does not exist.\n\nWould you like to create it?", "Folder not found", Enums.PromptButtons.YesNo, Enums.PromptIcons.Warning, FindForm() is SlickForm frm ? frm : null))
				{
					try
					{ Directory.CreateDirectory(Text); }
					catch
					{
						MessagePrompt.Show($"The folder: '{Text}' could not be created.", "Folder not found", PromptButtons.OK, PromptIcons.Error, FindForm() is SlickForm _frm ? _frm : null);
						return false;
					}
				}

				return Directory.Exists(Text);
			}
		}

		#region TextBox Handling
		private string lastAddedChars;
		private char lastKeyPress;
		private int chosenIndex;
		private DisableIdentifier autoCompleteDisableIdentifier = new DisableIdentifier();

		private void AutoCompletePath(object sender, EventArgs e)
		{
			if (Text.Length <= 3) return;

			try
			{
				var parentPath = Directory.GetParent(Text)?.FullName;
				var oldText = Text;

				if (parentPath == null && (Text.EndsWith("\\") || Text.EndsWith("/")))
					parentPath = Path.GetFullPath(Text);

				if (autoCompleteDisableIdentifier.Enabled && parentPath != null
					&& (((Text.EndsWith("\\") || Text.EndsWith("/")) && lastKeyPress != '\b')
					|| (!Directory.Exists(Text) && Directory.Exists(parentPath))))
				{
					var searchedDirectoryName = Regex.Match(Text, @"[/\\]([^/\\]+)$").Groups[1].Value;
                    var selectedDirectory = string.Empty;

                    if (!Folder)
                    {
                        selectedDirectory = Directory.GetDirectories(parentPath, "*", SearchOption.TopDirectoryOnly)
                        .Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
                            || Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase))).FirstOrDefault();
                    }
                    else
                    {
                        var directories = Directory.GetDirectories(parentPath, "*", SearchOption.TopDirectoryOnly)
                             .Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
                                  || Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)));
                        selectedDirectory = Directory.GetFiles(parentPath, "*", SearchOption.TopDirectoryOnly)
                             .Where(x => FileExtensions.Any(f => x.EndsWith(f, StringComparison.CurrentCultureIgnoreCase))
                                  && (searchedDirectoryName == string.Empty || Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)))
                                        .Concat(directories).FirstOrDefault();
                    }

                    if (selectedDirectory != null)
					{
						var index = SelectionStart;

						autoCompleteDisableIdentifier.Disable();
						Text = selectedDirectory;
						Select(index, Text.Length - index);
						lastAddedChars = SelectedText;
						chosenIndex = 0;
						autoCompleteDisableIdentifier.Enable();

						if (oldText == Text)
							return;
					}
				}
			}
			catch { }
		}

		private void HandleKeyInput(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\b' && TB.SelectionLength > 0 && TB.SelectedText == lastAddedChars)
			{
				TB.SelectionStart--;
				TB.SelectionLength++;
			}

			if ((e.KeyChar == '\\' || e.KeyChar == '/') && Directory.Exists(TB.Text))
				TB.Select(TB.Text.Length, 0);

			if (e.KeyChar == '\t' && Directory.Exists(TB.Text) && Directory.GetParent(TB.Text) != null)
			{
				var index = TB.SelectionStart;
				var searchedDirectoryName = Regex.Match(TB.Text.Substring(0, index), @"[/\\]([^/\\]+)$").Groups[1].Value;
                var directories =
                    Directory.GetDirectories(Directory.GetParent(TB.Text).FullName, "*", SearchOption.TopDirectoryOnly)
                    .Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
                        || Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)));

                if (!Folder)
                    directories = Directory.GetFiles(Directory.GetParent(TB.Text).FullName, "*", SearchOption.TopDirectoryOnly)
                        .Where(x => FileExtensions.Any(f => x.EndsWith(f, StringComparison.CurrentCultureIgnoreCase))
                            && (searchedDirectoryName == string.Empty || Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)))
                                .Concat(directories);

                if (directories.Any())
				{
					chosenIndex++;
					if (chosenIndex >= directories.Count())
						chosenIndex = 0;

					autoCompleteDisableIdentifier.Disable();
					TB.Text = directories.ElementAt(chosenIndex);
					TB.Select(index, TB.Text.Length - index);
					lastAddedChars = TB.SelectedText;
					autoCompleteDisableIdentifier.Enable();
					e.Handled = true;
				}
			}

			lastKeyPress = e.KeyChar;
		}

		private void TextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (TB.SelectedText != string.Empty)
			{
				if (e.KeyCode == Keys.Enter)
					TB.SelectionStart = TB.Text.Length;
				else if (TB.Text.EndsWith(TB.SelectedText))
					e.IsInputKey = true;
			}
		}
		#endregion
	}
}
