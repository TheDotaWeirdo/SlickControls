using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	[DefaultEvent("Click")]
	public partial class SlickTile : UserControl
	{
		private bool colorIcon = true;
		private int corner = 5;
		private bool hovered = false;
		private int iconSize = 16;
		private Image image;
		private bool mouseDowned = false;
		private bool pressed = false;
		private bool roundedCorner = false;
		private bool selected = false;

		public SlickTile()
		{
			ResizeRedraw = DoubleBuffered = true;
			Padding = new Padding(5);
			TabStop = false;

			Paint += Tile_Paint;
			MouseEnter += (s, e) => { hovered = true; Invalidate(); };
			MouseLeave += (s, e) => { hovered = false; Invalidate(); };
			MouseDown += (s, e) => { mouseDowned = true; Invalidate(); };
			MouseUp += (s, e) => { mouseDowned = false; Invalidate(); };
		}

		[Category("Behavior"), DefaultValue(true)]
		public bool ColorIcon { get => colorIcon; set { colorIcon = value; Invalidate(); } }

		[Category("Behavior"), DefaultValue(5)]
		public int CornerRadius { get => corner; set { corner = value; Invalidate(); } }

		[Browsable(false)]
		public bool Hovered { get => pressed || hovered; private set => hovered = value; }

		[Category("Appearance"), DefaultValue(16)]
		public int IconSize { get => iconSize; set { iconSize = value; Invalidate(); } }

		[Category("Appearance")]
		public Image Image { get => image; set { image = value; Invalidate(); } }

		[Browsable(false)]
		public bool MouseDowned { get => selected || mouseDowned; private set => mouseDowned = value; }

		[Category("Behavior"), DefaultValue(false)]
		public bool Pressed { get => pressed; set { pressed = value; Invalidate(); } }

		[Category("Appearance"), DefaultValue(false)]
		public bool RoundedCorner { get => roundedCorner; set { roundedCorner = value; Invalidate(); } }

		[Category("Behavior"), DefaultValue(false)]
		public bool Selected { get => selected; set { selected = value; Invalidate(); } }

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override string Text { get { return base.Text; } set { base.Text = value; Invalidate(); } }

		[Category("Appearance"), DefaultValue(true)]
		public bool DrawLeft { get; set; } = true;

		private void Tile_Paint(object sender, PaintEventArgs e)
		{
			var back = BackColor;
			var fore = FormDesign.Design.ForeColor;

			if (hovered)
				back = BackColor.MergeColor(FormDesign.Design.BackColor, 25);

			if (Selected)
			{
				fore = FormDesign.Design.ActiveColor;
				back = FormDesign.Design.BackColor;
			}
			else if (mouseDowned)
			{
				back = FormDesign.Design.ActiveColor;
				fore = FormDesign.Design.ActiveForeColor;
			}

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			if (RoundedCorner)
			{
				e.Graphics.Clear(BackColor);
				e.Graphics.FillRoundedRectangle(new SolidBrush(back), new Rectangle(new Point(), Size), CornerRadius);
			}
			else
				e.Graphics.Clear(back);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			if (Image != null)
				e.Graphics.DrawImage(new Bitmap(Image, iconSize, iconSize).If(colorIcon, x => x.Color(fore)),
					DrawLeft ? new RectangleF(Padding.Left, (Height - iconSize) / 2F, iconSize, iconSize)
						: new RectangleF(Width - Padding.Right - IconSize, (Height - iconSize) / 2F, iconSize, iconSize));

			var bnds = e.Graphics.MeasureString(Text, Font);
			var stl = new StringFormat()
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near,
				Trimming = StringTrimming.EllipsisCharacter
			};

			e.Graphics.DrawString(Text,
				Font, 
				new SolidBrush(fore),
				new RectangleF(DrawLeft ? iconSize + Padding.Horizontal : Padding.Left, (Height - bnds.Height) / 2, Width - (iconSize + Padding.Horizontal + Padding.Left), bnds.Height),
				stl);
		}
	}
}