using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public partial class VerticalScroll : UserControl
	{
		private bool active = false;
		private Func<Color> barColor;
		private bool disabled = false;
		private Control linkedControl;
		private Point MouseDownLocation;
		private double perc = 0;
		private double targetPerc = 0;
		private System.Timers.Timer Timer = new System.Timers.Timer(35);
		private System.Timers.Timer DismissTimer = new System.Timers.Timer(3000) { AutoReset = false };

		[Category("Behavior"), DefaultValue(true)]
		public bool AutoResize { get; set; } = true;

		public Func<int> SizeSource = null;

		private double Perc
		{
			get => perc;
			set
			{
				try
				{
					perc = value.Between(0, 100);
					if (InvokeRequired)
						Invoke(new Action(() =>
						{
							Bar.Top = (int)(perc * (Height - Bar.Height) / 100);
							LinkedControl.Top = (int)(Perc * (linkedControl.Parent.Height - (SizeSource == null ? linkedControl.Height : SizeSource())) / 100);
						}));
					else
					{
						Bar.Top = (int)(perc * (Height - Bar.Height) / 100);
						LinkedControl.Top = (int)(Perc * (linkedControl.Parent.Height - (SizeSource == null ? linkedControl.Height : SizeSource())) / 100);
					}
				}
				catch { }
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			Margin = new Padding(0, 0, 1, 0);
		}

		private double TargetPerc
		{
			get => targetPerc;
			set
			{
				targetPerc = value.Between(0, 100);
				Timer.Start();
			}
		}

		private int TargetY => (int)(TargetPerc * (Height - Bar.Height));

		public VerticalScroll()
		{
			InitializeComponent();
			Dock = DockStyle.Right;
			Bar.Size = new Size(150, 15);
			Bar.MouseDown += Bar_MouseDown;
			Bar.MouseUp += Bar_MouseUp;
			Bar.MouseMove += Bar_MouseMove;
			Bar.LocationChanged += Bar_LocationChanged;
			MouseWheel += Control_OnMouseWheel;
			Bar.Paint += RoundedPanel_Paint;
			Bar.Resize += (s, e) => Bar.Refresh();

			if (!DesignMode)
			{
				Timer.Elapsed += Timer_Elapsed;
				DismissTimer.Elapsed += DismissTimer_Elapsed;
			}

			var md = new MouseDetector();
			if (!DesignMode)
				md.MouseMove += Md_MouseMove;
			Disposed += (s, e) => md.MouseMove -= Md_MouseMove;

			BackColorChanged += (s, e) => Bar.Refresh();
		}

		private void RoundedPanel_Paint(object sender, PaintEventArgs e)
		{
			var brush = new SolidBrush(BarColor == null ? FormDesign.Design.InfoColor : BarColor());
			var border = Bar.Width;

			e.Graphics.Clear(Parent?.BackColor ?? FormDesign.Design.BackColor);
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			e.Graphics.FillPie(brush, new Rectangle(0, 0, border, border), 180, 180);
			e.Graphics.FillPie(brush, new Rectangle(0, Bar.Height - border, border, border), 0, 180);

			e.Graphics.FillRectangle(brush, new Rectangle(0, border / 2 - 1, Bar.Width, Bar.Height - border + 2));
		}

		private AnimationHandler AH;

		private void Md_MouseMove(object sender, Point p)
		{
			try
			{
				if (AutoResize)
				{
					var pt = PointToScreen(new Point(-p.X, -p.Y));
					if (Width != 12 && (pt.X.IsWithin(-7, 7 + Width) && pt.Y.IsWithin(-7 - Height, 7)))
					{
						AH?.Dispose();
						AH = new AnimationHandler(this, new Size(12, Height))
						{
							IgnoreHeight = true
						};
						AH.StartAnimation();
						DismissTimer.Stop();
						DismissTimer.Start();
					}
				}
			}
			catch { }
		}

		private void DismissTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (AutoResize)
			{
				AH?.Dispose();
				AH = new AnimationHandler(this, new Size(4, Height))
				{
					IgnoreHeight = true
				};
				AH.StartAnimation();
			}
		}

		private double acceleration = 0;
		private double speed = 0;
		private double maxSpeed = 0;

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			double maxVelocity = (3D * 1000 / (SizeSource == null ? linkedControl.Height : SizeSource())).Between(1, 7);
			if (TargetPerc == Perc)
			{
				Timer.Stop();
				acceleration = speed = maxSpeed = 0;
			}
			else
			{
				if (maxSpeed > 0)
					speed = (speed + (acceleration / 28.57142857142857)).Between(speed, maxSpeed * maxVelocity);
				else
					speed = (speed + (acceleration / 28.57142857142857)).Between(maxSpeed * maxVelocity, speed);

				if (TargetPerc - Perc > 0)
					Perc = (Perc + speed).Between(0, TargetPerc);
				else
					Perc = (Perc + speed).Between(TargetPerc, 100);
			}
		}

		public bool Active
		{
			get => active;
			private set
			{
				active = value;
				if (InvokeRequired)
					Invoke(new Action(() => Visible = value));
				else
				{
					Visible = value;
					if (!AutoResize)
						BringToFront();
				}
			}
		}

		public Func<Color> BarColor
		{
			get => barColor;
			set
			{
				barColor = value;
				Bar.Refresh();
			}
		}

		public Control LinkedControl
		{
			get => linkedControl;
			set
			{
				linkedControl = value;
				if (value != null)
				{
					linkedControl.MouseWheel += Control_OnMouseWheel;
					linkedControl.Layout += Control_Resize;
					linkedControl.Resize += LinkedControl_Resize;
					linkedControl.ParentChanged += (s, e) =>
					{
						if (linkedControl.Parent != null)
						{
							linkedControl.Parent.MouseWheel += Control_OnMouseWheel;
							linkedControl.Parent.Layout += Control_Resize;
							linkedControl.Parent.Resize += LinkedControl_Resize;
						}
					};
					if (linkedControl.Parent != null)
					{
						linkedControl.Parent.MouseWheel += Control_OnMouseWheel;
						linkedControl.Parent.Layout += Control_Resize;
						linkedControl.Parent.Resize += LinkedControl_Resize;
					}
					Control_Resize(null, null);
					LinkedControl_Resize(null, null);
				}
			}
		}

		private void LinkedControl_Resize(object sender, EventArgs e)
		{
			if (disabled || linkedControl.Parent == null) return;

			var p = 100D * -Math.Max(linkedControl.Top, linkedControl.Parent.Height - (SizeSource == null ? linkedControl.Height : SizeSource())) / Math.Max(1, (SizeSource == null ? linkedControl.Height : SizeSource()));
			Bar.Top = (int)(p.Between(0, 100) * Height / 100);
			perc = targetPerc = 100D * Bar.Top / (Height - Bar.Height);
		}

		public void SetPerc(double perc)
		{
			if (Active)
				TargetPerc = perc;
		}

		public void Reset()
		{
			if (!DesignMode)
			{
				perc = 0;
				targetPerc = 0;
				Bar.Top = 0;
				LinkedControl.Top = 0;
				Control_Resize(null, null);
			}
		}

		private bool moveOnBar = false;

		private void Bar_LocationChanged(object sender, EventArgs e)
		{
			if (moveOnBar)
			{
				disabled = true;
				if (linkedControl.InvokeRequired)
					linkedControl.Invoke(new Action(() => LinkedControl.Top = (int)(Perc * (linkedControl.Parent.Height - (SizeSource == null ? linkedControl.Height : SizeSource())) / 100)));
				else
					LinkedControl.Top = (int)(Perc * (linkedControl.Parent.Height - (SizeSource == null ? linkedControl.Height : SizeSource())) / 100);
				disabled = false;
			}

			DismissTimer.Start();
		}

		private void Bar_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MouseDownLocation = e.Location;
			}
		}

		private void Bar_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Timer.Stop();
				moveOnBar = true;
				perc = targetPerc = 100D * (Bar.Top = (e.Y + Bar.Top - MouseDownLocation.Y).Between(0, Height - Bar.Height)) / (Height - Bar.Height);
				moveOnBar = false;
			}
		}

		private void Bar_MouseUp(object sender, MouseEventArgs e) => BackColor = Color.Empty;

		private void Control_OnMouseWheel(object sender, MouseEventArgs e)
		{
			if (Active)
			{
				if ((e.Delta < 0 && TargetPerc < 100) || (e.Delta > 0 && TargetPerc > 0))
					(e as HandledMouseEventArgs).Handled = true;

				if (maxSpeed.Sign() == e.Delta.Sign())
				{
					acceleration = maxSpeed = speed = 0;
					targetPerc = perc;
				}

				var h = (SizeSource == null ? linkedControl.Height : SizeSource()).If(0, 1);
				var hMod = (1 + ((((double)h / linkedControl.Parent.Height) - 1) / 15)).Between(1, 2.5);
				var hDiff = (225 / hMod);
				TargetPerc -= e.Delta.Sign() * (h / Math.Floor(h / hDiff) * 100 / h).Between(0, 100);

				var accStep = (20000D / (SizeSource == null ? linkedControl.Height : SizeSource()).If(0, 1))/*.Between(2, 60) * 0.7D*/;
				var dist = (h * Math.Abs(TargetPerc - perc) / 100) - linkedControl.Parent.Height;
				acceleration = acceleration == 0 ? -e.Delta.Sign() * accStep : acceleration * 1.5;
				maxSpeed = maxSpeed == 0 ? -e.Delta.Sign() * (1.45 * hDiff / dist.If(x => x <= 0, hDiff)) : maxSpeed * 1.5;
			}
		}

		private void Control_Resize(object sender, EventArgs e)
		{
			if (disabled || linkedControl.Parent == null) return;

			Active = (SizeSource == null ? linkedControl.Height : SizeSource()) > linkedControl.Parent.Height;
			if (Active)
			{
				Bar.Height = Height * linkedControl.Parent.Height / (SizeSource == null ? linkedControl.Height : SizeSource());
				Bar.Top = Math.Min(Bar.Top, Height - Bar.Height);
				//var p = (linkedControl.Location.Y / (double)linkedControl.Parent.Height);
				//TargetY = (int)(p * (Height - Bar.Height)).Between(0, Height - 1);
			}
			else
			{
				TargetPerc = Perc = 0;
				Bar.Top = 0;
				Timer.Stop();
			}
		}

		private void HorizontalScroll_Resize(object sender, EventArgs e)
		{
			Bar.Width = Width - 2;
		}

		private void VerticalScroll_Load(object sender, EventArgs e)
		{
			if (AutoResize)
			{
				DismissTimer.Start();
				Reset();
			}
			else
				Width = 4;
		}
	}
}