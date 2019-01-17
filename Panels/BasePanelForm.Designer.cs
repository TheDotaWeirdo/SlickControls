namespace SlickControls.Panels
{
	partial class BasePanelForm
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
			this.base_P_Content = new System.Windows.Forms.Panel();
			this.base_TLP_TopButtons = new System.Windows.Forms.TableLayoutPanel();
			this.base_P_PanelContent = new System.Windows.Forms.Panel();
			this.base_P_Side = new System.Windows.Forms.Panel();
			this.base_SideScroll = new SlickControls.Controls.VerticalScroll();
			this.base_P_Tabs = new System.Windows.Forms.Panel();
			this.base_P_SideControls = new System.Windows.Forms.Panel();
			this.base_P_Icon = new System.Windows.Forms.Panel();
			this.base_P_Content.SuspendLayout();
			this.base_TLP_TopButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Min)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Close)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Max)).BeginInit();
			this.base_P_Side.SuspendLayout();
			this.base_P_Tabs.SuspendLayout();
			this.base_P_Icon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.base_PB_Icon)).BeginInit();
			this.base_P_Container.SuspendLayout();
			this.SuspendLayout();
			// 
			// base_P_Content
			// 
			this.base_P_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(79)))));
			this.base_P_Content.Controls.Add(this.base_TLP_TopButtons);
			this.base_P_Content.Controls.Add(this.base_P_PanelContent);
			this.base_P_Content.Controls.Add(this.base_P_Side);
			this.base_P_Content.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_Content.Location = new System.Drawing.Point(1, 1);
			this.base_P_Content.Margin = new System.Windows.Forms.Padding(0);
			this.base_P_Content.Name = "base_P_Content";
			this.base_P_Content.Size = new System.Drawing.Size(842, 471);
			this.base_P_Content.TabIndex = 2;
			// 
			// base_TLP_TopButtons
			// 
			this.base_TLP_TopButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.base_TLP_TopButtons.AutoSize = true;
			this.base_TLP_TopButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.base_TLP_TopButtons.ColumnCount = 3;
			this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.base_TLP_TopButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.base_TLP_TopButtons.Controls.Add(this.base_B_Min, 0, 0);
			this.base_TLP_TopButtons.Controls.Add(this.base_B_Close, 2, 0);
			this.base_TLP_TopButtons.Controls.Add(this.base_B_Max, 1, 0);
			this.base_TLP_TopButtons.Location = new System.Drawing.Point(778, 6);
			this.base_TLP_TopButtons.Name = "base_TLP_TopButtons";
			this.base_TLP_TopButtons.RowCount = 1;
			this.base_TLP_TopButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.base_TLP_TopButtons.Size = new System.Drawing.Size(58, 16);
			this.base_TLP_TopButtons.TabIndex = 10;
			// 
			// base_B_Min
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
			// 
			// base_P_PanelContent
			// 
			this.base_P_PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_PanelContent.Location = new System.Drawing.Point(165, 0);
			this.base_P_PanelContent.Name = "base_P_PanelContent";
			this.base_P_PanelContent.Size = new System.Drawing.Size(677, 471);
			this.base_P_PanelContent.TabIndex = 1;
			// 
			// base_P_Side
			// 
			this.base_P_Side.Controls.Add(this.base_SideScroll);
			this.base_P_Side.Controls.Add(this.base_P_Tabs);
			this.base_P_Side.Controls.Add(this.base_P_Icon);
			this.base_P_Side.Dock = System.Windows.Forms.DockStyle.Left;
			this.base_P_Side.Location = new System.Drawing.Point(0, 0);
			this.base_P_Side.Name = "base_P_Side";
			this.base_P_Side.Size = new System.Drawing.Size(165, 471);
			this.base_P_Side.TabIndex = 0;
			// 
			// base_SideScroll
			// 
			this.base_SideScroll.AutoResize = false;
			this.base_SideScroll.BarColor = null;
			this.base_SideScroll.Dock = System.Windows.Forms.DockStyle.Left;
			this.base_SideScroll.LinkedControl = null;
			this.base_SideScroll.Location = new System.Drawing.Point(0, 72);
			this.base_SideScroll.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
			this.base_SideScroll.Name = "base_SideScroll";
			this.base_SideScroll.Size = new System.Drawing.Size(4, 399);
			this.base_SideScroll.TabIndex = 11;
			// 
			// base_P_Tabs
			// 
			this.base_P_Tabs.Controls.Add(this.base_P_SideControls);
			this.base_P_Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_Tabs.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.base_P_Tabs.Location = new System.Drawing.Point(0, 72);
			this.base_P_Tabs.Name = "base_P_Tabs";
			this.base_P_Tabs.Size = new System.Drawing.Size(165, 399);
			this.base_P_Tabs.TabIndex = 10;
			// 
			// base_P_SideControls
			// 
			this.base_P_SideControls.AutoSize = true;
			this.base_P_SideControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.base_P_SideControls.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.base_P_SideControls.Location = new System.Drawing.Point(0, 349);
			this.base_P_SideControls.MinimumSize = new System.Drawing.Size(0, 50);
			this.base_P_SideControls.Name = "base_P_SideControls";
			this.base_P_SideControls.Size = new System.Drawing.Size(165, 50);
			this.base_P_SideControls.TabIndex = 0;
			// 
			// base_P_Icon
			// 
			this.base_P_Icon.Controls.Add(this.base_PB_Icon);
			this.base_P_Icon.Dock = System.Windows.Forms.DockStyle.Top;
			this.base_P_Icon.Location = new System.Drawing.Point(0, 0);
			this.base_P_Icon.Name = "base_P_Icon";
			this.base_P_Icon.Size = new System.Drawing.Size(165, 72);
			this.base_P_Icon.TabIndex = 9;
			// 
			// base_PB_Icon
			// 
			this.base_PB_Icon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.base_PB_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.base_PB_Icon.Location = new System.Drawing.Point(66, 20);
			this.base_PB_Icon.Name = "base_PB_Icon";
			this.base_PB_Icon.Size = new System.Drawing.Size(32, 32);
			this.base_PB_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.base_PB_Icon.TabIndex = 9;
			this.base_PB_Icon.TabStop = false;
			// 
			// base_P_Container
			// 
			this.base_P_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(192)))), ((int)(((byte)(232)))));
			this.base_P_Container.Controls.Add(this.base_P_Content);
			this.base_P_Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.base_P_Container.Location = new System.Drawing.Point(7, 7);
			this.base_P_Container.Name = "base_P_Container";
			this.base_P_Container.Padding = new System.Windows.Forms.Padding(1);
			this.base_P_Container.Size = new System.Drawing.Size(844, 473);
			this.base_P_Container.TabIndex = 5;
			// 
			// BasePanelForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.ClientSize = new System.Drawing.Size(861, 490);
			this.Controls.Add(this.base_P_Container);
			this.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(59)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.MinimumSize = new System.Drawing.Size(200, 180);
			this.Name = "BasePanelForm";
			this.Padding = new System.Windows.Forms.Padding(7, 7, 10, 10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.base_P_Content.ResumeLayout(false);
			this.base_P_Content.PerformLayout();
			this.base_TLP_TopButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.base_B_Min)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Close)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.base_B_Max)).EndInit();
			this.base_P_Side.ResumeLayout(false);
			this.base_P_Tabs.ResumeLayout(false);
			this.base_P_Tabs.PerformLayout();
			this.base_P_Icon.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.base_PB_Icon)).EndInit();
			this.base_P_Container.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		protected System.Windows.Forms.Panel base_P_Content;
		private System.Windows.Forms.Panel base_P_Side;
		private System.Windows.Forms.Panel base_P_Icon;
		private System.Windows.Forms.Panel base_P_PanelContent;
		private System.Windows.Forms.TableLayoutPanel base_TLP_TopButtons;
		protected System.Windows.Forms.Panel base_P_SideControls;
		private System.Windows.Forms.Panel base_P_Tabs;
		private Controls.VerticalScroll base_SideScroll;
	}
}