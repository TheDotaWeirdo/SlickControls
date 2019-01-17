using Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SlickControls.Controls
{
	[DefaultEvent("PercentageChanged")]
	public partial class SlickProgressBar : UserControl
	{
		private double minStep = .5;
		private double perc = 0;
		private double targetPerc = 0;
		private System.Timers.Timer timer = new System.Timers.Timer(35);

		public SlickProgressBar()
		{
			InitializeComponent();
			ResizeRedraw = true;
			DoubleBuffered = true;
			TabStop = false;
			timer.Elapsed += Timer_Elapsed;

			FormDesign.DesignChanged += d => Refresh();
		}

		public event EventHandler PercentageChanged;

		[Category("Behavior"), DefaultValue(0.5)]
		public double MinStep { get => minStep; set => minStep = value; }

		[Category("Behavior"), DefaultValue(0)]
		public double Percentage
		{
			get => targetPerc;
			set
			{
				targetPerc = Math.Min(100, value);
				timer.Start();
				PercentageChanged?.Invoke(this, new EventArgs());
			}
		}

		private int GetWidth => (int)( ( perc * Width / 100 ) - Padding.Horizontal );

		private void SlickProgressBar_Paint(object sender, PaintEventArgs e)
		{
			var barWidth = (int)( ( Width - Padding.Horizontal ) * perc / 100 ).Between(14, Width - Padding.Horizontal);

			e.Graphics.Clear(BackColor);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.FillRoundedRectangle(new SolidBrush(FormDesign.Design.MenuColor), new Rectangle(new Point(Padding.Left, Padding.Top), new Size(Width - Padding.Horizontal, Height - Padding.Vertical)), 7);
			e.Graphics.FillRoundedRectangle(new SolidBrush(perc == 100 ? FormDesign.Design.GreenColor : FormDesign.Design.ActiveColor), new Rectangle(new Point(Padding.Left, Padding.Top), new Size(barWidth, Height - Padding.Vertical)), 7);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			var txt = $"{Math.Floor(perc)} %";
			var bnds = e.Graphics.MeasureString(txt, Font);

			if (barWidth < bnds.Width + 10)
				e.Graphics.DrawString(txt, Font, new SolidBrush(FormDesign.Design.ForeColor), new PointF(barWidth + 5, ( Height - Padding.Vertical - bnds.Height ) / 2));
			else
				e.Graphics.DrawString(txt, Font, new SolidBrush(FormDesign.Design.ActiveForeColor), new PointF(barWidth - bnds.Width - 5, ( Height - Padding.Vertical - bnds.Height ) / 2));
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (targetPerc != perc)
			{
				if (targetPerc - perc > 0)
					perc = Math.Min(targetPerc, perc + Math.Max(minStep, ( targetPerc - perc ) / 8d));
				else
					perc = Math.Max(targetPerc, perc - Math.Max(minStep, ( perc - targetPerc ) / 8d));

				if (( perc == 100 && targetPerc == 100 ) || ( perc == 0 && targetPerc == 0 ))
					timer.Stop();

				this.TryInvoke(Refresh);
			}
		}
	}
}