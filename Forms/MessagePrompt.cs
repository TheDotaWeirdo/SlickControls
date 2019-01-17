using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;
using SlickControls.Enums;
using SlickControls.Panels;

namespace SlickControls.Forms
{
	public partial class MessagePrompt : Form
	{
		private Func<string, bool> InputValidation;
		private PromptButtons selectedButtons;
		private PromptIcons selectedIcon;

		private MessagePrompt() => InitializeComponent();

		private MessagePrompt(string title, string msg, PromptButtons buttons, PromptIcons icons, bool input)
		{
			InitializeComponent();

			var h = (int)CreateGraphics().MeasureString(msg, L_Text.Font, 290).Height + Padding.Vertical;
			if (input)
			{
				TB_Input.Visible = true;
				h += 50;
			}
			else
				TLP_ImgText.RowStyles[1].Height = 0;

			Height = Math.Max(80, h) + 120;

			Text = title;
			L_Text.Text = msg;
			selectedButtons = buttons;
			selectedIcon = icons;

			SetIcon();
			SetButtons();
			DesignChanged(FormDesign.Design);
		}

		public string OutputText { get; private set; } = string.Empty;

		private void MessagePrompt_Load(object sender, EventArgs e)
		{
			PlaySound();
		}		

		#region Statics

		public static DialogResult Show(
			  string message
			, string title = "Prompt"
			, PromptButtons buttons = PromptButtons.OK
			, PromptIcons icon = PromptIcons.None
			, SlickForm form = null)
		{
			var prompt = new MessagePrompt(title, message, buttons, icon, false);

			if (form != null)
			{
				form.CurrentFormState = FormState.ForcedFocused;
				prompt.Location = form.Bounds.Center(prompt.Size);
			}
			else
				prompt.StartPosition = FormStartPosition.CenterScreen;

			try
			{
				return prompt.ShowDialog();
			}
			finally
			{
				if (form != null)
					form.CurrentFormState = FormState.NormalFocused;
			}
		}

		public static InputResult ShowInput(
			  string message
			, string title = "Input Prompt"
			, string defaultValue = ""
			, PromptButtons buttons = PromptButtons.OKCancel
			, PromptIcons icon = PromptIcons.Input
			, Func<string, bool> inputValidation = null
			, SlickForm form = null)
		{
			var prompt = new MessagePrompt(title, message, buttons, icon, true);
			prompt.TB_Input.Text = defaultValue;
			prompt.InputValidation = inputValidation;

			if (form != null)
			{
				form.CurrentFormState = FormState.ForcedFocused;
				prompt.Location = form.Bounds.Center(prompt.Size);
			}
			else
				prompt.StartPosition = FormStartPosition.CenterScreen;

			try
			{
				return new InputResult(prompt.ShowDialog(), prompt.OutputText);
			}
			finally
			{
				if (form != null)
					form.CurrentFormState = FormState.NormalFocused;
			}
		}

		#endregion Statics

		#region FormActive

		public bool FormIsActive = true;
		private FormState currentFormState = FormState.NormalFocused;

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
			}
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

		#endregion Move/Resize

		#region General Methods

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				switch (selectedButtons)
				{
					case PromptButtons.OK:
						B_OK_Click(this, new EventArgs());
						break;

					case PromptButtons.OKCancel:
						B_OK_Click(this, new EventArgs());
						break;

					case PromptButtons.AbortRetryIgnore:
						B_Abort_Click(this, new EventArgs());
						break;

					case PromptButtons.YesNoCancel:
						B_Yes_Click(this, new EventArgs());
						break;

					case PromptButtons.YesNo:
						B_Yes_Click(this, new EventArgs());
						break;

					case PromptButtons.RetryCancel:
						B_Retry_Click(this, new EventArgs());
						break;

					default:
						break;
				}

				return true;
			}

			if (keyData == Keys.Escape)
			{
				switch (selectedButtons)
				{
					case PromptButtons.OK:
						B_OK_Click(this, new EventArgs());
						break;

					case PromptButtons.OKCancel:
						B_Cancel_Click(this, new EventArgs());
						break;

					case PromptButtons.AbortRetryIgnore:
						B_Ignore_Click(this, new EventArgs());
						break;

					case PromptButtons.YesNoCancel:
						B_Cancel_Click(this, new EventArgs());
						break;

					case PromptButtons.YesNo:
						B_No_Click(this, new EventArgs());
						break;

					case PromptButtons.RetryCancel:
						B_Cancel_Click(this, new EventArgs());
						break;

					default:
						break;
				}

				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected void DesignChanged(FormDesign design)
		{
			base_P_Content.BackColor = design.BackColor;
			ForeColor = design.ForeColor;
			base_P_Container.BackColor = design.ActiveColor;

			P_Spacer_1.BackColor = design.AccentColor;

			B_Abort.ColorShade = design.RedColor;

			switch (selectedIcon)
			{
				case PromptIcons.Hand:
					PB_Icon.Color(design.IconColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Info:
					PB_Icon.Color(design.ActiveColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Input:
					PB_Icon.Color(design.IconColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Question:
					PB_Icon.Color(design.IconColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Warning:
					PB_Icon.Color(design.YellowColor);
					CurrentFormState = FormState.Working;
					break;

				case PromptIcons.Error:
					PB_Icon.Color(design.RedColor);
					CurrentFormState = FormState.Busy;
					break;

				default:
					break;
			}
		}

		private void PlaySound()
		{
			switch (selectedIcon)
			{
				case PromptIcons.Hand:
					SystemSounds.Hand.Play();
					break;

				case PromptIcons.Info:
					SystemSounds.Beep.Play();
					break;

				case PromptIcons.Input:
					SystemSounds.Question.Play();
					break;

				case PromptIcons.Question:
					SystemSounds.Question.Play();
					break;

				case PromptIcons.Warning:
					SystemSounds.Asterisk.Play();
					break;

				case PromptIcons.Error:
					SystemSounds.Exclamation.Play();
					break;

				default:
					break;
			}
		}

		private void SetButtons()
		{
			switch (selectedButtons)
			{
				case PromptButtons.OK:
					B_OK.Visible = true;
					break;

				case PromptButtons.OKCancel:
					B_OK.Visible = B_Cancel.Visible = true;
					break;

				case PromptButtons.AbortRetryIgnore:
					B_Abort.Visible = B_Retry.Visible = B_Ignore.Visible = true;
					break;

				case PromptButtons.YesNoCancel:
					B_Yes.Visible = B_No.Visible = B_Cancel.Visible = true;
					break;

				case PromptButtons.YesNo:
					B_Yes.Visible = B_No.Visible = true;
					break;

				case PromptButtons.RetryCancel:
					B_Retry.Visible = B_Cancel.Visible = true;
					break;

				default:
					B_OK.Visible = true;
					break;
			}
		}

		private void SetIcon()
		{
			var design = FormDesign.Design;
			switch (selectedIcon)
			{
				case PromptIcons.Hand:
					PB_Icon.Image = Properties.Resources.Icon_Hand.Color(design.IconColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Info:
					PB_Icon.Image = Properties.Resources.Icon_Info.Color(design.ActiveColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Input:
					PB_Icon.Image = Properties.Resources.Icon_Change.Color(design.IconColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Question:
					PB_Icon.Image = Properties.Resources.Icon_Question.Color(design.IconColor);
					CurrentFormState = FormState.NormalFocused;
					break;

				case PromptIcons.Warning:
					PB_Icon.Image = Properties.Resources.Icon_Warning.Color(design.YellowColor);
					CurrentFormState = FormState.Working;
					break;

				case PromptIcons.Error:
					PB_Icon.Image = Properties.Resources.Icon_No.Color(design.RedColor);
					CurrentFormState = FormState.Busy;
					break;

				default:
					TLP_ImgText.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 0);
					break;
			}
		}

		#endregion General Methods

		#region Click Events

		private void B_Abort_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void B_Close_Click(object sender, EventArgs e)
		{
			switch (selectedButtons)
			{
				case PromptButtons.OK:
					DialogResult = DialogResult.OK;
					break;

				case PromptButtons.OKCancel:
					DialogResult = DialogResult.Cancel;
					break;

				case PromptButtons.AbortRetryIgnore:
					DialogResult = DialogResult.Ignore;
					break;

				case PromptButtons.YesNoCancel:
					DialogResult = DialogResult.Cancel;
					break;

				case PromptButtons.YesNo:
					DialogResult = DialogResult.No;
					break;

				case PromptButtons.RetryCancel:
					DialogResult = DialogResult.Cancel;
					break;

				default:
					DialogResult = DialogResult.None;
					break;
			}
			Close();
		}

		private void B_Ignore_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Ignore;
			Close();
		}

		private void B_No_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}

		private void B_OK_Click(object sender, EventArgs e)
		{
			if (InputValidation == null || InputValidation(TB_Input.Text))
			{
				OutputText = TB_Input.Text;
				DialogResult = DialogResult.OK;
				Close();
			}
			else
				SystemSounds.Exclamation.Play();
		}

		private void B_Retry_Click(object sender, EventArgs e)
		{
			if (InputValidation == null || InputValidation(TB_Input.Text))
			{
				OutputText = TB_Input.Text;
				DialogResult = DialogResult.Retry;
				Close();
			}
			else
				SystemSounds.Exclamation.Play();
		}

		private void B_Yes_Click(object sender, EventArgs e)
		{
			if (InputValidation == null || InputValidation(TB_Input.Text))
			{
				OutputText = TB_Input.Text;
				DialogResult = DialogResult.Yes;
				Close();
			}
			else
				SystemSounds.Exclamation.Play();
		}

		#endregion Click Events
	}
}