namespace SlickControls.Controls
{
	partial class SlickPathTextBox
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
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// L_Placerholder
			// 
			this.L_Placerholder.Size = new System.Drawing.Size(74, 16);
			this.L_Placerholder.Text = "Folder Path";
			// 
			// SlickPathTextBox
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Image = global::SlickControls.Properties.Resources.Tiny_Search;
			this.LabelText = "Folder";
			this.MinimumSize = new System.Drawing.Size(50, 35);
			this.Name = "SlickPathTextBox";
			this.Placeholder = "Folder Path";
			this.Size = new System.Drawing.Size(200, 35);
			this.Validation = SlickControls.Enums.ValidationType.Custom;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderDialog;
	}
}
