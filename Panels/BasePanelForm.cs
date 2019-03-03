using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using SlickControls.Forms;

namespace SlickControls.Panels
{
	public partial class BasePanelForm : SlickForm
	{
		#region Private Fields

		private TableLayoutPanel base_TLP_PanelItems;
		private Image formIcon;
		private List<PanelContent> panelHistory = new List<PanelContent>();
		private PanelItem[] sidebarItems = new PanelItem[0];

		#endregion Private Fields

		#region Public Properties

		public PanelContent CurrentPanel { get; private set; }

		[Category("Appearance")]
		public override Image FormIcon { get => formIcon; set { base_PB_Icon.Image = formIcon = value.Color(FormDesign.Design.IconColor); } }

		[Category("Appearance")]
		public override Rectangle IconBounds { get => base_PB_Icon.Bounds; set => base_PB_Icon.Bounds = value; }

		public new bool MaximizeBox { get => base_B_Max.Visible; set => base_B_Max.Visible = value; }

		public new bool MinimizeBox { get => base_B_Min.Visible; set => base_B_Min.Visible = value; }

		[Category("Design")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PanelItem[] SidebarItems
		{
			get => sidebarItems;
			set
			{
				sidebarItems = value;
				GenerateTabs();
			}
		}

		public IEnumerable<PanelContent> PanelHistory => panelHistory;

		#endregion Public Properties

		#region Protected Properties

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= 0x20000; // <--- use 0x20000
				return cp;
			}
		}

		#endregion Protected Properties

		#region Public Constructors

		public BasePanelForm() : this(false)
		{ }

		public BasePanelForm(bool initialized)
		{
			InitializeComponent();

			if (DesignMode)
				SetPanel<PanelContent>(null);

			if (!initialized)
				FormDesign.DesignChanged += DesignChanged;

			base_P_Tabs.MouseDown += Form_MouseDown;
			base_P_Icon.MouseDown += Form_MouseDown;
			base_P_SideControls.MouseDown += Form_MouseDown;
		}

		#endregion Public Constructors

		#region Public Methods

		public void PushBack(bool dispose = true)
		{
			var panel = panelHistory.LastOrDefault();

			if (panel != null)
			{
				panelHistory.Remove(panel);
				SetPanel(panel.PanelItem, panel, dispose, false);
			}
		}

		public void PushPanel<T>(PanelItem panelItem) where T : PanelContent, new()
		{
			if (CurrentPanel != null)
			{
				panelHistory.Add(CurrentPanel);
				base_P_PanelContent.Controls.Remove(CurrentPanel);
				CurrentPanel = null;
			}

			SetPanel<T>(panelItem, false, false);
		}

		public void PushPanel(PanelItem panelItem, PanelContent panelContent)
		{
			if (CurrentPanel != null)
			{
				panelHistory.Add(CurrentPanel);
				base_P_PanelContent.Controls.Remove(CurrentPanel);
				CurrentPanel = null;
			}

			SetPanel(panelItem, panelContent, false, false);
		}

		public void SetPanel<T>(PanelItem panelItem, bool dispose = true, bool clearHistory = true) where T : PanelContent, new()
		{
			if (CurrentPanel != null && ((CurrentPanel.PanelItem == panelItem && !panelItem.ForceReopen) || !CurrentPanel.CanExit()))
				return;

			if (clearHistory)
			{
				panelHistory?.ForEach(x => x.TryInvoke(x.Dispose));
				panelHistory?.Clear();
			}

			base_P_PanelContent.SuspendDrawing();

			if (CurrentPanel != null)
				base_P_PanelContent.Controls.Remove(CurrentPanel);
			CurrentPanel?.Dispose();

			CurrentPanel = new T
			{
				Size = base_P_PanelContent.Size,
				Dock = DockStyle.Fill,
				PanelItem = panelItem
			};

			if (!CurrentPanel.PanelWasSetUp)
			{
				RecursiveMouseDown(CurrentPanel);
				CurrentPanel.PanelWasSetUp = true;
			}

			if (CurrentPanel.AcceptButton != null)
			{
				var btn = new Button();
				AcceptButton = btn;
				btn.Click += (s, e) => { if (CurrentPanel.AcceptButton.Enabled) CurrentPanel.AcceptButton.OnClick(e); };
			}
			else
				AcceptButton = null;

			if (CurrentPanel.CancelButton != null)
			{
				var btn = new Button();
				CancelButton = btn;
				btn.Click += (s, e) => { if (CurrentPanel.CancelButton.Enabled) CurrentPanel.CancelButton.OnClick(e); };
			}
			else
				CancelButton = null;

			base_P_PanelContent.Controls.Add(CurrentPanel);

			if (base_TLP_PanelItems != null && panelItem != null)
				foreach (var item in base_TLP_PanelItems.Controls.ThatAre<PanelItemControl>())
					item.Selected = item.PanelItem == panelItem;

			base_P_PanelContent.ResumeDrawing();

			CurrentPanel.Focus();
		}

		public void SetPanel(PanelItem panelItem, PanelContent panelContent, bool dispose = true, bool clearHistory = true)
		{
			if (CurrentPanel != null && (
					(CurrentPanel.PanelItem != null && CurrentPanel.PanelItem == panelItem && !panelItem.ForceReopen)
					|| (dispose && !CurrentPanel.CanExit())
				))
				return;

			if (clearHistory)
			{
				panelHistory?.ForEach(x => x.TryInvoke(x.Dispose));
				panelHistory?.Clear();
			}

			base_P_PanelContent.SuspendDrawing();

			if (dispose)
				CurrentPanel?.Dispose();
			else if (CurrentPanel != null)
				base_P_PanelContent.Controls.Remove(CurrentPanel);

			CurrentPanel = panelContent;

			CurrentPanel.Size = base_P_PanelContent.Size;
			CurrentPanel.Dock = DockStyle.Fill;
			CurrentPanel.PanelItem = panelItem;

			if (!CurrentPanel.PanelWasSetUp)
			{
				RecursiveMouseDown(CurrentPanel);
				CurrentPanel.PanelWasSetUp = true;
			}

			if (CurrentPanel.AcceptButton != null)
			{
				var btn = new Button();
				AcceptButton = btn;
				btn.Click += (s, e) => { if (CurrentPanel.AcceptButton.Enabled) CurrentPanel.AcceptButton.OnClick(e); };
			}
			else
				AcceptButton = null;

			if (CurrentPanel.CancelButton != null)
			{
				var btn = new Button();
				CancelButton = btn;
				btn.Click += (s, e) => { if (CurrentPanel.CancelButton.Enabled) CurrentPanel.CancelButton.OnClick(e); };
			}
			else
				CancelButton = null;

			base_P_PanelContent.Controls.Add(CurrentPanel);

			if (base_TLP_PanelItems != null && panelItem != null)
				foreach (var item in base_TLP_PanelItems.Controls.ThatAre<PanelItemControl>())
					item.Selected = item.PanelItem == panelItem;

			base_P_PanelContent.ResumeDrawing();

			CurrentPanel.Focus();
		}

		#endregion Public Methods

		#region Protected Methods

		protected override void DesignChanged(FormDesign design)
		{
			base.DesignChanged(design);

			base_P_PanelContent.BackColor = base_TLP_TopButtons.BackColor = design.BackColor;
			base_P_Content.BackColor = design.MenuColor;
			base_P_Side.ForeColor = design.LabelColor;
			base_P_SideControls.ForeColor = design.LabelColor.MergeColor(design.ID.If(0, design.AccentColor, design.MenuColor), 80);

			if (base_TLP_PanelItems != null)
				foreach (var item in base_TLP_PanelItems.Controls.ThatAre<Panel>())
					item.BackColor = design.AccentColor;

			base_PB_Icon.Color(design.MenuForeColor);
			base_B_Close.Color(design.RedColor);
			base_B_Max.Color(design.YellowColor);
			base_B_Min.Color(design.GreenColor);
		}

		protected void DisableSideBar()
		{
			foreach (var item in base_TLP_PanelItems.Controls.ThatAre<PanelItemControl>())
				item.Enabled = false;
		}

		protected void EnableSideBar()
		{
			foreach (var item in base_TLP_PanelItems.Controls.ThatAre<PanelItemControl>())
				item.Enabled = true;
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			base_P_SideControls?.BringToFront();
			base_TLP_PanelItems?.BringToFront();
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (CurrentPanel != null && CurrentPanel.KeyPressed(e.KeyChar))
				return;

			base.OnKeyPress(e);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (CurrentPanel != null && CurrentPanel.KeyPressed(ref msg, keyData))
				return true;

			if (keyData == Keys.Escape && CancelButton == null)
			{
				if (PanelHistory.Any())
				{ PushBack(); return true; }
				else if (WindowState == FormWindowState.Maximized)
				{ WindowState = FormWindowState.Normal; return true; }
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);

			if (m.Msg == 0x210 && m.WParam == (IntPtr)0x1020b && PanelHistory.Any())
				PushBack();
		}

		#endregion Protected Methods

		#region Private Methods

		private void GenerateTabs()
		{
			base_TLP_PanelItems?.Dispose();
			base_TLP_PanelItems = new TableLayoutPanel()
			{
				MaximumSize = new Size(base_P_Side.Width, 9999),
				MinimumSize = new Size(base_P_Side.Width, 0),
				AutoSize = true
			};

			base_TLP_PanelItems.MouseDown += Form_MouseDown;

			foreach (var group in sidebarItems.Select(x => x.Group).Distinct())
			{
				if (!string.IsNullOrWhiteSpace(group))
				{
					var label = new Label()
					{
						Text = group.ToUpper(),
						Margin = new Padding(7, 10, 0, 0),
						MaximumSize = new Size(175, 17)
					};

					base_TLP_PanelItems.Controls.Add(label);
				}

				var items = sidebarItems.Where(x => x.Group == group);

				foreach (var item in items)
				{
					var panelitem = new PanelItemControl(item)
					{
						Margin = new Padding(0)
					};

					base_TLP_PanelItems.Controls.Add(panelitem);
				}

				if (group != sidebarItems.Select(x => x.Group).Distinct().Last())
					base_TLP_PanelItems.Controls.Add(new Panel()
					{
						BackColor = FormDesign.Design.AccentColor,
						Size = new Size(base_P_Side.Width - 30, 1),
						Dock = DockStyle.Top,
						Margin = new Padding(15, 5, 15, 0)
					});
			}

			for (int i = 0; i < base_TLP_PanelItems.RowCount; i++)
				base_TLP_PanelItems.RowStyles[i].SizeType = SizeType.AutoSize;

			base_P_Tabs.Controls.Add(base_TLP_PanelItems);
			base_SideScroll.LinkedControl = base_TLP_PanelItems;
		}

		private void RecursiveMouseDown(Control ctrl, int level = 0)
		{
			if (level < 5 && (ctrl is Panel || ctrl is UserControl))
			{
				ctrl.MouseDown += Form_MouseDown;

				foreach (var item in ctrl.Controls.ThatAre<Panel>())
					RecursiveMouseDown(item, level + 1);

				if (level <= 1)
					foreach (var item in ctrl.Controls.ThatAre<Label>())
						item.MouseDown += Form_MouseDown;
			}
		}

		#endregion Private Methods
	}
}