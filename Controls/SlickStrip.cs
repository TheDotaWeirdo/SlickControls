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
	public partial class SlickStrip : UserControl
	{
		private const int ICON_SIZE = 16;

		private bool mouseIn = false;
		private bool mouseDown = false;

		public Classes.FlatStripItem StripItem { get; }

		public SlickStrip(Classes.FlatStripItem item, bool hideImg)
		{
			InitializeComponent();
			StripItem = item;

			if (!item.Fade && !item.IsEmpty)
			{
				Cursor = Cursors.Hand;
				Click += SlickStrip_Click;
				MouseDown += SlickStrip_MouseDown;
				MouseEnter += SlickStrip_MouseEnter;
				MouseLeave += SlickStrip_MouseLeave;
				MouseUp += SlickStrip_MouseUp;
			}

			if (item.IsEmpty)
				Height = 7;

			if (item.Image != null)
				item.Image = new Bitmap(item.Image, new Size(ICON_SIZE, ICON_SIZE));
		}

		private void SlickStrip_Paint(object sender, PaintEventArgs e)
		{
			var d = FormDesign.Design;
			e.Graphics.Clear(mouseIn.If(d.ButtonColor, d.BackColor).If(mouseDown, d.ActiveColor));

			if (StripItem.Image != null)
				e.Graphics.DrawImage(StripItem.Image.Color(StripItem.Fade.If(d.InfoColor, mouseDown.If(d.ActiveForeColor, d.ForeColor))), 5, 2);

			if (StripItem.Text != null)
			{
				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
				var bnds = e.Graphics.MeasureString(StripItem.Text, Font);
				e.Graphics.DrawString(StripItem.Text, Font, new SolidBrush(StripItem.Fade.If(d.InfoColor, mouseDown.If(d.ActiveForeColor, d.ForeColor)))
					, 23  + (StripItem.Tab * 12), 10 - (bnds.Height / 2));
			}
		}

		private void SlickStrip_Click(object sender, EventArgs e) { StripItem.Action(); if (StripItem.CloseOnClick) FindForm()?.Dispose(); } 

		private void SlickStrip_MouseEnter(object sender, EventArgs e) { mouseIn = true; Invalidate(); }

		private void SlickStrip_MouseDown(object sender, MouseEventArgs e) { mouseDown = true; Invalidate(); }

		private void SlickStrip_MouseLeave(object sender, EventArgs e) { mouseIn = false; Invalidate(); }

		private void SlickStrip_MouseUp(object sender, MouseEventArgs e) { mouseDown = false; Invalidate(); }
	}
}
