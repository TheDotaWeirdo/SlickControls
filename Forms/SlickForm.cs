using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;
using SlickControls.Panels;

namespace SlickControls.Forms
{
	public partial class SlickForm : Form, ISlickForm
	{
		#region Public Events

		public event Action<Message> OnWndProc;

		[Category("Property Changed"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event EventHandler WindowStateChanged;

		#endregion Public Events

		#region Public Properties

		[Category("Behavior"), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
		public bool CloseForm { get; set; } = true;

		public virtual Image FormIcon { get; set; }
		public virtual Rectangle IconBounds { get; set; }

		public new FormWindowState WindowState
		{
			get => base.WindowState;
			set
			{
				var change = base.WindowState != value;
				base.WindowState = value;
				if (change)
					WindowStateChanged?.Invoke(this, new EventArgs());
			}
		}

		#endregion Public Properties

		#region Public Constructors

		public SlickForm()
		{
			InitializeComponent();
		}

		#endregion Public Constructors

		#region Protected Methods

		protected void base_B_Close_Click(object sender, EventArgs e)
		{
			if (CloseForm)
				Close();
			else
				Hide();
		}

		protected virtual void DesignChanged(FormDesign design)
		{
			ForeColor = design.ForeColor;
			base_P_Container.BackColor = CurrentFormState.Color();

			if (!DesignMode)
			{
				base_PB_Icon.Color(design.MenuForeColor);
				base_B_Close.Color(design.RedColor);
				base_B_Max.Color(design.YellowColor);
				base_B_Min.Color(design.GreenColor);
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			if (!DesignMode)
			{
				base_PB_Icon.Click += base_PB_Icon_Click;
				base_B_Close.Click += base_B_Close_Click;
				base_B_Max.Click += base_B_Max_Click;
				base_B_Min.Click += base_B_Min_Click;
			}

			DesignChanged(FormDesign.Design);
		}

		#endregion Protected Methods

		#region Private Methods

		private void base_B_Max_Click(object sender, EventArgs e)
			=> WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;

		private void base_B_Min_Click(object sender, EventArgs e)
			=> WindowState = FormWindowState.Minimized;

		private void base_PB_Icon_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right)
			{
				var panelForm = (this is BasePanelForm bpf);
				var items = new List<FlatStripItem>()
				{
					new FlatStripItem("Minimize", () => WindowState = FormWindowState.Minimized, Properties.Resources.Tiny_Minimize, MinimizeBox),

					new FlatStripItem(WindowState == FormWindowState.Maximized ? "Restore" : "Maximize",
						() =>
						{
							this.SuspendDrawing();
							WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
							this.ResumeDrawing();
						},
						WindowState == FormWindowState.Maximized ? Properties.Resources.Tiny_Restore : Properties.Resources.Tiny_Maximize,
						MaximizeBox),

					new FlatStripItem("Close", Close, Properties.Resources.Tiny_Close),

					new FlatStripItem("", show: (!panelForm || !((this as BasePanelForm).CurrentPanel is PC_ThemeChanger))),

					new FlatStripItem("Theme Changer", () =>
					{
						if (panelForm)
							(this as BasePanelForm).PushPanel<PC_ThemeChanger>(PanelItem.Empty);
						else
							Theme_Changer.ThemeForm = Theme_Changer.ThemeForm.ShowUp(true);
					}, image: Properties.Resources.Tiny_Paint, show: (!panelForm || !((this as BasePanelForm).CurrentPanel is PC_ThemeChanger))),

					new FlatStripItem("Switch To:", fade: true, image: Properties.Resources.Tiny_Switch, show: (!panelForm || !((this as BasePanelForm).CurrentPanel is PC_ThemeChanger)))
				};

				if ((!panelForm || !((this as BasePanelForm).CurrentPanel is PC_ThemeChanger)))
					foreach (var item in FormDesign.List)
					{
						items.Add(new FlatStripItem(item.Name, () =>
						{
							Cursor = Cursors.WaitCursor;
							FormDesign.Switch(item);
							Cursor = Cursors.Default;
						}, item.If(FormDesign.Design, Properties.Resources.ArrowRight, null), tab: 1));
					}

				new FlatToolStrip(items, this).ShowUp();
			}
			else
			{
				Cursor = Cursors.WaitCursor;
				FormDesign.Switch();
				Cursor = Cursors.Default;
			}
		}

		private void BaseForm_Resize(object sender, EventArgs e)
		{
			if ((WindowState != FormWindowState.Maximized) == (Padding.Left == 0))
			{
				Padding = WindowState == FormWindowState.Maximized ? new Padding(0) : new Padding(7, 7, 10, 10);
				base_P_Container.Padding = WindowState == FormWindowState.Maximized ? new Padding(0) : new Padding(1);
			}
		}

		#endregion Private Methods

		#region FormActive

		public bool FormIsActive = true;
		private FormState currentFormState = FormState.NormalFocused;

		public FormState CurrentFormState
		{
			get => currentFormState;
			set
			{
				currentFormState = value;
				this.TryInvoke(() => base_P_Container.BackColor = value.Color());
			}
		}

		private void Form_Activated(object sender, EventArgs e)
		{
			if (CurrentFormState.IsNormal())
				CurrentFormState = FormState.NormalFocused;
			FormIsActive = true;
		}

		private void Form_Deactivate(object sender, EventArgs e)
		{
			if (CurrentFormState.IsNormal())
				CurrentFormState = FormState.NormalUnfocused;
			FormIsActive = false;
		}

		#endregion FormActive

		#region Move/Resize

		public const int HT_CAPTION = 0x2;
		public const int WM_NCLBUTTONDOWN = 0xA1;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= 0x20000; // <--- use 0x20000
				return cp;
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		protected void Form_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
				if (e.Clicks == 2)
				{
					this.SuspendDrawing();
					WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
					Padding = new Padding(WindowState == FormWindowState.Maximized ? 0 : 2);
					this.ResumeDrawing();
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			const int RESIZE_HANDLE_SIZE = 10;

			OnWndProc?.Invoke(m);

			switch (m.Msg)
			{
				case 0x0084/*NCHITTEST*/ :
					base.WndProc(ref m);

					if ((int)m.Result == 0x01/*HTCLIENT*/)
					{
						Point screenPoint = new Point(m.LParam.ToInt32());
						Point clientPoint = this.PointToClient(screenPoint);
						if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
							else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
								m.Result = (IntPtr)12/*HTTOP*/ ;
							else
								m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
						}
						else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)10/*HTLEFT*/ ;
							else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
								m.Result = (IntPtr)2/*HTCAPTION*/ ;
							else
								m.Result = (IntPtr)11/*HTRIGHT*/ ;
						}
						else
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
							else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
								m.Result = (IntPtr)15/*HTBOTTOM*/ ;
							else
								m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
						}
					}
					return;
			}
			try { base.WndProc(ref m); } catch { }
		}

		#endregion Move/Resize
	}
}