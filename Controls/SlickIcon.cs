using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using SlickControls.Enums;

namespace SlickControls.Controls
{
	public class SlickIcon : PictureBox
	{
        private bool enableGraphics = true;

		private int minimumIconSize = 18;

		private bool selected = false;

		public SlickIcon()
		{
			MouseEnter += MyLabel_MouseEnter;
			MouseLeave += MyLabel_MouseLeave;
			MouseDown += MyLabel_MouseDown;
			MouseUp += MyLabel_MouseUp;

            DoubleBuffered = true;
			Cursor = Cursors.Hand;
			FormDesign.DesignChanged += (d) => UpdateState();
			UpdateState(true);
			SizeMode = PictureBoxSizeMode.Zoom;
		}

		public delegate void action();

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Func<Color> ActiveColor { get; set; }

        private HoverState hoverState = HoverState.Normal;

		[Category("Appearance")]
		public new Image Image
		{
			get => base.Image;
			set
			{
				base.Image = value;
				Visible = value != null;
				UpdateState(true);
			}
		}

		[Category("Design")]
		public int MinimumIconSize
		{
			get => minimumIconSize;
			set
			{
				minimumIconSize = value;
				Size = new Size(value, value);
			}
		}

		[Category("Behavior")]
		public new bool Enabled
		{
			get => enableGraphics;
			set
			{
				enableGraphics = value;
				Cursor = value ? Cursors.Hand : Cursors.Default;
				UpdateState(true);
			}
        }

        [Category("Appearance"), DisplayName("Color Style"), DefaultValue(ColorStyle.Active)]
        public ColorStyle ColorStyle { get; set; } = ColorStyle.Active;

        private bool IsPicture
		{
			get
			{
				try { return Image != null && Image.RawFormat.Guid != System.Drawing.Imaging.ImageFormat.Gif.Guid; }
				catch { return false; }
			}
		}

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public HoverState HoverState { get => hoverState; set { hoverState = value; UpdateState(); } }

		private void UpdateState(bool forced = false)
		{
			if (!forced && (!Enabled || selected))
				return;

			switch (hoverState)
			{
				case HoverState.Normal:
					{
						if (IsPicture)
							base.Image = Image.Color(FormDesign.Design.IconColor);

						break;
					}
				case HoverState.Hovered:
                {
                    if (IsPicture)
                    {
                        if (ActiveColor == null)
                            base.Image = Image.Color(ColorStyle.GetColor());
                        else
                            base.Image = Image.Color(ActiveColor());
                    }
						break;
					}
				default:
					break;
			}

		}

		public void Hold()
		{
			Refresh();
			MyLabel_MouseDown(null, null);
			selected = true;
		}

		public void Release()
		{
			selected = false;
			Refresh();
		}

		public void Disable()
			=> Enabled = false;

		public void Enable()
			=> Enabled = true;

		private void MyLabel_MouseDown(object sender, MouseEventArgs e)
			=> HoverState = HoverState.Pressed;

		private void MyLabel_MouseEnter(object sender, EventArgs e)
			=> HoverState = HoverState.Hovered;

		private void MyLabel_MouseLeave(object sender, EventArgs e)
			=> HoverState = HoverState.Normal;

		private void MyLabel_MouseUp(object sender, MouseEventArgs e)
			=> HoverState = HoverState.Normal;
	}
}
