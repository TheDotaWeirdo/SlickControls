using System;
using System.Drawing;
using System.Windows.Forms;
using Extensions;
using SlickControls.Enums;

namespace SlickControls.Forms
{
	public partial class Theme_Changer : BaseForm
	{
		public static Theme_Changer ThemeForm;

		private DisableIdentifier ColorLoopIdentifier = new DisableIdentifier();

		private DisableIdentifier UD_BaseThemeIdentifier = new DisableIdentifier();

		public Theme_Changer()
		{
			InitializeComponent();
			verticalScroll1.LinkedControl = FLP_Pickers;
			base_PB_Icon.Enabled = false;

			if (FormDesign.IsCustomEligible())
				FormDesign.Switch(FormDesign.Custom);

			UD_BaseThemeIdentifier.Disable();
			UD_BaseTheme.Text = FormDesign.List[FormDesign.Design.ID].Name;
			UD_BaseThemeIdentifier.Enable();

			DesignChanged(FormDesign.Design);
		}

		private void B_Reset_Click(object sender, EventArgs e)
		{
			FormDesign.ResetCustomTheme();
			FormDesign.Switch(FormDesign.List[UD_BaseTheme.Text]);
		}

		private void CP_ColorChanged(object sender, bool userChange)
		{
			if (ColorLoopIdentifier.Enabled)
			{
				ColorLoopIdentifier.Disable();

				if (userChange)
				{
					foreach (Controls.ColorPicker item in FLP_Pickers.Controls)
					{
						if (item != sender)
							item.Refresh();
					}

					if (!FormDesign.IsCustomEligible())
						FormDesign.Switch(FormDesign.List[UD_BaseTheme.Text]);
				}

				ColorLoopIdentifier.Enable();
			}
		}

		private void Theme_Changer_Layout(object sender, LayoutEventArgs e)
		{
			FLP_Pickers.MaximumSize = new Size(panel1.Width, 9999);
			FLP_Pickers.Left = (panel1.Width - FLP_Pickers.Width) / 2;
		}

		private void Theme_Changer_Load(object sender, EventArgs e)
		{
			var settings = ISave.LoadRaw("Settings.tf", "Shared");
			if (settings == null || !settings.TutorialShown)
			{
				ISave.Save(new { TutorialShown = true }, "Settings.tf", appName: "Shared");
				new Action(() => Invoke(new Action(() =>
				{
					MessagePrompt.Show("Welcome to Theme Changer!\nCustomize any color in the App to fit your desire.\n\nClick on any Color-Square to change it, Right-Click the Square to Reset it.",
						"Theme Changer Info", PromptButtons.OK, PromptIcons.Info);
				}))).RunInBackground(50);
			}
		}

		private void UD_BaseTheme_TextChanged(object sender, EventArgs e)
		{
			if (UD_BaseThemeIdentifier.Disabled) return;

			FormDesign.SetCustomBaseDesign(FormDesign.List[UD_BaseTheme.Text]);

			if (!FormDesign.IsCustomEligible())
				FormDesign.Switch(FormDesign.List[UD_BaseTheme.Text], forceRefresh: true);
		}

		private void B_Done_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Theme_Changer_Resize(object sender, EventArgs e)
		{
			FLP_Pickers.MaximumSize = new Size(panel1.Width, 9999);
			FLP_Pickers.Left = (panel1.Width - FLP_Pickers.Width) / 2;
		}
	}
}