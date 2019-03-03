namespace SlickControls.Controls
{
	partial class SlickScroll
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
			this.Bar = new System.Windows.Forms.Control();
			this.SuspendLayout();
			// 
			// Bar
			// 
			this.Bar.Location = new System.Drawing.Point(0, 0);
			this.Bar.Name = "Bar";
			this.Bar.Size = new System.Drawing.Size(0, 0);
			this.Bar.TabIndex = 0;
			// 
			// SlickScroll
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Name = "SlickScroll";
			this.Size = new System.Drawing.Size(12, 137);
			this.Load += new System.EventHandler(this.LinkedControl_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SlickScroll_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlickScroll_MouseDown);
			this.MouseEnter += new System.EventHandler(this.SlickScroll_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.SlickScroll_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SlickScroll_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SlickScroll_MouseUp);
			this.Resize += new System.EventHandler(this.SlickScroll_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Control Bar;
	}
}
