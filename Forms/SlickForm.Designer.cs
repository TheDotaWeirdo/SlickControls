﻿namespace SlickControls.Forms
{
	partial class SlickForm
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
			this.base_P_Container = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			base_B_Close = new Controls.TopIcon();
			base_B_Max = new Controls.TopIcon();
			base_B_Min = new Controls.TopIcon();
			base_PB_Icon = new System.Windows.Forms.PictureBox();
			// 
			// base_P_Container
			// 
			this.base_P_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(192)))), ((int)(((byte)(232)))));
			this.base_P_Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_Container.Location = new System.Drawing.Point(7, 7);
			this.base_P_Container.Name = "base_P_Container";
			this.base_P_Container.Padding = new System.Windows.Forms.Padding(1);
			this.base_P_Container.Size = new System.Drawing.Size(583, 333);
			this.base_P_Container.TabIndex = 0;
			// 
			// SlickForm
			// 
			this.base_B_Min.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.base_B_Min.Color = SlickControls.Controls.TopIcon.IconStyle.Minimize;
			this.base_B_Min.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_B_Min.Location = new System.Drawing.Point(0, 0);
			this.base_B_Min.Margin = new System.Windows.Forms.Padding(0);
			this.base_B_Min.Name = "base_B_Min";
			this.base_B_Min.Size = new System.Drawing.Size(16, 16);
			this.base_B_Min.TabIndex = 4;
			this.base_B_Min.TabStop = false;
			// 
			// base_B_Close
			// 
			this.base_B_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.base_B_Close.Color = SlickControls.Controls.TopIcon.IconStyle.Close;
			this.base_B_Close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_B_Close.Location = new System.Drawing.Point(42, 0);
			this.base_B_Close.Margin = new System.Windows.Forms.Padding(0);
			this.base_B_Close.Name = "base_B_Close";
			this.base_B_Close.Size = new System.Drawing.Size(16, 16);
			this.base_B_Close.TabIndex = 1;
			this.base_B_Close.TabStop = false;
			this.base_B_Close.Click += new System.EventHandler(this.base_B_Close_Click);
			// 
			// base_B_Max
			// 
			this.base_B_Max.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.base_B_Max.Color = SlickControls.Controls.TopIcon.IconStyle.Maximize;
			this.base_B_Max.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_B_Max.Location = new System.Drawing.Point(21, 0);
			this.base_B_Max.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.base_B_Max.Name = "base_B_Max";
			this.base_B_Max.Size = new System.Drawing.Size(16, 16);
			this.base_B_Max.TabIndex = 5;
			this.base_B_Max.TabStop = false;
			this.base_PB_Icon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.base_PB_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_PB_Icon.Location = new System.Drawing.Point(66, 20);
			this.base_PB_Icon.Name = "base_PB_Icon";
			this.base_PB_Icon.Size = new System.Drawing.Size(32, 32);
			this.base_PB_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.base_PB_Icon.TabIndex = 9;
			this.base_PB_Icon.TabStop = false;

			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.ClientSize = new System.Drawing.Size(600, 350);
			this.Controls.Add(this.base_P_Container);
			this.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.MinimumSize = new System.Drawing.Size(200, 180);
			this.Name = "SlickForm";
			this.Padding = new System.Windows.Forms.Padding(7, 7, 10, 10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SlickForm";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			this.Resize += new System.EventHandler(this.BaseForm_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Panel base_P_Container;

		protected System.Windows.Forms.PictureBox base_PB_Icon;
		protected Controls.TopIcon base_B_Close;
		protected Controls.TopIcon base_B_Max;
		protected Controls.TopIcon base_B_Min;
	}
}