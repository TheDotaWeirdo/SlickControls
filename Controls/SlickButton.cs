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
using SlickControls.Enums;
using System.Drawing.Imaging;

namespace SlickControls.Controls
{
	[DefaultEvent("Click")]
	public partial class SlickButton : PictureBox
	{
		private Image image;
		private HoverState hoverState = HoverState.Normal;
		private Color? colorShade = null;

		public SlickButton()
		{
			InitializeComponent();
			Padding = new Padding(10, 5, 10, 5);
			FormDesign.DesignChanged += DesignChanged;
			DesignChanged(FormDesign.Design);
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public new bool TabStop { get; set; } = true;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public override Font Font { get => base.Font; set => base.Font = value; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public override string Text { get; set; }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public HoverState HoverState { get => hoverState; private set { hoverState = value; Invalidate(); } }

		[Category("Appearance")]
		public Color? ColorShade { get => colorShade; set { colorShade = value; Invalidate(); } }

		[Category("Appearance")]
		public int IconSize { get => iconSize; set { iconSize = value; Invalidate(); } }

		protected void DesignChanged(FormDesign design) => Invalidate();

		private void MyButton_Resize(object sender, EventArgs e) => Invalidate();

		private void On_MouseDown(object sender, MouseEventArgs e)
			=> HoverState = HoverState.Pressed;

		private void On_MouseEnter(object sender, EventArgs e)
			=> HoverState = HoverState.Hovered;

		private void On_MouseLeave(object sender, EventArgs e)
			=> HoverState = HoverState.Normal;

		private void On_MouseUp(object sender, MouseEventArgs e)
			=> HoverState = HoverState.Hovered;

		private int iconSize = 16;

		private void GetColors(out Color fore, out Color back)
		{
			switch (hoverState)
			{
				case HoverState.Hovered:
					fore = FormDesign.Design.ButtonForeColor.Tint(Lum: FormDesign.Design.Type == FormDesignType.Light ? -7 : 7);
					back = FormDesign.Design.ButtonColor.Tint(Lum: FormDesign.Design.Type == FormDesignType.Light ? -7 : 7);
					break;
				case HoverState.Pressed:
					fore = FormDesign.Design.ActiveForeColor.Tint(ColorShade?.GetHue());
					back = ColorShade ?? FormDesign.Design.ActiveColor;
					break;
				default:
					fore = FormDesign.Design.ButtonForeColor;
					back = FormDesign.Design.ButtonColor;
					break;
			}
		}

		private void SlickButton_Paint(object sender, PaintEventArgs e)
		{
			GetColors(out var fore, out var back);
			e.Graphics.Clear(BackColor);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			e.Graphics.FillRoundedRectangle(new SolidBrush(back), new Rectangle(1, 1, Width - 3, Height - 3), 5);

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			
			var bnds = e.Graphics.MeasureString(Text, Font);

			if (Image != null)
			{
				try
				{
					image = Image.IsAnimated() ? Image : new Bitmap(Image, iconSize, iconSize).Color(fore);

					if (string.IsNullOrWhiteSpace(Text))
						e.Graphics.DrawImage(image, new RectangleF((Width - iconSize) / 2, (Height - iconSize) / 2F, iconSize, iconSize));
					else
						e.Graphics.DrawImage(image, new RectangleF(Padding.Left, (Height - iconSize) / 2F, iconSize, iconSize));
				}
				catch { }
			}


			var stl = new StringFormat()
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near,
				Trimming = StringTrimming.EllipsisCharacter
			};

			if (Image != null)
				e.Graphics.DrawString(Text, Font, new SolidBrush(fore), new RectangleF((Width - iconSize - Padding.Horizontal - bnds.Width) / 2 + iconSize + Padding.Left, (Height - bnds.Height) / 2, Width - (iconSize + Padding.Horizontal + Padding.Left), bnds.Height), stl);
			else
				e.Graphics.DrawString(Text, Font, new SolidBrush(fore), new RectangleF(Math.Max(Padding.Left, (Width - bnds.Width) / 2), (Height - bnds.Height) / 2, Width - Padding.Horizontal, bnds.Height), stl);

		}

		private void SlickButton_FocusChange(object sender, EventArgs e)
			=> Invalidate();

		public new void OnClick(EventArgs e) => base.OnClick(e);
	}
}
