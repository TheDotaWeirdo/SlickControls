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
	[DefaultEvent("TabSelected")]
	public partial class SlickTab : SlickControl
	{
		public event EventHandler TabSelected;

		private bool hovered;
		private bool selected;
		private System.Timers.Timer AnimationTimer = new System.Timers.Timer(24);

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public override string Text { get; set; }
		public bool Hovered
		{
			get => hovered;
			set
			{
				hovered = value;

				if (!EndReached)
					AnimationTimer.Start();
			}
		}

		public bool Selected
		{
			get => selected;
			set
			{
				if (value && Parent != null)
					foreach (var item in Parent.Controls.ThatAre<SlickTab>())
						item.Selected = false;

				selected = value;

				Invalidate();

				if (!EndReached)
					AnimationTimer.Start();

				if (value)
					TabSelected?.Invoke(this, new EventArgs());
			}
		}

		public double Perc { get; private set; }

		public SlickTab()
		{
			InitializeComponent();
			AnimationTimer.Elapsed += AnimationTimer_Elapsed;
		}

		private void AnimationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			var diff = 7.5 + (Math.Abs(((Selected || Hovered) ? 100 : 0) - Perc) / 5).Between(0, 10);

			if (!(Selected || Hovered))
				diff = -(diff - 2.5);

			Perc = (Perc + diff).Between(0, 100);

			if (EndReached)
				AnimationTimer.Stop();

			this.TryInvoke(() => Invalidate(new Rectangle(0, Height - 1, Width, 1)));
		}

		private bool EndReached => ((Selected || Hovered) && Perc >= 100) || (!(Selected || Hovered) && Perc <= 0);

		private void SlickTab_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			var bnds = e.Graphics.MeasureString(Text, Font);
			e.Graphics.DrawString(Text, Font, new SolidBrush(Selected ? FormDesign.Design.ActiveColor : FormDesign.Design.ForeColor), (Width - bnds.Width) / 2, (Height - bnds.Height) / 2);

			var w = Math.Min(Width, 125) * (float)Perc / 100;
			e.Graphics.FillRectangle(new SolidBrush(Selected ? FormDesign.Design.ActiveColor : FormDesign.Design.ForeColor), (Width - w) / 2, Height - 1, w, 1);
		}

		private void SlickTab_MouseEnter(object sender, EventArgs e)
		{
			Hovered = true;
		}

		private void SlickTab_MouseLeave(object sender, EventArgs e)
		{
			Hovered = false;
		}

		private void SlickTab_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !Selected)
				Selected = true;
		}
	}
}
