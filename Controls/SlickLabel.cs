using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlickControls.Enums;
using Extensions;
using System.Drawing.Imaging;
using SlickControls.Classes;
using SlickControls.Forms;

namespace SlickControls.Controls
{
    [DefaultEvent("Click")]
	public partial class SlickLabel : PictureBox
	{
		public event HoverStateChanged HoverStateChanged;

		private Func<Color> activeColor;

		private bool center = false;

		private int iconSize = 16;

		private bool selected = false;

		public SlickLabel()
		{
			InitializeComponent();
			Padding = new Padding(5, 3, 5, 3);

			FormDesign.DesignChanged += DesignChanged;
			Disposed += (s, e) => FormDesign.DesignChanged += DesignChanged;
		}

		protected virtual void DesignChanged(FormDesign design) => Invalidate();

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public Func<Color> ActiveColor { get => activeColor; set { activeColor = value; Invalidate(); } }

		[Category("Design")]
		public bool Center { get => center; set { center = value; Invalidate(); } }

		private HoverState hoverState = HoverState.Normal;

		[Category("Appearance")]
		public new Image Image
		{
			get => base.Image;
			set { base.Image = value; ResizeForAutoSize(); }
		}

		private bool hideText = false;

		[Category("Design")]
		public int IconSize { get => iconSize; set { iconSize = value; ResizeForAutoSize(); Invalidate(); } }

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override string Text
		{
			get => base.Text;
			set
			{
				base.Text = value;
				ResizeForAutoSize();
				SlickTip.SetTo(this, value);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override Font Font { get => base.Font; set => base.Font = value; }

		private bool IsPicture
		{
			get
			{
				try { return Image != null && !Image.IsAnimated(); }
				catch { return false; }
			}
		}

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public HoverState HoverState
		{
			get => hoverState;
			set
			{
				if (!selected)
				{
					if (hoverState != value)
						HoverStateChanged?.Invoke(value);
					hoverState = value;
					Invalidate();
				}
			}
		}

		[Category("Design")]
		public bool HideText { get => hideText; set { hideText = value; ResizeForAutoSize(); Invalidate(); } }

		private void GetColors(out Color fore, out Color back)
		{
			switch (hoverState)
			{
				case HoverState.Hovered:
					fore = FormDesign.Design.ForeColor.Tint(Lum: FormDesign.Design.Type.If(FormDesignType.Dark, -7, 7));
					back = FormDesign.Design.ButtonColor;
					break;
				case HoverState.Pressed:
					fore = ActiveColor == null ? FormDesign.Design.ActiveForeColor : FormDesign.Design.ActiveForeColor.Tint(ActiveColor());
					back = ActiveColor == null ? FormDesign.Design.ActiveColor : ActiveColor();
					break;
				default:
					fore = ForeColor;
					back = BackColor;
					break;
			}
		}

		private void SlickButton_Paint(object sender, PaintEventArgs e)
		{
			GetColors(out var fore, out var back);
			e.Graphics.Clear(BackColor);

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			if (HoverState >= HoverState.Hovered)
				e.Graphics.FillRoundedRectangle(new SolidBrush(back), new Rectangle(1, 1, Width - 3, Height - 3), 7);

			//if (Focused)
			//	e.Graphics.DrawRoundedRectangle(new Pen(back.Tint(null, FormDesign.Design.Type == FormDesignType.Light ? 3 : -3), 2F), new Rectangle(1, 1, Width - 3, Height - 3), 7);

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			var bnds = e.Graphics.MeasureString(Text, Font);

			if (Image != null)
			{
            var bmp = IsPicture ? new Bitmap(Image, iconSize, iconSize).Color(fore) : Image;

            if (HideText || string.IsNullOrWhiteSpace(Text))
					e.Graphics.DrawImage(bmp, new Rectangle((Width - iconSize) / 2, (int)((Height - iconSize) / 2F), iconSize, iconSize));
				else
					e.Graphics.DrawImage(bmp, new Rectangle(Padding.Left, (int)((Height - iconSize) / 2F), iconSize, iconSize));
			}

			var stl = new StringFormat()
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near,
				Trimming = StringTrimming.EllipsisCharacter
			};

			if (!HideText && !string.IsNullOrWhiteSpace(Text))
			{
				if (Image != null)
					e.Graphics.DrawString(Text, Font, new SolidBrush(fore), new RectangleF(/*(Width - iconSize - Padding.Horizontal - bnds.Width) / 2 +*/ iconSize + 2 * Padding.Left, (Height - bnds.Height) / 2, Width - (iconSize + Padding.Horizontal + Padding.Left), bnds.Height), stl);
				else
					e.Graphics.DrawString(Text, Font, new SolidBrush(fore), new RectangleF(Math.Max(Padding.Left, (Width - bnds.Width) / 2), (Height - bnds.Height) / 2, Width - Padding.Horizontal, bnds.Height), stl);
			}
		}

		public void Hold()
		{
            ForeColor = FormDesign.Design.ActiveColor;
			selected = true;
		}

		public void Release()
		{
			selected = false;
            ForeColor = Color.Empty;
        }

		private void MyLabel_MouseDown(object sender, MouseEventArgs e)
			=> HoverState = HoverState.Pressed;

		private void MyLabel_MouseEnter(object sender, EventArgs e)
			=> HoverState = HoverState.Hovered;

		private void MyLabel_MouseLeave(object sender, EventArgs e)
			=> HoverState = HoverState.Normal;

		private void MyLabel_MouseUp(object sender, MouseEventArgs e)
			=> HoverState = HoverState.Normal;

		private void MyLabel_Resize(object sender, EventArgs e)
			=> Invalidate();

		/// <summary>
		/// Retrieves the size of a rectangular area into which
		/// a control can be fitted.
		/// </summary>
		public override Size GetPreferredSize(Size proposedSize)
		{
			return GetAutoSize();
		}
		private void ResizeForAutoSize()
        {
            try
            {
                if (AutoSize)
                    SetBoundsCore(Left, Top, Width, Height, BoundsSpecified.Size);
            }
            catch { }
		}
		private Size GetAutoSize()
		{
			using (var g = Graphics.FromHwnd(Handle))
			{
				var w = 3;
				var h = 0;

				var bnds = g.MeasureString(Text, Font);

				if (Image != null)
					w += Padding.Left + iconSize;

				if (Text != "" && !HideText)
					w += (int)bnds.Width + Padding.Horizontal;
				else
					w += Padding.Right;

				h = Math.Max(IconSize + Padding.Vertical, (int)bnds.Height + Padding.Vertical);

				return new Size(w, h);
			}
		}

		/// <summary>
		/// Performs the work of setting the specified bounds of this control.
		/// </summary>
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			//  Only when the size is affected...
			if (this.AutoSize && (specified & BoundsSpecified.Size) != 0)
			{
				Size size = GetAutoSize();

				width = size.Width;
				height = size.Height;
			}

			base.SetBoundsCore(x, y, width, height, specified);
		}

		private void SlickLabel_Focus(object sender, EventArgs e)
			=> Invalidate();
	}
}
