using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;

namespace SlickControls.Controls
{
	public partial class ChangeLogVersion : SlickControl
	{
		private VersionChangeLog inf;

		public ChangeLogVersion(VersionChangeLog inf)
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

			DrawItems(e.Graphics, true);
		}

		private int GetHeight() => DrawItems(CreateGraphics(), false);

		private int DrawItems(Graphics g, bool draw)
		{
			var tab = 0.25D;
			var h = 4;

			if (draw)
				g.DrawLine(new Pen(FormDesign.Design.AccentColor, 1), 20, 35, 20, Height - 13);

			g.DrawStringItem(inf.Version
				, new Font("Nirmala UI", 14F, FontStyle.Bold)
				, FormDesign.Design.ForeColor
				, Width
				, tab
				, ref h
				, draw);

			if (draw && inf.Date != null)
				g.DrawString($"on {inf.Date?.ToReadableString(inf.Date?.Year != DateTime.Now.Year, ExtensionClass.DateFormat.TDMY)}",
				new Font("Nirmala UI", 8.25F),
				new SolidBrush(FormDesign.Design.LabelColor),
				new PointF(56, 12));

			tab = 2;

			if (!string.IsNullOrWhiteSpace(inf.Tagline))
			{
				h += 2;

				g.DrawStringItem(inf.Tagline
					 , new Font("Century Gothic", 8.25F, FontStyle.Italic)
					 , FormDesign.Design.ButtonForeColor
					 , Width
					 , tab
					 , ref h
					, draw);

				h += 4;
			}

			h += 2;

			foreach (var item in inf.ChangeGroups.OrderBy(x => x.Order))
			{
				tab = 2;

				g.DrawStringItem(item.Name
					, new Font("Nirmala UI", 8.25F, FontStyle.Bold)
					, FormDesign.Design.LabelColor
					, Width
					, tab
					, ref h
					, draw);

				tab++;

				foreach (var ch in item.Changes)
					g.DrawStringItem((ch.StartsWith("-") ? "     " : "•  ") + ch
						, new Font("Nirmala UI", 8.25F)
						, FormDesign.Design.InfoColor
						, Width
						, tab
						, ref h
						, draw);

				h += 10;
			}

			return h;
		}

		private void ChangeLogVersion_Resize(object sender, EventArgs e)
		{
			var ch = GetHeight();
			if (Height != ch)
				Height = ch;
		}
	}
}