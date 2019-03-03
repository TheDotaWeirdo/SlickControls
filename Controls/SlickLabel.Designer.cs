namespace SlickControls.Controls
{
	partial class SlickLabel
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
            // SlickLabel
            // 
            this.AutoSize = true;
            this.DoubleBuffered = true;
            this.Name = "SlickLabel";
            this.Size = new System.Drawing.Size(0, 0);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SlickButton_Paint);
            this.Enter += new System.EventHandler(this.SlickLabel_Focus);
            this.Leave += new System.EventHandler(this.SlickLabel_Focus);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MyLabel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MyLabel_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyLabel_MouseUp);
            this.Resize += new System.EventHandler(this.MyLabel_Resize);
            this.ResumeLayout(false);

		}

		#endregion
	}
}
