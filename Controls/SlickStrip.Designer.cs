﻿namespace SlickControls.Controls
{
	partial class SlickStrip
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
			this.SuspendLayout();
			// 
			// SlickStrip
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SlickStrip";
			this.Size = new System.Drawing.Size(150, 20);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SlickStrip_Paint);
			this.ResumeLayout(false);

		}

		#endregion
	}
}