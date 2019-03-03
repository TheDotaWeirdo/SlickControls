namespace SlickControls.Forms
{
	partial class Theme_Changer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Theme_Changer));
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
			this.verticalScroll1 = new SlickControls.Controls.SlickScroll();
			this.flatButton2 = new SlickControls.Controls.SlickButton();
			this.UD_BaseTheme = new SlickControls.Controls.SlickDropdown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.FLP_Pickers = new System.Windows.Forms.FlowLayoutPanel();
			this.CP_Back = new SlickControls.Controls.ColorPicker();
			this.CP_Text = new SlickControls.Controls.ColorPicker();
			this.CP_Menu = new SlickControls.Controls.ColorPicker();
			this.CP_MenuText = new SlickControls.Controls.ColorPicker();
			this.CP_Button = new SlickControls.Controls.ColorPicker();
			this.CP_ButtonText = new SlickControls.Controls.ColorPicker();
			this.CP_Active = new SlickControls.Controls.ColorPicker();
			this.CP_ActiveText = new SlickControls.Controls.ColorPicker();
			this.CP_Label = new SlickControls.Controls.ColorPicker();
			this.CP_Info = new SlickControls.Controls.ColorPicker();
			this.CP_Accent = new SlickControls.Controls.ColorPicker();
			this.CP_Icon = new SlickControls.Controls.ColorPicker();
			this.CP_Red = new SlickControls.Controls.ColorPicker();
			this.CP_Green = new SlickControls.Controls.ColorPicker();
			this.CP_Yellow = new SlickControls.Controls.ColorPicker();
			this.base_P_Content.SuspendLayout();
			this.TLP_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flatButton2)).BeginInit();
			this.panel1.SuspendLayout();
			this.FLP_Pickers.SuspendLayout();
			this.SuspendLayout();
			// 
			// base_P_Content
			// 
			this.base_P_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
			this.base_P_Content.Controls.Add(this.TLP_Main);
			this.base_P_Content.Location = new System.Drawing.Point(1, 73);
			this.base_P_Content.Size = new System.Drawing.Size(426, 399);
			// 
			// base_P_Controls
			// 
			this.base_P_Controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(55)))), ((int)(((byte)(68)))));
			this.base_P_Controls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.base_P_Controls.Size = new System.Drawing.Size(426, 45);
			// 
			// base_P_Top_Spacer
			// 
			this.base_P_Top_Spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
			this.base_P_Top_Spacer.Location = new System.Drawing.Point(1, 71);
			this.base_P_Top_Spacer.Size = new System.Drawing.Size(426, 2);
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 20000;
			this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(65)))), ((int)(((byte)(77)))));
			this.toolTip.InitialDelay = 600;
			this.toolTip.ReshowDelay = 100;
			// 
			// TLP_Main
			// 
			this.TLP_Main.ColumnCount = 3;
			this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TLP_Main.Controls.Add(this.verticalScroll1, 2, 0);
			this.TLP_Main.Controls.Add(this.flatButton2, 1, 2);
			this.TLP_Main.Controls.Add(this.UD_BaseTheme, 1, 0);
			this.TLP_Main.Controls.Add(this.panel1, 1, 1);
			this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP_Main.Location = new System.Drawing.Point(0, 0);
			this.TLP_Main.Name = "TLP_Main";
			this.TLP_Main.RowCount = 3;
			this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TLP_Main.Size = new System.Drawing.Size(426, 399);
			this.TLP_Main.TabIndex = 2;
			// 
			// verticalScroll1
			// 
			this.verticalScroll1.Dock = System.Windows.Forms.DockStyle.Right;
			this.verticalScroll1.LinkedControl = null;
			this.verticalScroll1.Location = new System.Drawing.Point(421, 0);
			this.verticalScroll1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.verticalScroll1.Name = "verticalScroll1";
			this.TLP_Main.SetRowSpan(this.verticalScroll1, 2);
			this.verticalScroll1.Size = new System.Drawing.Size(4, 363);
			this.verticalScroll1.TabIndex = 6;
			// 
			// flatButton2
			// 
			this.flatButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.flatButton2.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.flatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flatButton2.ColorShade = null;
			this.flatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.flatButton2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
			this.flatButton2.IconSize = 14;
			this.flatButton2.Image = global::SlickControls.Properties.Resources.Tiny_Retry;
			this.flatButton2.Location = new System.Drawing.Point(163, 368);
			this.flatButton2.Margin = new System.Windows.Forms.Padding(5);
			this.flatButton2.Name = "flatButton2";
			this.flatButton2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
			this.flatButton2.Size = new System.Drawing.Size(100, 26);
			this.flatButton2.TabIndex = 3;
			this.flatButton2.Text = "Reset";
			this.flatButton2.Click += new System.EventHandler(this.B_Reset_Click);
			// 
			// UD_BaseTheme
			// 
			this.UD_BaseTheme.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.UD_BaseTheme.Conversion = null;
			this.UD_BaseTheme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UD_BaseTheme.Image = ((System.Drawing.Image)(resources.GetObject("UD_BaseTheme.Image")));
			this.UD_BaseTheme.Items = new string[] {
        "Dark",
        "Grey",
        "Light",
        "Chic"};
			this.UD_BaseTheme.LabelText = "Base Theme";
			this.UD_BaseTheme.Location = new System.Drawing.Point(21, 6);
			this.UD_BaseTheme.Margin = new System.Windows.Forms.Padding(6);
			this.UD_BaseTheme.MaximumSize = new System.Drawing.Size(900, 34);
			this.UD_BaseTheme.MaxLength = 32767;
			this.UD_BaseTheme.MinimumSize = new System.Drawing.Size(50, 34);
			this.UD_BaseTheme.Name = "UD_BaseTheme";
			this.UD_BaseTheme.Placeholder = "Select how the app interacts with your theme";
			this.UD_BaseTheme.Required = false;
			this.UD_BaseTheme.SelectedItem = null;
			this.UD_BaseTheme.SelectedText = "";
			this.UD_BaseTheme.SelectionLength = 0;
			this.UD_BaseTheme.SelectionStart = 0;
			this.UD_BaseTheme.Size = new System.Drawing.Size(384, 34);
			this.UD_BaseTheme.TabIndex = 0;
			this.UD_BaseTheme.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.UD_BaseTheme.Validation = SlickControls.Enums.ValidationType.None;
			this.UD_BaseTheme.ValidationRegex = "";
			this.UD_BaseTheme.TextChanged += new System.EventHandler(this.UD_BaseTheme_TextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.FLP_Pickers);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(15, 46);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(396, 317);
			this.panel1.TabIndex = 58;
			this.panel1.Resize += new System.EventHandler(this.Theme_Changer_Resize);
			// 
			// FLP_Pickers
			// 
			this.FLP_Pickers.AutoSize = true;
			this.FLP_Pickers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FLP_Pickers.Controls.Add(this.CP_Back);
			this.FLP_Pickers.Controls.Add(this.CP_Text);
			this.FLP_Pickers.Controls.Add(this.CP_Menu);
			this.FLP_Pickers.Controls.Add(this.CP_MenuText);
			this.FLP_Pickers.Controls.Add(this.CP_Button);
			this.FLP_Pickers.Controls.Add(this.CP_ButtonText);
			this.FLP_Pickers.Controls.Add(this.CP_Active);
			this.FLP_Pickers.Controls.Add(this.CP_ActiveText);
			this.FLP_Pickers.Controls.Add(this.CP_Label);
			this.FLP_Pickers.Controls.Add(this.CP_Info);
			this.FLP_Pickers.Controls.Add(this.CP_Accent);
			this.FLP_Pickers.Controls.Add(this.CP_Icon);
			this.FLP_Pickers.Controls.Add(this.CP_Red);
			this.FLP_Pickers.Controls.Add(this.CP_Green);
			this.FLP_Pickers.Controls.Add(this.CP_Yellow);
			this.FLP_Pickers.Location = new System.Drawing.Point(0, 0);
			this.FLP_Pickers.Margin = new System.Windows.Forms.Padding(0);
			this.FLP_Pickers.MaximumSize = new System.Drawing.Size(500, 9998);
			this.FLP_Pickers.Name = "FLP_Pickers";
			this.FLP_Pickers.Size = new System.Drawing.Size(396, 360);
			this.FLP_Pickers.TabIndex = 0;
			// 
			// CP_Back
			// 
			this.CP_Back.ColorName = "BackColor";
			this.CP_Back.Location = new System.Drawing.Point(5, 3);
			this.CP_Back.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Back.Name = "CP_Back";
			this.CP_Back.Size = new System.Drawing.Size(188, 37);
			this.CP_Back.TabIndex = 0;
			this.CP_Back.Text = "Background";
			// 
			// CP_Text
			// 
			this.CP_Text.ColorName = "ForeColor";
			this.CP_Text.Location = new System.Drawing.Point(203, 3);
			this.CP_Text.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Text.Name = "CP_Text";
			this.CP_Text.Size = new System.Drawing.Size(188, 37);
			this.CP_Text.TabIndex = 1;
			this.CP_Text.Text = "Text";
			// 
			// CP_Menu
			// 
			this.CP_Menu.ColorName = "MenuColor";
			this.CP_Menu.Location = new System.Drawing.Point(5, 48);
			this.CP_Menu.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Menu.Name = "CP_Menu";
			this.CP_Menu.Size = new System.Drawing.Size(188, 37);
			this.CP_Menu.TabIndex = 8;
			this.CP_Menu.Text = "Menu Background";
			// 
			// CP_MenuText
			// 
			this.CP_MenuText.ColorName = "MenuForeColor";
			this.CP_MenuText.Location = new System.Drawing.Point(203, 48);
			this.CP_MenuText.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_MenuText.Name = "CP_MenuText";
			this.CP_MenuText.Size = new System.Drawing.Size(188, 37);
			this.CP_MenuText.TabIndex = 3;
			this.CP_MenuText.Text = "Menu Text";
			// 
			// CP_Button
			// 
			this.CP_Button.ColorName = "ButtonColor";
			this.CP_Button.Location = new System.Drawing.Point(5, 93);
			this.CP_Button.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Button.Name = "CP_Button";
			this.CP_Button.Size = new System.Drawing.Size(188, 37);
			this.CP_Button.TabIndex = 14;
			this.CP_Button.Text = "Button";
			// 
			// CP_ButtonText
			// 
			this.CP_ButtonText.ColorName = "ButtonForeColor";
			this.CP_ButtonText.Location = new System.Drawing.Point(203, 93);
			this.CP_ButtonText.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_ButtonText.Name = "CP_ButtonText";
			this.CP_ButtonText.Size = new System.Drawing.Size(188, 37);
			this.CP_ButtonText.TabIndex = 2;
			this.CP_ButtonText.Text = "Button Text";
			// 
			// CP_Active
			// 
			this.CP_Active.ColorName = "ActiveColor";
			this.CP_Active.Location = new System.Drawing.Point(5, 138);
			this.CP_Active.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Active.Name = "CP_Active";
			this.CP_Active.Size = new System.Drawing.Size(188, 37);
			this.CP_Active.TabIndex = 9;
			this.CP_Active.Text = "Active";
			// 
			// CP_ActiveText
			// 
			this.CP_ActiveText.ColorName = "ActiveForeColor";
			this.CP_ActiveText.Location = new System.Drawing.Point(203, 138);
			this.CP_ActiveText.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_ActiveText.Name = "CP_ActiveText";
			this.CP_ActiveText.Size = new System.Drawing.Size(188, 37);
			this.CP_ActiveText.TabIndex = 9;
			this.CP_ActiveText.Text = "Active Text";
			// 
			// CP_Label
			// 
			this.CP_Label.ColorName = "LabelColor";
			this.CP_Label.Location = new System.Drawing.Point(5, 183);
			this.CP_Label.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Label.Name = "CP_Label";
			this.CP_Label.Size = new System.Drawing.Size(188, 37);
			this.CP_Label.TabIndex = 4;
			this.CP_Label.Text = "Label";
			// 
			// CP_Info
			// 
			this.CP_Info.ColorName = "InfoColor";
			this.CP_Info.Location = new System.Drawing.Point(203, 183);
			this.CP_Info.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Info.Name = "CP_Info";
			this.CP_Info.Size = new System.Drawing.Size(188, 37);
			this.CP_Info.TabIndex = 5;
			this.CP_Info.Text = "Info Text";
			// 
			// CP_Accent
			// 
			this.CP_Accent.ColorName = "AccentColor";
			this.CP_Accent.Location = new System.Drawing.Point(5, 228);
			this.CP_Accent.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Accent.Name = "CP_Accent";
			this.CP_Accent.Size = new System.Drawing.Size(188, 37);
			this.CP_Accent.TabIndex = 6;
			this.CP_Accent.Text = "Accent Background";
			// 
			// CP_Icon
			// 
			this.CP_Icon.ColorName = "IconColor";
			this.CP_Icon.Location = new System.Drawing.Point(203, 228);
			this.CP_Icon.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Icon.Name = "CP_Icon";
			this.CP_Icon.Size = new System.Drawing.Size(188, 37);
			this.CP_Icon.TabIndex = 10;
			this.CP_Icon.Text = "Icon";
			// 
			// CP_Red
			// 
			this.CP_Red.ColorName = "RedColor";
			this.CP_Red.Location = new System.Drawing.Point(5, 273);
			this.CP_Red.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Red.Name = "CP_Red";
			this.CP_Red.Size = new System.Drawing.Size(188, 37);
			this.CP_Red.TabIndex = 11;
			this.CP_Red.Text = "Red";
			// 
			// CP_Green
			// 
			this.CP_Green.ColorName = "GreenColor";
			this.CP_Green.Location = new System.Drawing.Point(203, 273);
			this.CP_Green.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Green.Name = "CP_Green";
			this.CP_Green.Size = new System.Drawing.Size(188, 37);
			this.CP_Green.TabIndex = 12;
			this.CP_Green.Text = "Green";
			// 
			// CP_Yellow
			// 
			this.CP_Yellow.ColorName = "YellowColor";
			this.CP_Yellow.Location = new System.Drawing.Point(5, 318);
			this.CP_Yellow.Margin = new System.Windows.Forms.Padding(5, 3, 5, 5);
			this.CP_Yellow.Name = "CP_Yellow";
			this.CP_Yellow.Size = new System.Drawing.Size(188, 37);
			this.CP_Yellow.TabIndex = 13;
			this.CP_Yellow.Text = "Yellow";
			// 
			// Theme_Changer
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(445, 490);
			this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(69)))));
			this.FormIcon = global::SlickControls.Properties.Resources.Tiny_Switch;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(351, 400);
			this.Name = "Theme_Changer";
			this.Text = "Theme Changer";
			this.Load += new System.EventHandler(this.Theme_Changer_Load);
			this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Theme_Changer_Layout);
			this.base_P_Content.ResumeLayout(false);
			this.TLP_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.flatButton2)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.FLP_Pickers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TableLayoutPanel TLP_Main;
		private SlickControls.Controls.SlickScroll verticalScroll1;
		private SlickControls.Controls.SlickButton flatButton2;
		internal SlickControls.Controls.SlickDropdown UD_BaseTheme;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.FlowLayoutPanel FLP_Pickers;
		private SlickControls.Controls.ColorPicker CP_Back;
		private Controls.ColorPicker CP_Text;
		private Controls.ColorPicker CP_ButtonText;
		private Controls.ColorPicker CP_MenuText;
		private Controls.ColorPicker CP_Label;
		private Controls.ColorPicker CP_Info;
		private Controls.ColorPicker CP_Accent;
		private Controls.ColorPicker CP_Menu;
		private Controls.ColorPicker CP_Active;
		private Controls.ColorPicker CP_Icon;
		private Controls.ColorPicker CP_Red;
		private Controls.ColorPicker CP_Green;
		private Controls.ColorPicker CP_Yellow;
        private Controls.ColorPicker CP_Button;
		private Controls.ColorPicker CP_ActiveText;
	}
}