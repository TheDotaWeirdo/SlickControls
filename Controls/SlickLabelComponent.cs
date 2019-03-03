using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	[DefaultEvent("Click")]
	public partial class SlickLabelComponent : Component
	{
		#region Public Events

		[Category("Action")]
		public event MouseEventHandler MouseHoverChanged;

		[Category("Action")]
		public event MouseEventHandler Click;

		#endregion Public Events

		#region Private Fields

		private Rectangle _bounds = new Rectangle(0, 0, 16, 16);
		private string _text;
		private Control _parent;
		private bool _visible = true;

		#endregion Private Fields

		#region Public Properties

		[Category("Layout")]
		public Rectangle Bounds { get => _bounds; set { _bounds = value; Parent?.Invalidate(value); } }

		[Category("Appearance"), DefaultValue(ColorStyle.Text)]
		public ColorStyle ColorStyle { get; set; } = ColorStyle.Text;

		[Category("Appearance"), DefaultValue(ColorStyle.Active)]
		public ColorStyle HoverStyle { get; set; } = ColorStyle.Active;

		[Category("Appearance")]
		public string Text { get => _text; set { _text = value; Parent?.Invalidate(Bounds); } }

		[Category("Appearance")]
		public Font Font { get; set; }

		[Category("Layout")]
		public Point Location { get => Bounds.Location; set => Bounds = new Rectangle(value, Size); }

		[Category("Behavior"), Browsable(false)]
		public bool MouseHovered { get; private set; }

		[Category("Behavior"), DefaultValue(true)]
		public bool Enabled { get; set; } = true;

		[Category("Appearance"), DefaultValue(false)]
		public bool Background { get; set; }

		[Category("Behavior")]
		public Control Parent
		{
			get => _parent;
			set
			{
				if (_parent != null && !DesignMode)
				{
					_parent.Paint -= _parent_Paint;
					_parent.MouseMove -= _parent_MouseMove;
					_parent.MouseClick -= _parent_MouseClick;
				}

				_parent = value;

				if (value != null && !DesignMode)
				{
					_parent.Paint += _parent_Paint;
					_parent.MouseMove += _parent_MouseMove;
					_parent.MouseClick += _parent_MouseClick;
				}
			}
		}

		[DefaultValue(AnchorStyles.Top | AnchorStyles.Left)]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public AnchorStyles Anchor { get; set; }

		private void _parent_MouseClick(object sender, MouseEventArgs e)
		{
			if (Visible && Bounds.Contains(e.Location))
				Click?.Invoke(this, e);
		}

		[Category("Layout")]
		public Size Size { get => Bounds.Size; set => Bounds = new Rectangle(Location, value); }

		[Category("Behavior"), DefaultValue(true)]
		public bool Visible { get => _visible; set { _visible = value; if (!value) MouseHovered = false; } }

		#endregion Public Properties

		#region Public Constructors

		public SlickLabelComponent()
		{
			InitializeComponent();
		}

		public SlickLabelComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		#endregion Public Constructors

		#region Private Methods

		private void _parent_MouseMove(object sender, MouseEventArgs e)
		{
			if (Visible)
			{
				MouseHovered = Bounds.Contains(e.Location);
				MouseHoverChanged?.Invoke(this, e);
				Parent?.Invalidate(Bounds);
			}
		}

		private void _parent_Paint(object sender, PaintEventArgs e)
		{
			if (Visible)
			{
				var loc = Location;
				if (Anchor == (AnchorStyles.Right | AnchorStyles.Top))
					loc = new Point(Parent.Width - Location.X - Size.Width, Location.Y);
				else if (Anchor == (AnchorStyles.Right | AnchorStyles.Bottom))
					loc = new Point(Parent.Width - Location.X - Size.Width, Parent.Height - Location.Y - Size.Height);
				else if (Anchor == (AnchorStyles.Left | AnchorStyles.Bottom))
					loc = new Point(Location.X, Parent.Height - Location.Y - Size.Height);

				var colorStyle = (Enabled || !MouseHovered).If(ColorStyle, HoverStyle);
				var bnds = e.Graphics.MeasureString(Text, Font);

				if (Background)
				{
					e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					e.Graphics.FillRoundedRectangle(new SolidBrush(colorStyle.GetBackColor()), new Rectangle(loc, Size), 5);
				}

				e.Graphics.DrawString(Text, Font, new SolidBrush(colorStyle.GetColor()), new Rectangle(new Rectangle(loc, Size).Center(bnds.ToSize()), Size));
			}
		}

		#endregion Private Methods
	}
}