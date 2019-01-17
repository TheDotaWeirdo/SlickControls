namespace SlickControls.Forms
{
	partial class FlatToolStrip
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
			this.TLP_Container = new System.Windows.Forms.TableLayoutPanel();
			this.SuspendLayout();
			// 
			// TLP_Container
			// 
			this.TLP_Container.AutoSize = true;
			this.TLP_Container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TLP_Container.ColumnCount = 1;
			this.TLP_Container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TLP_Container.Dock = System.Windows.Forms.DockStyle.Top;
			this.TLP_Container.Location = new System.Drawing.Point(0, 0);
			this.TLP_Container.Margin = new System.Windows.Forms.Padding(0);
			this.TLP_Container.Name = "TLP_Container";
			this.TLP_Container.Padding = new System.Windows.Forms.Padding(1);
			this.TLP_Container.RowCount = 1;
			this.TLP_Container.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TLP_Container.Size = new System.Drawing.Size(119, 2);
			this.TLP_Container.TabIndex = 1;
			// 
			// FlatToolStrip
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(120, 0);
			this.Controls.Add(this.TLP_Container);
			this.Font = new System.Drawing.Font("Century Gothic", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FlatToolStrip";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.FlatToolStrip_Leave);
			this.Load += new System.EventHandler(this.FlatToolStrip_Load);
			this.Leave += new System.EventHandler(this.FlatToolStrip_Leave);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel TLP_Container;
	}
}