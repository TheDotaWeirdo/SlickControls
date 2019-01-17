namespace SlickControls.Panels
{
	partial class PC_ThemeChanger
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC_ThemeChanger));
			this.panel1 = new System.Windows.Forms.Panel();
			this.verticalScroll1 = new SlickControls.Controls.VerticalScroll();
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
			this.UD_BaseTheme = new SlickControls.Controls.SlickDropdown();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.B_Reset = new SlickControls.Controls.SlickButton();
			this.panel1.SuspendLayout();
			this.FLP_Pickers.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.B_Reset)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
			this.panel1.Controls.Add(this.verticalScroll1);
			this.panel1.Controls.Add(this.FLP_Pickers);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 51);
			this.panel1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(778, 357);
			this.panel1.TabIndex = 59;
			// 
			// verticalScroll1
			// 
			this.verticalScroll1.BarColor = null;
			this.verticalScroll1.Dock = System.Windows.Forms.DockStyle.Right;
			this.verticalScroll1.LinkedControl = this.FLP_Pickers;
			this.verticalScroll1.Location = new System.Drawing.Point(774, 0);
			this.verticalScroll1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.verticalScroll1.Name = "verticalScroll1";
			this.verticalScroll1.Size = new System.Drawing.Size(4, 185);
			this.verticalScroll1.TabIndex = 1;
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
			this.FLP_Pickers.MaximumSize = new System.Drawing.Size(778, 9999);
			this.FLP_Pickers.Name = "FLP_Pickers";
			this.FLP_Pickers.Size = new System.Drawing.Size(654, 335);
			this.FLP_Pickers.TabIndex = 0;
			// 
			// CP_Back
			// 
			this.CP_Back.ColorName = "BackColor";
			this.CP_Back.Location = new System.Drawing.Point(15, 15);
			this.CP_Back.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Back.Name = "CP_Back";
			this.CP_Back.Size = new System.Drawing.Size(188, 37);
			this.CP_Back.TabIndex = 0;
			this.CP_Back.Text = "Background";
			this.CP_Back.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Text
			// 
			this.CP_Text.ColorName = "ForeColor";
			this.CP_Text.Location = new System.Drawing.Point(233, 15);
			this.CP_Text.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Text.Name = "CP_Text";
			this.CP_Text.Size = new System.Drawing.Size(188, 37);
			this.CP_Text.TabIndex = 1;
			this.CP_Text.Text = "Text";
			this.CP_Text.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Menu
			// 
			this.CP_Menu.ColorName = "MenuColor";
			this.CP_Menu.Location = new System.Drawing.Point(451, 15);
			this.CP_Menu.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Menu.Name = "CP_Menu";
			this.CP_Menu.Size = new System.Drawing.Size(188, 37);
			this.CP_Menu.TabIndex = 8;
			this.CP_Menu.Text = "Menu Background";
			this.CP_Menu.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_MenuText
			// 
			this.CP_MenuText.ColorName = "MenuForeColor";
			this.CP_MenuText.Location = new System.Drawing.Point(15, 82);
			this.CP_MenuText.Margin = new System.Windows.Forms.Padding(15);
			this.CP_MenuText.Name = "CP_MenuText";
			this.CP_MenuText.Size = new System.Drawing.Size(188, 37);
			this.CP_MenuText.TabIndex = 3;
			this.CP_MenuText.Text = "Menu Text";
			this.CP_MenuText.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Button
			// 
			this.CP_Button.ColorName = "ButtonColor";
			this.CP_Button.Location = new System.Drawing.Point(233, 82);
			this.CP_Button.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Button.Name = "CP_Button";
			this.CP_Button.Size = new System.Drawing.Size(188, 37);
			this.CP_Button.TabIndex = 14;
			this.CP_Button.Text = "Button";
			this.CP_Button.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_ButtonText
			// 
			this.CP_ButtonText.ColorName = "ButtonForeColor";
			this.CP_ButtonText.Location = new System.Drawing.Point(451, 82);
			this.CP_ButtonText.Margin = new System.Windows.Forms.Padding(15);
			this.CP_ButtonText.Name = "CP_ButtonText";
			this.CP_ButtonText.Size = new System.Drawing.Size(188, 37);
			this.CP_ButtonText.TabIndex = 2;
			this.CP_ButtonText.Text = "Button Text";
			this.CP_ButtonText.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Active
			// 
			this.CP_Active.ColorName = "ActiveColor";
			this.CP_Active.Location = new System.Drawing.Point(15, 149);
			this.CP_Active.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Active.Name = "CP_Active";
			this.CP_Active.Size = new System.Drawing.Size(188, 37);
			this.CP_Active.TabIndex = 9;
			this.CP_Active.Text = "Active";
			this.CP_Active.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_ActiveText
			// 
			this.CP_ActiveText.ColorName = "ActiveForeColor";
			this.CP_ActiveText.Location = new System.Drawing.Point(233, 149);
			this.CP_ActiveText.Margin = new System.Windows.Forms.Padding(15);
			this.CP_ActiveText.Name = "CP_ActiveText";
			this.CP_ActiveText.Size = new System.Drawing.Size(188, 37);
			this.CP_ActiveText.TabIndex = 9;
			this.CP_ActiveText.Text = "Active Text";
			this.CP_ActiveText.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Label
			// 
			this.CP_Label.ColorName = "LabelColor";
			this.CP_Label.Location = new System.Drawing.Point(451, 149);
			this.CP_Label.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Label.Name = "CP_Label";
			this.CP_Label.Size = new System.Drawing.Size(188, 37);
			this.CP_Label.TabIndex = 4;
			this.CP_Label.Text = "Label";
			this.CP_Label.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Info
			// 
			this.CP_Info.ColorName = "InfoColor";
			this.CP_Info.Location = new System.Drawing.Point(15, 216);
			this.CP_Info.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Info.Name = "CP_Info";
			this.CP_Info.Size = new System.Drawing.Size(188, 37);
			this.CP_Info.TabIndex = 5;
			this.CP_Info.Text = "Info Text";
			this.CP_Info.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Accent
			// 
			this.CP_Accent.ColorName = "AccentColor";
			this.CP_Accent.Location = new System.Drawing.Point(233, 216);
			this.CP_Accent.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Accent.Name = "CP_Accent";
			this.CP_Accent.Size = new System.Drawing.Size(188, 37);
			this.CP_Accent.TabIndex = 6;
			this.CP_Accent.Text = "Accent Background";
			this.CP_Accent.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Icon
			// 
			this.CP_Icon.ColorName = "IconColor";
			this.CP_Icon.Location = new System.Drawing.Point(451, 216);
			this.CP_Icon.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Icon.Name = "CP_Icon";
			this.CP_Icon.Size = new System.Drawing.Size(188, 37);
			this.CP_Icon.TabIndex = 10;
			this.CP_Icon.Text = "Icon";
			this.CP_Icon.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Red
			// 
			this.CP_Red.ColorName = "RedColor";
			this.CP_Red.Location = new System.Drawing.Point(15, 283);
			this.CP_Red.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Red.Name = "CP_Red";
			this.CP_Red.Size = new System.Drawing.Size(188, 37);
			this.CP_Red.TabIndex = 11;
			this.CP_Red.Text = "Red";
			this.CP_Red.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Green
			// 
			this.CP_Green.ColorName = "GreenColor";
			this.CP_Green.Location = new System.Drawing.Point(233, 283);
			this.CP_Green.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Green.Name = "CP_Green";
			this.CP_Green.Size = new System.Drawing.Size(188, 37);
			this.CP_Green.TabIndex = 12;
			this.CP_Green.Text = "Green";
			this.CP_Green.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// CP_Yellow
			// 
			this.CP_Yellow.ColorName = "YellowColor";
			this.CP_Yellow.Location = new System.Drawing.Point(451, 283);
			this.CP_Yellow.Margin = new System.Windows.Forms.Padding(15);
			this.CP_Yellow.Name = "CP_Yellow";
			this.CP_Yellow.Size = new System.Drawing.Size(188, 37);
			this.CP_Yellow.TabIndex = 13;
			this.CP_Yellow.Text = "Yellow";
			this.CP_Yellow.ColorChanged += new System.Action<object, bool>(this.CP_ColorChanged);
			// 
			// UD_BaseTheme
			// 
			this.UD_BaseTheme.Conversion = null;
			this.UD_BaseTheme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UD_BaseTheme.Image = ((System.Drawing.Image)(resources.GetObject("UD_BaseTheme.Image")));
			this.UD_BaseTheme.Items = new string[] {
        "Dark",
        "Grey",
        "Light",
        "Chic"};
			this.UD_BaseTheme.LabelText = "Base Theme";
			this.UD_BaseTheme.Location = new System.Drawing.Point(6, 6);
			this.UD_BaseTheme.Margin = new System.Windows.Forms.Padding(6);
			this.UD_BaseTheme.MaximumSize = new System.Drawing.Size(400, 34);
			this.UD_BaseTheme.MaxLength = 32767;
			this.UD_BaseTheme.MinimumSize = new System.Drawing.Size(50, 34);
			this.UD_BaseTheme.Name = "UD_BaseTheme";
			this.UD_BaseTheme.Placeholder = "Select how the app interacts with your theme";
			this.UD_BaseTheme.Required = false;
			this.UD_BaseTheme.SelectedItem = null;
			this.UD_BaseTheme.SelectedText = "";
			this.UD_BaseTheme.SelectionLength = 0;
			this.UD_BaseTheme.SelectionStart = 0;
			this.UD_BaseTheme.Size = new System.Drawing.Size(400, 34);
			this.UD_BaseTheme.TabIndex = 60;
			this.UD_BaseTheme.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.UD_BaseTheme.Validation = SlickControls.Enums.ValidationType.None;
			this.UD_BaseTheme.ValidationRegex = "";
			this.UD_BaseTheme.TextChanged += new System.EventHandler(this.UD_BaseTheme_TextChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.B_Reset, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.UD_BaseTheme, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 30);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 408);
			this.tableLayoutPanel1.TabIndex = 62;
			// 
			// B_Reset
			// 
			this.B_Reset.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.B_Reset.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.B_Reset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.B_Reset.ColorShade = null;
			this.B_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
			this.B_Reset.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
			this.B_Reset.IconSize = 16;
			this.B_Reset.Image = global::SlickControls.Properties.Resources.Tiny_Retry;
			this.B_Reset.Location = new System.Drawing.Point(668, 8);
			this.B_Reset.Margin = new System.Windows.Forms.Padding(15, 0, 10, 0);
			this.B_Reset.Name = "B_Reset";
			this.B_Reset.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
			this.B_Reset.Size = new System.Drawing.Size(100, 30);
			this.B_Reset.TabIndex = 61;
			this.B_Reset.Text = "RESET";
			this.B_Reset.Click += new System.EventHandler(this.B_Reset_Click);
			// 
			// PC_ThemeChanger
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "PC_ThemeChanger";
			this.Padding = new System.Windows.Forms.Padding(5, 30, 0, 0);
			this.ShowBack = true;
			this.Text = "Theme Changer";
			this.Load += new System.EventHandler(this.Theme_Changer_Load);
			this.Resize += new System.EventHandler(this.Theme_Changer_Resize);
			this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.FLP_Pickers.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.B_Reset)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.FlowLayoutPanel FLP_Pickers;
		private Controls.ColorPicker CP_Back;
		private Controls.ColorPicker CP_Text;
		private Controls.ColorPicker CP_Menu;
		private Controls.ColorPicker CP_MenuText;
		private Controls.ColorPicker CP_Button;
		private Controls.ColorPicker CP_ButtonText;
		private Controls.ColorPicker CP_Active;
		private Controls.ColorPicker CP_ActiveText;
		private Controls.ColorPicker CP_Label;
		private Controls.ColorPicker CP_Info;
		private Controls.ColorPicker CP_Accent;
		private Controls.ColorPicker CP_Icon;
		private Controls.ColorPicker CP_Red;
		private Controls.ColorPicker CP_Green;
		private Controls.ColorPicker CP_Yellow;
		internal Controls.SlickDropdown UD_BaseTheme;
		private Controls.VerticalScroll verticalScroll1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private Controls.SlickButton B_Reset;
	}
}
