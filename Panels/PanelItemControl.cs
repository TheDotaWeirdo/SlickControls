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

namespace SlickControls.Panels
{
	public partial class PanelItemControl : Controls.SlickControl
	{
		public PanelItem PanelItem { get; private set; }
		public bool Selected { get => selected; set { selected = value; Invalidate(); /*Font = new Font(Font, value ? FontStyle.Bold : FontStyle.Regular);*/ } }

		private bool selected;

		private bool _hovered = false;
		private bool _pressed = false;

		public PanelItemControl(PanelItem item)
		{
			InitializeComponent();
			Dock = DockStyle.Top;
			PanelItem = item;
		}

		protected override void DesignChanged(FormDesign design) => Refresh();

		private void PanelItemControl_Paint(object sender, PaintEventArgs e)
		{
			var back = FormDesign.Design.MenuColor;
			var fore = FormDesign.Design.MenuForeColor;

			if (_hovered)
				back = FormDesign.Design.MenuColor.Tint(Lum: FormDesign.Design.Type.If(FormDesignType.Dark, 10, -5));

			if (Selected)
				fore = FormDesign.Design.ActiveColor;
			else if(_pressed)
			{
				back = FormDesign.Design.ActiveColor;
				fore = FormDesign.Design.ActiveForeColor;
			}

			e.Graphics.Clear(back);

			if (Selected)
				e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ActiveColor), new RectangleF(Width - 2, 0, 2, Height));

			var bnds = e.Graphics.MeasureString(PanelItem.Text, Font);

			if (PanelItem.Icon != null)
				e.Graphics.DrawImage(new Bitmap(PanelItem.Icon, 16, 16).Color(fore), 15, (Height - 16) / 2);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			e.Graphics.DrawString(PanelItem.Text, Font, new SolidBrush(fore), 15 + 16 + 5, (Height - bnds.Height) / 2);
		}

		private void PanelItemControl_MouseClick(object sender, MouseEventArgs e)
		{
			PanelItem.MouseClick(e);
		}

		private void PanelItemControl_MouseDown(object sender, MouseEventArgs e)
		{
			_pressed = true;
			Invalidate();
		}

		private void PanelItemControl_MouseEnter(object sender, EventArgs e)
		{
			_hovered = true;
			Invalidate();
		}

		private void PanelItemControl_MouseLeave(object sender, EventArgs e)
		{
			_hovered = false;
			Invalidate();
		}

		private void PanelItemControl_MouseUp(object sender, MouseEventArgs e)
		{
			_pressed = false;
			Invalidate();
		}
	}
}
