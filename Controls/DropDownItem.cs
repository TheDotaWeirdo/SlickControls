using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public partial class DropDownItem : Control
	{
		private bool MouseDowned = false;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public override string Text { get; set; }

		public DropDownItem()
		{
			InitializeComponent();
		}

		private void DropDownItem_Paint(object sender, PaintEventArgs e)
		{
			var back = FormDesign.Design.BackColor;
			var fore = FormDesign.Design.ForeColor;

			if (MouseDowned)
			{
				back = FormDesign.Design.ActiveColor;
				fore = FormDesign.Design.ActiveForeColor;
			}
			if (Focused)
			{
				back = back.MergeColor(FormDesign.Design.ActiveColor, 85);
			}

			e.Graphics.Clear(back);

			if (Focused)
				e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ActiveColor), 0, 0, 2, Height);

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			var bnds = e.Graphics.MeasureString(Text, Font);
			e.Graphics.DrawString(Text, Font, new SolidBrush(fore), new RectangleF(5, (Height - bnds.Height) / 2, Width - 10, bnds.Height), new StringFormat() { Trimming = StringTrimming.EllipsisCharacter });
		}

		private void DropDownItem_Enter(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void DropDownItem_Leave(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void DropDownItem_MouseEnter(object sender, EventArgs e)
		{
			Focus();
		}

		private void DropDownItem_MouseLeave(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void DropDownItem_MouseUp(object sender, MouseEventArgs e)
		{
			MouseDowned = false;
			Invalidate();
		}

		private void DropDownItem_MouseDown(object sender, MouseEventArgs e)
		{
			MouseDowned = true;
			Invalidate();
		}

		private void DropDownItem_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				e.Handled = true;
				OnClick(new EventArgs());
			}
		}
	}
}
