using System.Drawing;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public partial class TopIcon : PictureBox
	{
		public enum IconStyle { Minimize, Maximize, Close }

		public IconStyle Color { get; set; }

		public TopIcon()
		{
			InitializeComponent();
			MouseEnter += (s, e) => Invalidate();
			MouseLeave += (s, e) => Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			e.Graphics.FillEllipse(new SolidBrush(new RectangleF(0, 0, Width, Height).Contains(PointToClient(MousePosition)) ? GetColor() : BackColor.MergeColor(GetColor(), 90)), new RectangleF(0, 0, Width - 1, Height - 1));
			e.Graphics.DrawEllipse(new Pen(GetColor(), 1), new RectangleF(0, 0, Width - 1, Height - 1));
		}

		private Color GetColor()
		{
			switch (Color)
			{
				case IconStyle.Minimize:
					return FormDesign.Design.GreenColor;
				case IconStyle.Maximize:
					return FormDesign.Design.YellowColor;
				case IconStyle.Close:
					return FormDesign.Design.RedColor;
				default:
					return FormDesign.Design.IconColor;
			}
		}
	}
}
