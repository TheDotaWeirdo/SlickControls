using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public class RoundedPicture : PictureBox
	{
		private int border = 5;

		[Category("Appearance")]
		public int Border { get => border; set { border = value; Refresh(); } }

		public RoundedPicture()
		{
			Paint += RoundedPanel_Paint;
			Resize += (s, e) => Refresh();
			//DoubleBuffered = true;
		}

		private void RoundedPanel_Paint(object sender, PaintEventArgs e)
		{
			if (Image == null || Image.RawFormat.Guid == ImageFormat.Gif.Guid || Image.Width <= 100)
				return;

			p: try
			{
				var brush = new TextureBrush(new Bitmap(Image, Size));
				var border = (Border == 0 ? (Math.Min(Height, Width) / 3).Between(5, 20) : Border) * 2;

				e.Graphics.Clear(BackColor);
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

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
			catch (InvalidOperationException)
			{
				System.Threading.Thread.Sleep(100);
				goto p;
			}
		}
	}
	}
