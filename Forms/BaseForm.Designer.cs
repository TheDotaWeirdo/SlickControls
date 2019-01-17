namespace SlickControls.Forms
{
	partial class BaseForm
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
			this.base_toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.base_P_Top = new System.Windows.Forms.Panel();
			this.base_TLP_TopButtons = new System.Windows.Forms.TableLayoutPanel();
			this.base_B_Min = new Controls.TopIcon();
			this.base_B_Close = new Controls.TopIcon();
			this.base_B_Max = new Controls.TopIcon();
			this.base_B_Min.Color = SlickControls.Controls.TopIcon.IconStyle.Minimize;
			this.base_B_Close.Color = SlickControls.Controls.TopIcon.IconStyle.Close;
			this.base_B_Max.Color = SlickControls.Controls.TopIcon.IconStyle.Maximize;
			this.base_PB_Icon = new System.Windows.Forms.PictureBox();
			this.base_L_Title = new System.Windows.Forms.Label();
			this.base_P_Content = new System.Windows.Forms.Panel();
			this.base_P_Controls = new System.Windows.Forms.Panel();
			this.base_P_Top_Spacer = new System.Windows.Forms.Panel();
			this.base_P_Top.SuspendLayout();
			this.base_TLP_TopButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Min)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Close)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Max)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.base_PB_Icon)).BeginInit();
			this.SuspendLayout();
			// 
			// base_toolTip
			// 
			this.base_toolTip.AutoPopDelay = 20000;
			this.base_toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.base_toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(65)))), ((int)(((byte)(77)))));
			this.base_toolTip.InitialDelay = 600;
			this.base_toolTip.ReshowDelay = 100;
			// 
			// base_P_Top
			// 
			this.base_P_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.base_P_Top.Controls.Add(this.base_TLP_TopButtons);
			this.base_P_Top.Controls.Add(this.base_PB_Icon);
			this.base_P_Top.Controls.Add(this.base_L_Title);
			this.base_P_Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.base_P_Top.Location = new System.Drawing.Point(1, 1);
			this.base_P_Top.Margin = new System.Windows.Forms.Padding(0);
			this.base_P_Top.Name = "base_P_Top";
			this.base_P_Top.Size = new System.Drawing.Size(596, 25);
			this.base_P_Top.TabIndex = 1;
			// 
			// base_TLP_TopButtons
			// 
			this.base_TLP_TopButtons.AutoSize = true;
			this.base_TLP_TopButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.base_TLP_TopButtons.ColumnCount = 3;
			this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.base_TLP_TopButtons.Controls.Add(this.base_B_Min, 0, 0);
			this.base_TLP_TopButtons.Controls.Add(this.base_B_Close, 2, 0);
			this.base_TLP_TopButtons.Controls.Add(this.base_B_Max, 1, 0);
			this.base_TLP_TopButtons.Dock = System.Windows.Forms.DockStyle.Right;
			this.base_TLP_TopButtons.Location = new System.Drawing.Point(536, 0);
			this.base_TLP_TopButtons.Name = "base_TLP_TopButtons";
			this.base_TLP_TopButtons.RowCount = 1;
			this.base_TLP_TopButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.base_TLP_TopButtons.Size = new System.Drawing.Size(60, 25);
			this.base_TLP_TopButtons.TabIndex = 8;
			// 
			// base_B_Min
			// 
			this.base_B_Min.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.base_B_Min.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_B_Min.Image = global::SlickControls.Properties.Resources.Circle;
			this.base_B_Min.Location = new System.Drawing.Point(0, 4);
			this.base_B_Min.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.base_B_Min.Name = "base_B_Min";
			this.base_B_Min.Size = new System.Drawing.Size(16, 16);
			this.base_B_Min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.base_B_Min.TabIndex = 4;
			this.base_B_Min.TabStop = false;
			// 
			// base_B_Close
			// 
			this.base_B_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.base_B_Close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_B_Close.Image = global::SlickControls.Properties.Resources.Circle;
			this.base_B_Close.Location = new System.Drawing.Point(40, 4);
			this.base_B_Close.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.base_B_Close.Name = "base_B_Close";
			this.base_B_Close.Size = new System.Drawing.Size(16, 16);
			this.base_B_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.base_B_Close.TabIndex = 1;
			this.base_B_Close.TabStop = false;
			// 
			// base_B_Max
			// 
			this.base_B_Max.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.base_B_Max.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_B_Max.Image = global::SlickControls.Properties.Resources.Circle;
			this.base_B_Max.Location = new System.Drawing.Point(20, 4);
			this.base_B_Max.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.base_B_Max.Name = "base_B_Max";
			this.base_B_Max.Size = new System.Drawing.Size(16, 16);
			this.base_B_Max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.base_B_Max.TabIndex = 5;
			this.base_B_Max.TabStop = false;
			// 
			// base_PB_Icon
			// 
			this.base_PB_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_PB_Icon.Location = new System.Drawing.Point(4, 4);
			this.base_PB_Icon.Name = "base_PB_Icon";
			this.base_PB_Icon.Size = new System.Drawing.Size(16, 16);
			this.base_PB_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.base_PB_Icon.TabIndex = 7;
			this.base_PB_Icon.TabStop = false;
			// 
			// base_L_Title
			// 
			this.base_L_Title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_L_Title.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.base_L_Title.ForeColor = System.Drawing.Color.White;
			this.base_L_Title.Location = new System.Drawing.Point(0, 0);
			this.base_L_Title.Name = "base_L_Title";
			this.base_L_Title.Size = new System.Drawing.Size(596, 25);
			this.base_L_Title.TabIndex = 6;
			this.base_L_Title.Text = "Form";
			this.base_L_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.base_L_Title.TextChanged += new System.EventHandler(this.L_Title_TextChanged);
			// 
			// base_P_Content
			// 
			this.base_P_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.base_P_Content.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_Content.Location = new System.Drawing.Point(1, 28);
			this.base_P_Content.Margin = new System.Windows.Forms.Padding(0);
			this.base_P_Content.Name = "base_P_Content";
			this.base_P_Content.Size = new System.Drawing.Size(596, 310);
			this.base_P_Content.TabIndex = 2;
			// 
			// base_P_Controls
			// 
			this.base_P_Controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.base_P_Controls.Dock = System.Windows.Forms.DockStyle.Top;
			this.base_P_Controls.Location = new System.Drawing.Point(1, 26);
			this.base_P_Controls.Margin = new System.Windows.Forms.Padding(0);
			this.base_P_Controls.Name = "base_P_Controls";
			this.base_P_Controls.Size = new System.Drawing.Size(596, 0);
			this.base_P_Controls.TabIndex = 3;
			this.base_P_Controls.Visible = false;
			// 
			// base_P_Top_Spacer
			// 
			this.base_P_Top_Spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
			this.base_P_Top_Spacer.Dock = System.Windows.Forms.DockStyle.Top;
			this.base_P_Top_Spacer.Location = new System.Drawing.Point(1, 26);
			this.base_P_Top_Spacer.Margin = new System.Windows.Forms.Padding(0);
			this.base_P_Top_Spacer.Name = "base_P_Top_Spacer";
			this.base_P_Top_Spacer.Size = new System.Drawing.Size(596, 2);
			this.base_P_Top_Spacer.TabIndex = 4;
			this.base_P_Top_Spacer.Paint += new System.Windows.Forms.PaintEventHandler(this.P_Top_Spacer_Paint);
			// 
			// base_P_Container
			// 
			this.base_P_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(192)))), ((int)(((byte)(232)))));
			this.base_P_Container.Controls.Add(this.base_P_Content);
			this.base_P_Container.Controls.Add(this.base_P_Top_Spacer);
			this.base_P_Container.Controls.Add(this.base_P_Controls);
			this.base_P_Container.Controls.Add(this.base_P_Top);
			this.base_P_Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_Container.Location = new System.Drawing.Point(7, 7);
			this.base_P_Container.Name = "base_P_Container";
			this.base_P_Container.Padding = new System.Windows.Forms.Padding(1);
			this.base_P_Container.Size = new System.Drawing.Size(598, 339);
			this.base_P_Container.TabIndex = 5;
			// 
			// BaseForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.ClientSize = new System.Drawing.Size(615, 356);
			this.Controls.Add(this.base_P_Container);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.MinimumSize = new System.Drawing.Size(200, 180);
			this.Name = "BaseForm";
			this.Padding = new System.Windows.Forms.Padding(7, 7, 10, 10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			
			this.Load += new System.EventHandler(this.BaseForm_Load);
			this.base_P_Top.ResumeLayout(false);
			this.base_P_Top.PerformLayout();
			this.base_TLP_TopButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.base_B_Min)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Close)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Max)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.base_PB_Icon)).EndInit();
			this.base_P_Container.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolTip base_toolTip;
		private System.Windows.Forms.Panel base_P_Top;
		private System.Windows.Forms.Label base_L_Title;
		protected System.Windows.Forms.Panel base_P_Content;
		protected System.Windows.Forms.Panel base_P_Controls;
		protected System.Windows.Forms.Panel base_P_Top_Spacer;
		private System.Windows.Forms.TableLayoutPanel base_TLP_TopButtons;
    }
}