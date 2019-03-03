using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Extensions;
using Timer = System.Timers.Timer;

namespace SlickControls.Controls
{
	public enum StyleType { Vertical, Horizontal }

	public partial class SlickScroll : UserControl
	{
		#region Private Fields

		private const int BAR_SIZE_MAX = 12;
		private const int BAR_SIZE_MIN = 5;
		private AnimationHandler animationHandler;
		private Timer DismissTimer = new Timer(1000) { AutoReset = false };
		private Control linkedControl;
		private bool mouseDown;
		private bool opening;
		private Point mouseDownLocation;
		private bool mouseIn;
		private Timer ScrollTimer = new Timer(28);
		private double speedModifier;
		private double targetPercentage;

		#endregion Private Fields

		#region Public Properties

		[Category("Behavior"), DefaultValue(true)]
		public bool ShowHandle { get; set; } = true;

		[Category("Data")]
		public Control LinkedControl
		{
			get => linkedControl;
			set
			{
				linkedControl = value;

				if (!DesignMode && value != null)
				{
					linkedControl.MouseWheel += SlickScroll_OnMouseWheel;
					linkedControl.Resize += LinkedControl_Resize;
					linkedControl.ParentChanged += (s, e) => SetParentEvents();
					SetParentEvents();
					LinkedControl_Resize(null, null);
				}
			}
		}

		[Browsable(false)]
		public double Percentage { get; private set; }

		[Browsable(false)]
		public Func<int> SizeSource { get; set; }

		[Category("Behavior")]
		public StyleType Style { get; set; }

		[Browsable(false)]
		public double TargetPercentage
		{
			get => targetPercentage;
			private set
			{
				targetPercentage = value.Between(0, 100);

				if (Percentage != targetPercentage)
				{
					speedModifier = speedModifier.If(0, 10, speedModifier / 1.05);
					ScrollTimer.Start();
				}
			}
		}

		#endregion Public Properties

		#region Private Properties

		private int ControlSize => SizeSource?.Invoke() ?? linkedControl?.Height ?? 0;
		private bool Open => Width != BAR_SIZE_MIN;

		[Browsable(false)]
		public bool Active => linkedControl != null && ControlSize != 0 && ControlSize > linkedControl.Parent.Height;

		#endregion Private Properties

		#region Public Constructors

		public SlickScroll()
		{
			InitializeComponent();
			ResizeRedraw = DoubleBuffered = true;

			MouseWheel += SlickScroll_OnMouseWheel;
			DismissTimer.Elapsed += DismissTimer_Elapsed;
			ScrollTimer.Elapsed += ScrollTimer_Elapsed;
		}

		#endregion Public Constructors

		#region Public Methods

		public void Reset()
		{
			SetPercentage(0, true);
			LinkedControl_Resize(null, null);
		}

		public void SetPercentage(double perc, bool target = false)
		{
			Percentage = perc.Between(0, 100);

			if (target)
			{
				ScrollTimer.Stop();
				speedModifier = 0;
				targetPercentage = Percentage;
			}

			Bar.Top = (int)(Percentage * (Height - (Bar.Height)) / 100);
			LinkedControl.Top = (int)(Percentage * (linkedControl.Parent.Height - ControlSize) / 100);
			Invalidate();
		}

		#endregion Public Methods

		#region Protected Methods

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			if (Style == StyleType.Vertical)
				Width = BAR_SIZE_MIN;
			else
				Height = BAR_SIZE_MIN;
		}

		#endregion Protected Methods

		#region Private Methods

		private void DismissTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (!mouseDown && !mouseIn)
			{
				animationHandler?.Dispose();
				animationHandler = new AnimationHandler(this, new Size(BAR_SIZE_MIN, 0))
				{
					IgnoreHeight = true,
					Interval = 28
				};
				animationHandler.StartAnimation();
			}
		}

		private void LinkedControl_Resize(object sender, EventArgs e)
		{
			if (linkedControl?.Parent == null)
				return;

			if(Active)
			Bar.Height = Height * linkedControl.Parent.Height / ControlSize.If(0, 1);
			Visible = Active;
			SetPercentage(Active ? Percentage : 0, true);
		}

		private void ScrollTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (Active)
			{
				var size = ControlSize - linkedControl.Parent.Height;
				var incPerc = (TargetPercentage - Percentage) > 0;
				var minStep = 1000D / size * speedModifier;
				var maxStep = Math.Max(minStep, ControlSize / (75D / speedModifier));
				var perc = (((TargetPercentage - Percentage)).Between(incPerc.If(minStep, -maxStep), incPerc.If(maxStep, -minStep)) / speedModifier);

				this.TryInvoke(() => SetPercentage((Percentage + perc).Between(incPerc ? 0 : TargetPercentage, incPerc ? TargetPercentage : 100)));

				if (Percentage == TargetPercentage)
				{
					ScrollTimer.Stop();
					speedModifier = 0;
				}
			}
			else
			{
				ScrollTimer.Stop();
				speedModifier = 0;
			}
		}

		private void SetParentEvents()
		{
			if (linkedControl.Parent != null)
			{
				linkedControl.Parent.MouseWheel += SlickScroll_OnMouseWheel;
				linkedControl.Parent.Resize += LinkedControl_Resize;
			}
		}

		private void SlickScroll_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mouseDown = true;
				mouseDownLocation = e.Location;
				SetPercentage(100D * (e.Y.Between(Bar.Height / 2, Height - (Bar.Height / 2)) - (Bar.Height / 2)) / (Height - Bar.Height), true);
				Invalidate();
			}
		}

		private void SlickScroll_MouseEnter(object sender, EventArgs e)
		{
			if (!mouseIn && !opening && ShowHandle)
			{
				mouseIn = opening = true;
				animationHandler?.Dispose();
				animationHandler = new AnimationHandler(this, new Size(BAR_SIZE_MAX, 0))
				{
					IgnoreHeight = true,
					Interval = 28
				};
				animationHandler.StartAnimation(() => opening = false);
				DismissTimer.Stop();
			}
		}

		private void SlickScroll_MouseLeave(object sender, EventArgs e)
		{
			mouseIn = false;
			DismissTimer.Start();
		}

		private void SlickScroll_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				SetPercentage(100D * (e.Y.Between(Bar.Height / 2, Height - (Bar.Height / 2)) - (Bar.Height / 2)) / (Height - Bar.Height), true);
		}

		private void SlickScroll_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
			Invalidate();
			DismissTimer.Start();
		}

		private void SlickScroll_OnMouseWheel(object sender, MouseEventArgs e)
		{
			if (Active && !mouseDown)
			{
				TargetPercentage -= e.Delta * 100D / (ControlSize - linkedControl.Parent.Height);
				(e as dynamic).Handled = true;
			}
		}

		private void SlickScroll_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(BackColor);
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			if (Open)
			{
				if (mouseDown)
					e.Graphics.DrawLine(new Pen(FormDesign.Design.AccentColor, 1), (Width - 1) / 2, 1, (Width - 1) / 2, Height - 1);

				e.Graphics.FillRoundedRectangle(new SolidBrush(mouseDown ? FormDesign.Design.ActiveColor : FormDesign.Design.AccentColor), new Rectangle(0, Bar.Top, Bar.Width, Bar.Height), Bar.Width / 2);
			}
			else
			{
				e.Graphics.DrawLine(new Pen(FormDesign.Design.AccentColor, Bar.Width), 0, Bar.Top, 0, Bar.Top + Bar.Height);
			}
		}

		private void SlickScroll_Resize(object sender, EventArgs e)
		{
			Bar.Width = Width - 3;
		}

		#endregion Private Methods
	}
}