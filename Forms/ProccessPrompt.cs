using System;
using System.Drawing;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Forms
{
	public partial class ProccessPrompt : Form
	{
		#region Public Events

		public event Action<FormClosingEventArgs> ActionCanceled;

		#endregion Public Events

		#region Public Fields

		public const int HT_CAPTION = 0x2;
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public bool FormIsActive = true;

		#endregion Public Fields

		#region Private Fields

		private FormState currentFormState = FormState.NormalFocused;

		#endregion Private Fields

		#region Public Properties

		public bool CancelClicked { get; private set; } = false;

		public FormState CurrentFormState
		{
			get => currentFormState;
			set
			{
				currentFormState = value;
				if (InvokeRequired)
					Invoke(new Action(() => { base_P_Container.BackColor = value.Color(); }));
				else
					base_P_Container.BackColor = value.Color();
			}
		}

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

		#region Private Constructors

		private ProccessPrompt(string msg, bool showCancel)
		{
			InitializeComponent();

			var h = (int)CreateGraphics().MeasureString(msg, L_Text.Font, 290).Height + Padding.Vertical;

			Height = Math.Max(80, h) + 120;

			Text = "Working..";
			L_Text.Text = msg;

			if (!showCancel)
				TLP_Main.RowStyles[1].Height = TLP_Main.RowStyles[2].Height = 0;

			B_Cancel.Visible = showCancel;
			DesignChanged(FormDesign.Design);
		}

		#endregion Private Constructors

		#region Public Methods

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		public static ProccessPrompt Create(
							  string message
			, bool showCancel = false)
		{
			return new ProccessPrompt(message, showCancel);
		}

		public void Show(SlickForm form = null)
		{
			if (form != null)
			{
				form.CurrentFormState = FormState.ForcedFocused;
				Location = form.Bounds.Center(Size);
			}
			else
				StartPosition = FormStartPosition.CenterScreen;

			try
			{
				ShowDialog();
			}
			finally
			{
				if (form != null)
					form.CurrentFormState = FormState.NormalFocused;
			}
		}

		public new void Close()
		{
			this.TryInvoke(base.Close);
		}

		public void SetText(string text)
		{
			this.TryInvoke(() => L_Text.Text = text);
		}

		#endregion Public Methods

		#region Protected Methods

		protected void DesignChanged(FormDesign design)
		{
			base_P_Content.BackColor = design.BackColor;
			ForeColor = design.ForeColor;
			base_P_Container.BackColor = design.ActiveColor;

			P_Spacer_1.BackColor = design.AccentColor;
			PB_Icon.Image = FormDesign.Loader;
		}

		protected void Form_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape && B_Cancel.Visible)
			{
				B_Cancel_Click(this, new EventArgs());

				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void WndProc(ref Message m)
		{
			const int RESIZE_HANDLE_SIZE = 10;

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

		#endregion Protected Methods

		#region Private Methods

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			var ea = new FormClosingEventArgs(CloseReason.UserClosing, false);
			ActionCanceled?.Invoke(ea);
			if (!ea.Cancel)
			{
				Close();
				CancelClicked = true;
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

		#endregion Private Methods
	}
}