using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public class RoundedBack : PictureBox
	{
		private Color backColor;
		private int border = 0;

		public new Color BackColor { get => backColor; set { backColor = value; Refresh(); } }

		[Category("Appearance")]
		public int Border { get => border; set { border = value; Refresh(); } }

		public RoundedBack()
		{
			Paint += RoundedPanel_Paint;
			Resize += (s, e) => Refresh();
			DoubleBuffered = true;
		}

		private void RoundedPanel_Paint(object sender, PaintEventArgs e)
		{
			var brush = new SolidBrush(backColor);
			var border = (Border == 0 ? (Math.Min(Height, Width) / 3).Between(10, 20) : Border) * 2;

			e.Graphics.Clear(Parent?.BackColor ?? FormDesign.Design.BackColor);
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			e.Graphics.FillPie(brush, new Rectangle(0, 0, border, border), 180, 90);
			e.Graphics.FillPie(brush, new Rectangle(Width - border, 0, border, border), 270, 90);
			e.Graphics.FillPie(brush, new Rectangle(Width - border, Height - border, border, border), 0, 90);
			e.Graphics.FillPie(brush, new Rectangle(0, Height - border, border, border), 90, 90);

			e.Graphics.FillRectangles(brush, new Rectangle[]
				{
					new Rectangle(border / 2 - 1, 0, Width - border + 2, Height),
					new Rectangle(0, border / 2 - 1, Width, Height - border + 2)
				});
		}
	}
}
