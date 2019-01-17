using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public partial class HorizontalScroll : UserControl
	{
		public Func<Color> MouseDownColor;
		private bool active = false;
		private Func<Color> barColor;
		private bool disabled = false;
		private Control linkedControl;
		private Point MouseDownLocation;
		private double perc = 0;
		private System.Timers.Timer Timer = new System.Timers.Timer(35);
		private int targetY = 0;
		public Func<int> SizeSource = null;

		private int TargetY
		{
			get => targetY;
			set
			{
				targetY = value.Between(0, Width - Bar.Width);
				Timer.Start();
			}
		}

		public HorizontalScroll()
		{
			InitializeComponent();
			Bar.Size = new Size(15, 150);
			Bar.MouseDown += Bar_MouseDown;
			Bar.MouseUp += Bar_MouseUp;
			Bar.MouseMove += Bar_MouseMove;
			Bar.LocationChanged += Bar_LocationChanged;
			MouseWheel += Control_OnMouseWheel;

			Timer.Elapsed += Timer_Elapsed;

			FormDesign.DesignChanged += (d) => Bar.BackColor = BarColor == null ? d.InfoColor : BarColor();
			Bar.BackColor = BarColor == null ? FormDesign.Design.InfoColor : BarColor();
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (Bar.Left == targetY)
				Timer.Stop();
			else
			{
				if (InvokeRequired)
					Invoke(new Action(() =>
					{
						if ((targetY - Bar.Left).Sign() == 1)
							Bar.Left = (Bar.Left + ((int)(Math.Abs(targetY - Bar.Left) / 5)).Between(4, 25)).Between(0, targetY);
						else
							Bar.Left = (Bar.Left - ((int)(Math.Abs(targetY - Bar.Left) / 5)).Between(4, 25)).Between(targetY, Width - Bar.Width);
					}));
				else
				{
					if ((targetY - Bar.Left).Sign() == 1)
						Bar.Left = (Bar.Left + ((int)(Math.Abs(targetY - Bar.Left) / 5)).Between(4, 25)).Between(0, targetY);
					else
						Bar.Left = (Bar.Left - ((int)(Math.Abs(targetY - Bar.Left) / 5)).Between(4, 25)).Between(targetY, Width - Bar.Width);
				}
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
					Visible = value;
			}
		}

		public Func<Color> BarColor
		{
			get => barColor;
			set
			{
				barColor = value;
				Bar.BackColor = value == null ? FormDesign.Design.InfoColor : value();
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
					linkedControl.Parent.MouseWheel += Control_OnMouseWheel;
					linkedControl.Layout += Control_Resize;
					linkedControl.Parent.Layout += Control_Resize;
					Control_Resize(null, null);
				}
			}
		}

		public void SetPerc(double perc)
		{
			if (Active)
				TargetY = (int)(perc.Between(0, 100) * (Width - Bar.Width) / 100);
		}

		private void Bar_LocationChanged(object sender, EventArgs e)
		{
			disabled = true;
			perc = 100 * Bar.Left / Math.Max(Width - Bar.Width, 1);
			if (linkedControl.InvokeRequired)
				linkedControl.Invoke(new Action(() => LinkedControl.Left = (int)(perc * (linkedControl.Parent.Width - (SizeSource == null ? linkedControl.Width : SizeSource())) / 100)));
			else
				LinkedControl.Left = (int)(perc * (linkedControl.Parent.Width - (SizeSource == null ? linkedControl.Width : SizeSource())) / 100);
			disabled = false;
		}

		private void Bar_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MouseDownLocation = e.Location;
				BackColor = BarColor == null ? FormDesign.Design.AccentColor : MouseDownColor();
			}
		}

		private void Bar_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Timer.Stop();
				targetY = Bar.Left = (e.X + Bar.Left - MouseDownLocation.X).Between(0, Width - Bar.Width);
			}
		}

		private void Bar_MouseUp(object sender, MouseEventArgs e) => BackColor = Color.Empty;

		public void SetX(int x) => TargetY = Active ? x : 0;

		private void Control_OnMouseWheel(object sender, MouseEventArgs e)
		{
			if (Active)
			{
				if ((e.Delta > 0 && TargetY < Width - Bar.Width) || (e.Delta < 0 && TargetY > 0))
					(e as HandledMouseEventArgs).Handled = true;

				TargetY = (TargetY - (e.Delta.Sign() * Bar.Width / 2)).Between(0, Width - Bar.Width);
			}
		}

		private void Control_Resize(object sender, EventArgs e)
		{
			if (disabled) return;

			Active = !IsDisposed && (SizeSource == null ? linkedControl.Width : SizeSource()) > linkedControl.Parent.Width;
			if (Active)
			{
				Bar.Width = Width * linkedControl.Parent.Width / (SizeSource == null ? linkedControl.Width : SizeSource());
				var p = (linkedControl.Location.Y / (double)linkedControl.Parent.Width);
				TargetY = (int)(p * (Width - Bar.Width)).Between(0, Width - 1);
			}
		}

		private void HorizontalScroll_Resize(object sender, EventArgs e)
		{
			Bar.Height = Height;
		}

		public void ReEvaluate() => Control_Resize(null, null);
	}
}
