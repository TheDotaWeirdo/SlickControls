namespace SlickControls.Controls
{
	partial class HorizontalScroll
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
			this.Bar = new HorizontalBar();
			((System.ComponentModel.ISupportInitialize)(this.Bar)).BeginInit();
			this.SuspendLayout();
			// 
			// Bar
			// 
			this.Bar.Border = 0;
			this.Bar.Location = new System.Drawing.Point(0, 0);
			this.Bar.Margin = new System.Windows.Forms.Padding(0);
			this.Bar.MaximumSize = new System.Drawing.Size(9999, 15);
			this.Bar.Name = "Bar";
			this.Bar.Size = new System.Drawing.Size(150, 15);
			this.Bar.TabIndex = 0;
			this.Bar.TabStop = false;
			// 
			// HorizontalScroll
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.Bar);
			this.Name = "HorizontalScroll";
			this.Size = new System.Drawing.Size(506, 15);
			this.Resize += new System.EventHandler(this.HorizontalScroll_Resize);
			((System.ComponentModel.ISupportInitialize)(this.Bar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private HorizontalBar Bar;
	}
}
