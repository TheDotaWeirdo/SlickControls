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
	public class HorizontalBar : PictureBox
	{
		private Color backColor;
		private int border = 0;

		public new Color BackColor { get => backColor; set { backColor = value; Invalidate(); } }
		public int Border { get => border; set { border = value; Invalidate(); } }

		public HorizontalBar()
		{
			Paint += RoundedPanel_Paint;
			Resize += (s, e) => Refresh();
		}

		private void RoundedPanel_Paint(object sender, PaintEventArgs e)
		{
			var brush = new SolidBrush(backColor);
			var border = Height;

			e.Graphics.Clear(Parent?.BackColor ?? FormDesign.Design.BackColor);
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			e.Graphics.FillPie(brush, new Rectangle(0, 0, border, border), 90, 180);
			e.Graphics.FillPie(brush, new Rectangle(Width - border, 0, border, border), 270, 180);

			e.Graphics.FillRectangle(brush, new Rectangle(border / 2 - 1, 0, Width - border + 2, Height));
		}
	}
}
