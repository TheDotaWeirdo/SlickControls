﻿namespace SlickControls.Forms
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
            this.base_P_Top_Spacer = new System.Windows.Forms.Panel();
            this.base_TLP_TopButtons = new System.Windows.Forms.TableLayoutPanel();
            this.base_L_Title = new System.Windows.Forms.Label();
            this.base_P_Content = new System.Windows.Forms.Panel();
            this.base_P_Controls = new System.Windows.Forms.Panel();
            this.base_P_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.base_PB_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_B_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_B_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_B_Min)).BeginInit();
            this.base_P_Top.SuspendLayout();
            this.base_TLP_TopButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // base_P_Container
            // 
            this.base_P_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(157)))), ((int)(((byte)(22)))));
            this.base_P_Container.Controls.Add(this.base_P_Content);
            this.base_P_Container.Controls.Add(this.base_P_Controls);
            this.base_P_Container.Controls.Add(this.base_P_Top);
            this.base_P_Container.Size = new System.Drawing.Size(598, 339);
            this.base_P_Container.TabIndex = 5;
            // 
            // base_PB_Icon
            // 
            this.base_PB_Icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.base_PB_Icon.Location = new System.Drawing.Point(3, 4);
            this.base_PB_Icon.Size = new System.Drawing.Size(16, 16);
            this.base_PB_Icon.TabIndex = 7;
            // 
            // base_B_Close
            // 
            this.base_B_Close.Image = global::SlickControls.Properties.Resources.Circle;
            this.base_B_Close.Location = new System.Drawing.Point(40, 0);
            this.base_B_Close.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.base_B_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // base_B_Max
            // 
            this.base_B_Max.Image = global::SlickControls.Properties.Resources.Circle;
            this.base_B_Max.Location = new System.Drawing.Point(20, 0);
            this.base_B_Max.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.base_B_Max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // base_B_Min
            // 
            this.base_B_Min.Image = global::SlickControls.Properties.Resources.Circle;
            this.base_B_Min.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.base_B_Min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.base_P_Top.Controls.Add(this.base_P_Top_Spacer);
            this.base_P_Top.Controls.Add(this.base_TLP_TopButtons);
            this.base_P_Top.Controls.Add(this.base_PB_Icon);
            this.base_P_Top.Controls.Add(this.base_L_Title);
            this.base_P_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.base_P_Top.Location = new System.Drawing.Point(1, 1);
            this.base_P_Top.Margin = new System.Windows.Forms.Padding(0);
            this.base_P_Top.Name = "base_P_Top";
            this.base_P_Top.Size = new System.Drawing.Size(596, 24);
            this.base_P_Top.TabIndex = 1;
            this.base_P_Top.Controls.SetChildIndex(this.base_L_Title, 0);
            this.base_P_Top.Controls.SetChildIndex(this.base_PB_Icon, 0);
            this.base_P_Top.Controls.SetChildIndex(this.base_TLP_TopButtons, 0);
            this.base_P_Top.Controls.SetChildIndex(this.base_P_Top_Spacer, 0);
            // 
            // base_P_Top_Spacer
            // 
            this.base_P_Top_Spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.base_P_Top_Spacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.base_P_Top_Spacer.Location = new System.Drawing.Point(0, 0);
            this.base_P_Top_Spacer.Margin = new System.Windows.Forms.Padding(0);
            this.base_P_Top_Spacer.Name = "base_P_Top_Spacer";
            this.base_P_Top_Spacer.Size = new System.Drawing.Size(596, 2);
            this.base_P_Top_Spacer.TabIndex = 9;
            this.base_P_Top_Spacer.Paint += new System.Windows.Forms.PaintEventHandler(this.P_Top_Spacer_Paint);
            // 
            // base_TLP_TopButtons
            // 
            this.base_TLP_TopButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.base_TLP_TopButtons.AutoSize = true;
            this.base_TLP_TopButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.base_TLP_TopButtons.ColumnCount = 3;
            this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.base_TLP_TopButtons.Controls.Add(this.base_B_Min, 0, 0);
            this.base_TLP_TopButtons.Controls.Add(this.base_B_Close, 2, 0);
            this.base_TLP_TopButtons.Controls.Add(this.base_B_Max, 1, 0);
            this.base_TLP_TopButtons.Location = new System.Drawing.Point(536, 4);
            this.base_TLP_TopButtons.Name = "base_TLP_TopButtons";
            this.base_TLP_TopButtons.RowCount = 1;
            this.base_TLP_TopButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.base_TLP_TopButtons.Size = new System.Drawing.Size(60, 16);
            this.base_TLP_TopButtons.TabIndex = 8;
            // 
            // base_L_Title
            // 
            this.base_L_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.base_L_Title.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.base_L_Title.ForeColor = System.Drawing.Color.White;
            this.base_L_Title.Location = new System.Drawing.Point(0, 0);
            this.base_L_Title.Name = "base_L_Title";
            this.base_L_Title.Size = new System.Drawing.Size(596, 24);
            this.base_L_Title.TabIndex = 6;
            this.base_L_Title.Text = "Form";
            this.base_L_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.base_L_Title.TextChanged += new System.EventHandler(this.L_Title_TextChanged);
            // 
            // base_P_Content
            // 
            this.base_P_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.base_P_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.base_P_Content.Location = new System.Drawing.Point(1, 25);
            this.base_P_Content.Margin = new System.Windows.Forms.Padding(0);
            this.base_P_Content.Name = "base_P_Content";
            this.base_P_Content.Size = new System.Drawing.Size(596, 313);
            this.base_P_Content.TabIndex = 2;
            // 
            // base_P_Controls
            // 
            this.base_P_Controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.base_P_Controls.Dock = System.Windows.Forms.DockStyle.Top;
            this.base_P_Controls.Location = new System.Drawing.Point(1, 25);
            this.base_P_Controls.Margin = new System.Windows.Forms.Padding(0);
            this.base_P_Controls.Name = "base_P_Controls";
            this.base_P_Controls.Size = new System.Drawing.Size(596, 0);
            this.base_P_Controls.TabIndex = 3;
            this.base_P_Controls.Visible = false;
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(615, 356);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(69)))));
            this.Name = "BaseForm";
            this.Text = "Form";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.base_P_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.base_PB_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_B_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_B_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_B_Min)).EndInit();
            this.base_P_Top.ResumeLayout(false);
            this.base_P_Top.PerformLayout();
            this.base_TLP_TopButtons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolTip base_toolTip;
		private System.Windows.Forms.Panel base_P_Top;
		private System.Windows.Forms.Label base_L_Title;
		protected System.Windows.Forms.Panel base_P_Content;
		protected System.Windows.Forms.Panel base_P_Controls;
		private System.Windows.Forms.TableLayoutPanel base_TLP_TopButtons;
        protected System.Windows.Forms.Panel base_P_Top_Spacer;
    }
}