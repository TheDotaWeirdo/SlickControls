namespace SlickControls.Controls
{
	partial class DropDownItem
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
			// DropDownItem
			// 
			this.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
			this.Size = new System.Drawing.Size(200, 18);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DropDownItem_Paint);
			this.Enter += new System.EventHandler(this.DropDownItem_Enter);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DropDownItem_KeyPress);
			this.Leave += new System.EventHandler(this.DropDownItem_Leave);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DropDownItem_MouseDown);
			this.MouseEnter += new System.EventHandler(this.DropDownItem_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.DropDownItem_MouseLeave);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DropDownItem_MouseUp);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
