using System;
using System.ComponentModel;
using System.Windows.Forms;
using SlickControls.Forms;
using System.Threading;
using SlickControls.Controls;
using Extensions;
using System.Drawing;
using SlickControls.Enums;

namespace SlickControls.Panels
{
	public partial class PanelContent : SlickControl
	{
		private BasePanelForm form;
		private Thread LoadThread;
		private bool shouldLoad;

		public PanelContent() : this(false)
		{ }

		public PanelContent(bool load)
		{
			InitializeComponent();
			TabStop = false;
			DoubleBuffered = true;

			if (!DesignMode)
				DataLoaded = !(shouldLoad = load);

			LoadingTimer.Elapsed += LoadingTimer_Elapsed;
		}

		[Category("Design")]
		public SlickButton AcceptButton { get; set; }

		[Category("Design")]
		public SlickButton CancelButton { get; set; }

		[Browsable(false)]
		public bool DataLoaded { get; private set; }

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BasePanelForm Form { get => form ?? (form = (BasePanelForm)FindForm()); set => form = value; }

		[Browsable(false)]
		public bool Loading { get; private set; }

		[Category("Behavior"), DefaultValue(true)]
		public bool ApplyMouseDown { get; set; } = true;

		[Category("Design")]
		protected Control FocusedControl { get; set; }

		[Category("Design"), DisplayName("Label Bounds")]
		public Point LabelBounds { get => base_Text.Location; set => base_Text.Location = value; }

		public static PanelContent GetParentPanel(Control ctrl)
		{
			while (ctrl != null && !(ctrl is PanelContent))
				ctrl = ctrl.Parent;

			return (PanelContent)ctrl;
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public override string Text { get => base.Text; set => base_Text.Text = base.Text = value; }

		[Browsable(false)]
		internal bool PanelWasSetUp { get; set; } = false;

		[Browsable(false)]
		public PanelItem PanelItem { get; internal set; }

		[Category("Behavior"), DefaultValue(false)]
		public bool ShowBack { get; set; } = false;

		public virtual bool CanExit()
		{
			return true;
		}

		public virtual bool KeyPressed(ref Message msg, Keys keyData)
			=> false;

		public virtual bool KeyPressed(char keyChar)
			=> false;

		protected void AbortLoad()
		{
			if (Loading)
			{
				if (!IsDisposed)
					StopLoader();

				this.TryInvoke(OnLoadFail);
				LoadThread?.Interrupt();
				LoadThread?.Abort();
				Loading = false;
			}
		}

		protected override void DesignChanged(FormDesign design)
		{
			base.DesignChanged(design);

			BackColor = design.BackColor;
			ForeColor = design.ForeColor;
		}

		protected virtual bool LoadData()
		{
			return DataLoaded = true;
		}

		protected DialogResult ShowPrompt(string message, string title = "Prompt", PromptButtons buttons = PromptButtons.OK, PromptIcons icon = PromptIcons.None)
			=> MessagePrompt.Show(message, title, buttons, icon, Form);

		protected override void OnCreateControl()
		{
			if (!IsDisposed && !DesignMode)
			{
				if (Form != null)
					Form = (BasePanelForm)FindForm();

				if (Form != null && !DataLoaded)				
					StartDataLoad();
			}

			base_Text.BringToFront();

			if (ShowBack)
			{
				base_Text.Image = Properties.Resources.Icon_ArrowLeft;
				base_Text.Enabled = true;
				SlickTip.SetTo(base_Text, "Go Back");
			}

			base.OnCreateControl();
		}

		protected virtual void OnDataLoad()
		{ }

		protected virtual void OnLoadFail()
		{ }

		protected void StartDataLoad()
		{
			if (!DesignMode && !Loading)
			{
				DataLoaded = false;
				Loading = true;
				StartLoader();
				LoadThread = new Thread(() =>
				{
					try
					{
						if (LoadData())
						{
							this.TryInvoke(OnDataLoad);
							DataLoaded = true;
						}
						else
							this.TryInvoke(OnLoadFail);
					}
					catch (ThreadAbortException) { }
					catch (ThreadInterruptedException) { }

					if (!IsDisposed)
						StopLoader();

					Loading = false;
					LoadThread = null;
				})
				{ IsBackground = true };

				LoadThread.Start();
			}
		}

		private void PanelContent_Load(object sender, EventArgs e)
		{
			if (FocusedControl != null)
				BeginInvoke(new Action(() => FocusedControl.Focus()));
		}

		private void base_B_Close_Click(object sender, EventArgs e)
		{
			if (Form.CloseForm)
				Form.Close();
			else
				Form.Hide();
		}

		private void base_B_Max_Click(object sender, EventArgs e)
		{
			Form.SuspendDrawing();
			Form.WindowState = Form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
			Form.Padding = new Padding(Form.WindowState == FormWindowState.Maximized ? 0 : 2);
			Form.ResumeDrawing();
		}

		private void base_B_Min_Click(object sender, EventArgs e)
		{
			Form.WindowState = FormWindowState.Minimized;
		}


		#region Loader

		private System.Timers.Timer LoadingTimer = new System.Timers.Timer(30);

		private double perc = -100;

		public void StartLoader()
		{
			LoadingTimer.Start();
			perc = -20;
		}

		public void StopLoader()
		{
			LoadingTimer.Stop();
			perc = -100;

			this.TryInvoke(() => Invalidate(new Rectangle(0, 0, Width, 2)));
		}

		private void LoadingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				perc += 3;
				if (perc >= 100)
					perc = -20;

				this.TryInvoke(() => Invalidate(new Rectangle(0, 0, Width, 2)));
			}
			catch { }
		}

		private void PanelContent_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, 2);

			if (perc >= -20)
				e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ActiveColor), new RectangleF((float)(perc * Width / 100), 0, (Width * 2 / 10), 2));

			if (perc > 100)
				e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ActiveColor), new RectangleF(0, 0, (float)((Width * 2 / 10) * (perc - 100) / 100), 2));
		}

		#endregion Loader

		private void base_Text_Click(object sender, EventArgs e)
		{
			Form?.PushBack();
		}
	}
}
