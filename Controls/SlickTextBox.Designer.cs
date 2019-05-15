namespace SlickControls.Controls
{
	partial class SlickTextBox
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
			this.TLP = new System.Windows.Forms.TableLayoutPanel();
			this.label = new System.Windows.Forms.Label();
			this.TB = new System.Windows.Forms.MaskedTextBox();
			this.P_Bar = new System.Windows.Forms.Panel();
			this.PB = new System.Windows.Forms.PictureBox();
			this.L_Placerholder = new System.Windows.Forms.Label();
			this.TLP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
			this.SuspendLayout();
			// 
			// TLP
			// 
			this.TLP.ColumnCount = 2;
			this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TLP.Controls.Add(this.label, 0, 0);
			this.TLP.Controls.Add(this.TB, 0, 1);
			this.TLP.Controls.Add(this.P_Bar, 0, 2);
			this.TLP.Controls.Add(this.PB, 1, 1);
			this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TLP.Location = new System.Drawing.Point(0, 0);
			this.TLP.Name = "TLP";
			this.TLP.RowCount = 3;
			this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
			this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
			this.TLP.Size = new System.Drawing.Size(200, 34);
			this.TLP.TabIndex = 0;
			// 
			// label
			// 
			this.TLP.SetColumnSpan(this.label, 2);
			this.label.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label.Font = new System.Drawing.Font("Century Gothic", 7.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label.Location = new System.Drawing.Point(3, 0);
			this.label.MaximumSize = new System.Drawing.Size(9999, 14);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(194, 14);
			this.label.TabIndex = 0;
			this.label.Text = "Textbox";
			// 
			// TB
			// 
			this.TB.BackColor = System.Drawing.SystemColors.Control;
			this.TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TB.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
			this.TB.Location = new System.Drawing.Point(0, 18);
			this.TB.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.TB.Name = "TB";
			this.TB.Size = new System.Drawing.Size(180, 15);
			this.TB.TabIndex = 1;
			this.TB.TextChanged += new System.EventHandler(this.TB_TextChanged);
			this.TB.Enter += new System.EventHandler(this.TB_Enter);
			this.TB.Leave += new System.EventHandler(this.TB_Leave);
			// 
			// P_Bar
			// 
			this.P_Bar.BackColor = System.Drawing.SystemColors.ControlDark;
			this.TLP.SetColumnSpan(this.P_Bar, 2);
			this.P_Bar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.P_Bar.Location = new System.Drawing.Point(0, 33);
			this.P_Bar.Margin = new System.Windows.Forms.Padding(0);
			this.P_Bar.Name = "P_Bar";
			this.P_Bar.Size = new System.Drawing.Size(200, 2);
			this.P_Bar.TabIndex = 2;
			// 
			// PB
			// 
			this.PB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PB.Location = new System.Drawing.Point(180, 14);
			this.PB.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.PB.Name = "PB";
			this.PB.Size = new System.Drawing.Size(16, 16);
			this.PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB.TabIndex = 3;
			this.PB.TabStop = false;
			this.PB.Visible = false;
			this.PB.Click += new System.EventHandler(this.PB_Click);
			// 
			// L_Placerholder
			// 
			this.L_Placerholder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.L_Placerholder.AutoSize = true;
			this.L_Placerholder.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.L_Placerholder.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic);
			this.L_Placerholder.Location = new System.Drawing.Point(5, 18);
			this.L_Placerholder.Name = "L_Placerholder";
			this.L_Placerholder.Size = new System.Drawing.Size(73, 15);
			this.L_Placerholder.TabIndex = 1;
			this.L_Placerholder.Text = "Placeholder";
			this.L_Placerholder.Click += new System.EventHandler(this.L_Placerholder_Click);
			// 
			// SlickTextBox
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.L_Placerholder);
			this.Controls.Add(this.TLP);
			this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximumSize = new System.Drawing.Size(9999, 34);
			this.MinimumSize = new System.Drawing.Size(50, 34);
			this.Name = "SlickTextBox";
			this.Size = new System.Drawing.Size(200, 34);
			this.Load += new System.EventHandler(this.SlickTextBox_Load);
			this.BackColorChanged += new System.EventHandler(this.SlickTextBox_BackColorChanged);
			this.TLP.ResumeLayout(false);
			this.TLP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.TableLayoutPanel TLP;
		protected System.Windows.Forms.Label label;
		protected System.Windows.Forms.MaskedTextBox TB;
		protected System.Windows.Forms.Panel P_Bar;
		protected System.Windows.Forms.Label L_Placerholder;
		protected System.Windows.Forms.PictureBox PB;
	}
}
