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

namespace SlickControls.Controls
{
	public partial class SlickPathTextBox : SlickTextBox
	{
		public SlickPathTextBox() : base()
		{
			InitializeComponent();
			TB.PreviewKeyDown += TextBoxPreviewKeyDown;
			TB.KeyPress += HandleKeyInput;
			TB.TextChanged += AutoCompletePath;
			ValidationCustom = Directory.Exists;
			IconClicked += SlickPathTextBox_IconClicked;
		}

		private void SlickPathTextBox_IconClicked(object sender, EventArgs e)
		{
			if(folderDialog.ShowDialog() == DialogResult.OK)
			{
				Text = folderDialog.SelectedPath;
			}
		}

		protected override void OnCreateControl()
		{
			Image = Properties.Resources.Tiny_Search;

			base.OnCreateControl();
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
					var selectedDirectory = Directory.GetDirectories(parentPath, "*", SearchOption.TopDirectoryOnly)
						.Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
							|| Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)))
						.FirstOrDefault();

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
			var tb = (sender as TextBox);

			if (e.KeyChar == '\b' && tb.SelectionLength > 0 && tb.SelectedText == lastAddedChars)
			{
				tb.SelectionStart--;
				tb.SelectionLength++;
			}

			if ((e.KeyChar == '\\' || e.KeyChar == '/') && Directory.Exists(tb.Text))
				tb.Select(tb.Text.Length, 0);

			if (e.KeyChar == '\t' && Directory.GetParent(tb.Text) != null)
			{
				var index = tb.SelectionStart;
				var searchedDirectoryName = Regex.Match(tb.Text.Substring(0, index), @"[/\\]([^/\\]+)$").Groups[1].Value;
				var directories = Directory.GetDirectories(Directory.GetParent(tb.Text).FullName, "*", SearchOption.TopDirectoryOnly)
					.Where(x => Path.GetFileName(x)[0] != '$' && (searchedDirectoryName == string.Empty
						|| Path.GetFileName(x).StartsWith(searchedDirectoryName, StringComparison.OrdinalIgnoreCase)));

				chosenIndex++;
				if (chosenIndex >= directories.Count())
					chosenIndex = 0;

				autoCompleteDisableIdentifier.Disable();
				tb.Text = directories.ElementAt(chosenIndex);
				tb.Select(index, tb.Text.Length - index);
				lastAddedChars = tb.SelectedText;
				autoCompleteDisableIdentifier.Enable();
			}

			lastKeyPress = e.KeyChar;
		}

		private void TextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			var tb = (sender as TextBox);

			if (tb.SelectedText != string.Empty)
			{
				if (e.KeyCode == Keys.Enter)
					tb.SelectionStart = tb.Text.Length;
				else if (tb.Text.EndsWith(tb.SelectedText))
					e.IsInputKey = true;
			}
		}
		#endregion
	}
}
