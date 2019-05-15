using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;
using SlickControls.Enums;

namespace SlickControls.Forms
{
	public partial class NotificationForm : Form
	{
		private static Dictionary<Form, List<NotificationForm>> Notifications = new Dictionary<Form, List<NotificationForm>>();

		public Notification Notification { get; }
		private Form Form;

		private NotificationForm(Notification notification, Form form = null, bool longSound = false, int? timeoutSeconds = null)
		{
			InitializeComponent();

			Notification = notification;
			Form = form;

			ResizeRedraw = TopMost = DoubleBuffered = true;

			if (notification.Action != null)
				Cursor = Cursors.Hand;

			Disposed += (s, e) =>
			{
				Notifications[Form ?? Empty].Remove(this);
				FormDesign.DesignChanged -= DesignChanged;

				if (form != null)
				{
					form.LocationChanged -= Form_Move;
					form.Resize -= Form_Move;
				}

				foreach (var item in Notifications[Form ?? Empty])
					item.SetLocation();
			};

			if (form != null)
			{
				form.LocationChanged += Form_Move;
				form.Resize += Form_Move;
			}

			if (timeoutSeconds != null && timeoutSeconds > 0)
			{
				new System.Timers.Timer((double)timeoutSeconds * 1000) { Enabled = true, AutoReset = false }
					.Elapsed += (s, e) =>
					{
						if (!IsDisposed)
							this.TryInvoke(Close);

						(s as System.Timers.Timer).Dispose();
					};
			}

			FormDesign.DesignChanged += DesignChanged;

			var str = longSound ? Properties.Resources.Notif_Long : Properties.Resources.Notif_Quick;

			var snd = new System.Media.SoundPlayer(str);
			snd.Play();
		}

		internal static void Clear()
		{
			foreach (var item in Notifications.ConvertEnumerable(x => x.Value).ToArray())
				item.TryInvoke(item.Dispose);
		}

		private void DesignChanged(FormDesign design) => PictureBox.Invalidate();

		private void Form_Move(object sender, EventArgs e) => SetLocation();

		private void SetLocation()
		{
			if (Form != null)
			{
				var y = Form.Bottom - 10 - (Notifications[Form].Take((Notifications[Form].IndexOf(this) + 1)).Sum(f => (10 + f.Height)));
				var x = Form.Right - 20 - Width;

				Location = new Point(x, y);
			}
			else
			{
				var y = SystemInformation.VirtualScreen.Height - 10 - ((10 + Height) * (Notifications[Empty].IndexOf(this) + 1));
				var x = SystemInformation.VirtualScreen.Width - 20 - Width;

				Location = new Point(x, y);
			}
		}

		public void SetText(string text)
		{
			this.TryInvoke(() => { Notification.Description = text; PictureBox.Invalidate(); });
		}

		private static Form Empty = new Form();

		public static NotificationForm Push(Notification notification, Form form = null, bool longSound = false, int? timeoutSeconds = null)
		{
			if (form != null && (!form.Visible || form.WindowState == FormWindowState.Minimized))
				form = null;

			var frm = new NotificationForm(notification, form, longSound, timeoutSeconds) { Size = new Size(0, notification.Size.Height) };
			frm.PictureBox.Size = notification.Size;

			var aH = new AnimationHandler(frm, notification.Size) { SpeedModifier = 8, Interval = 14, IgnoreHeight = true };
			aH.OnAnimationTick += (s, e, p) => frm.SetLocation();
			aH.StartAnimation();

			if (Notifications.ContainsKey(form ?? Empty))
				Notifications[form ?? Empty].Add(frm);
			else
				Notifications.TryAdd(form ?? Empty, new List<NotificationForm>() { frm });

			frm.SetLocation();
			form?.ShowUp();
			frm.ShowUp();

			return frm;
		}

		private void NotificationForm_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(FormDesign.Design.BackColor);

			e.Graphics.DrawRectangle(new Pen(FormDesign.Design.AccentColor, 1), 0, 0, PictureBox.Width-1, PictureBox.Height-1);

			GetColorIcons(out var icon, out var color);

			e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 2, PictureBox.Height);

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

			if (Notification.OnPaint != null)
				Notification.OnPaint(PictureBox, e.Graphics);
			else
			{
				e.Graphics.DrawImage(icon, 8, 6, 16, 16);

				e.Graphics.DrawString(Notification.Title, new Font("Nirmala UI", 9.75F), new SolidBrush(FormDesign.Design.ForeColor), icon.IfNull(8, 25), 4);

				e.Graphics.DrawString(Notification.Description, new Font("Nirmala UI", 8.25F), new SolidBrush(FormDesign.Design.InfoColor), new RectangleF(12, 30, PictureBox.Width - 15, PictureBox.Height - 33), new StringFormat() { Trimming = StringTrimming.EllipsisCharacter });
			}

			if (new Rectangle(PictureBox.Width - 20, 4, 16, 16).Contains(PointToClient(MousePosition)))
				e.Graphics.DrawImage(Properties.Resources.Tiny_Close.Color(FormDesign.Design.ActiveColor), PictureBox.Width - 20, 4, 16, 16);
			else
				e.Graphics.DrawImage(Properties.Resources.Tiny_Close.Color(FormDesign.Design.IconColor), PictureBox.Width - 20, 4, 16, 16);
		}

		private void GetColorIcons(out Bitmap icon, out Color color)
		{
			var design = FormDesign.Design;
			switch (Notification.Icon)
			{
				case PromptIcons.Hand:
					icon = Properties.Resources.Tiny_Hand.Color(design.LabelColor);
					color = design.ActiveColor;
					break;

				case PromptIcons.Info:
					icon = Properties.Resources.Tiny_Info.Color(design.LabelColor);
					color = design.ActiveColor;
					break;

				case PromptIcons.Input:
					icon = Properties.Resources.Tiny_Notification.Color(design.LabelColor);
					color = design.ActiveColor;
					break;

				case PromptIcons.Question:
					icon = Properties.Resources.Tiny_Question.Color(design.LabelColor);
					color = design.ActiveColor;
					break;

				case PromptIcons.Warning:
					icon = Properties.Resources.Tiny_Warning.Color(design.YellowColor);
					color = design.YellowColor;
					break;

				case PromptIcons.Error:
					icon = Properties.Resources.Tiny_Cancel.Color(design.RedColor);
					color = design.RedColor;
					break;

				default:
					icon = null;
					color = design.ActiveColor;
					break;
			}
		}

		private void NotificationForm_MouseMove(object sender, MouseEventArgs e)
		{
			PictureBox.Invalidate();

			if (Notification.Action == null)
				PictureBox.Cursor = new Rectangle(Width - 20, 4, 16, 16).Contains(PointToClient(MousePosition))
					? Cursors.Hand
					: Cursors.Default;
		}

		private void NotificationForm_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (!new Rectangle(Width - 20, 4, 16, 16).Contains(PointToClient(MousePosition)))
				{
					if (Notification.Action != null)
					{
						Notification.Action.Invoke();
                        Close();
					}
				}
				else
                    Close();
			}

			if (Form != null)
				Form.ShowUp();
		}

        public new void Close()
        {
            var aH = new AnimationHandler(this, Size.Empty) { SpeedModifier = 8, Interval = 14, IgnoreHeight = true, Lazy = true };
            aH.OnAnimationTick += (s, e, p) => SetLocation();
            aH.StartAnimation(Dispose);
        }
	}
}
