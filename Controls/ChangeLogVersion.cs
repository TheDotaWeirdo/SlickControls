using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;

namespace SlickControls.Controls
{
	public partial class ChangeLogVersion : SlickControl
	{
		private VersionInfo inf;

		public ChangeLogVersion(VersionInfo inf)
		{
			InitializeComponent();
			this.inf = inf;
			Dock = DockStyle.Top;
			ResizeRedraw = true;
			DoubleBuffered = true;

			Height = GetHeight();
		}

		private void ChangeLogVersion_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(BackColor);

			e.Graphics.DrawString(inf.Version.ToString(),
				new Font("Nirmala UI", 9.75F, FontStyle.Bold),
				new SolidBrush(FormDesign.Design.ForeColor),
				new PointF(20, 4));

			var h = 23F;
			foreach (var item in inf.Descriptions)
			{
				if (item.Info.Any())
				{
					var bnds = e.Graphics.MeasureString(item.Title, new Font("Nirmala UI", 9F, FontStyle.Bold), Width - 30);
					e.Graphics.DrawString(item.Title,
						new Font("Nirmala UI", 9F, FontStyle.Bold),
						new SolidBrush(FormDesign.Design.LabelColor),
						new RectangleF(25, h, Width - 30, bnds.Height));

					h += 3 + bnds.Height;

					foreach (var info in item.Info)
					{
						bnds = e.Graphics.MeasureString(info, new Font("Nirmala UI", 8.25F), Width - 35);
						e.Graphics.DrawString(info,
							new Font("Nirmala UI", 8.25F),
							new SolidBrush(FormDesign.Design.InfoColor),
							new RectangleF(30, h, Width - 35, bnds.Height));

						h += bnds.Height;
					}

					h += 5;
				}
				else
				{
					var bnds = e.Graphics.MeasureString(item.Title, new Font("Nirmala UI", 9F, FontStyle.Bold), Width - 30);
					e.Graphics.DrawString(item.Title,
						new Font("Nirmala UI", 9F, FontStyle.Bold),
						new SolidBrush(FormDesign.Design.ActiveColor),
						new RectangleF(25, h, Width - 30, bnds.Height));

					h += 8 + bnds.Height;
				}
			}

			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			e.Graphics.FillPolygon(new SolidBrush(FormDesign.Design.ForeColor),
				new PointF[]
				{
					new PointF(12F,7),
					new PointF(16.5F,11.5F),
					new PointF(12F,16),
					new PointF(7.5F,11.5F),
				});

			e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ForeColor), 11.5F, 11.5F, 1, Height - 60);

			e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(
				new RectangleF(11.5F, Height - 60, 1, 50),
				FormDesign.Design.ForeColor,
				BackColor,
				90),
				new RectangleF(11.5F, Height - 60, 1, 49));
		}

		private int GetHeight()
		{
			var g = CreateGraphics();

			var h = 30F;
			foreach (var item in inf.Descriptions)
			{
				if (item.Info.Any())
				{
					var bnds = g.MeasureString(item.Title, new Font("Nirmala UI", 9F, FontStyle.Bold | FontStyle.Italic), Width - 30);

					h += 3 + bnds.Height;

					foreach (var info in item.Info)
					{
						bnds = g.MeasureString(info, new Font("Nirmala UI", 8.25F), Width - 35);

						h += bnds.Height;
					}

					h += 5;
				}
				else
				{
					var bnds = g.MeasureString(item.Title, new Font("Nirmala UI", 9F, FontStyle.Bold), Width - 30);

					h += 8 + bnds.Height;
				}
			}

			return (int)h;
		}


		private void ChangeLogVersion_Resize(object sender, EventArgs e)
		{
			var ch = GetHeight();
			if (Height != ch)
				Height = ch;
		}
	}
}