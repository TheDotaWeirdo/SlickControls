namespace SlickControls.Forms
{
	partial class DropDownItems
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
			this.panel = new System.Windows.Forms.Panel();
			this.P_Items = new System.Windows.Forms.Panel();
			this.verticalScroll1 = new SlickControls.Controls.VerticalScroll();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Controls.Add(this.verticalScroll1);
			this.panel.Controls.Add(this.P_Items);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(1, 1);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(218, 248);
			this.panel.TabIndex = 0;
			// 
			// P_Items
			// 
			this.P_Items.AutoSize = true;
			this.P_Items.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.P_Items.Location = new System.Drawing.Point(0, 0);
			this.P_Items.MaximumSize = new System.Drawing.Size(218, 9999);
			this.P_Items.MinimumSize = new System.Drawing.Size(218, 0);
			this.P_Items.Name = "P_Items";
			this.P_Items.Size = new System.Drawing.Size(218, 0);
			this.P_Items.TabIndex = 0;
			// 
			// verticalScroll1
			// 
			this.verticalScroll1.AutoResize = false;
			this.verticalScroll1.BarColor = null;
			this.verticalScroll1.Dock = System.Windows.Forms.DockStyle.Right;
			this.verticalScroll1.LinkedControl = this.P_Items;
			this.verticalScroll1.Location = new System.Drawing.Point(214, 0);
			this.verticalScroll1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.verticalScroll1.Name = "verticalScroll1";
			this.verticalScroll1.Size = new System.Drawing.Size(4, 248);
			this.verticalScroll1.TabIndex = 1;
			// 
			// DropDownItems
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(162)))), ((int)(((byte)(229)))));
			this.ClientSize = new System.Drawing.Size(220, 250);
			this.Controls.Add(this.panel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DropDownItems";
			this.Padding = new System.Windows.Forms.Padding(1);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "DropDownItems";
			this.TopMost = true;
			this.Resize += new System.EventHandler(this.DropDownItems_Resize);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private Controls.VerticalScroll verticalScroll1;
		private System.Windows.Forms.Panel P_Items;
	}
}