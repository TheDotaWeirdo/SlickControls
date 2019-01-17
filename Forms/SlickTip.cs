using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Extensions;
using SlickControls.Panels;

namespace SlickControls.Forms
{
	public partial class SlickTip : Form
	{
		private System.Timers.Timer DismissTimer = new System.Timers.Timer(10000) { Enabled = true };

		public SlickTip(Control control, string text)
		{
			InitializeComponent();

			Text = text;

			var bnds = CreateGraphics().MeasureString(text, new Font("Nirmala UI", 8.25F));
			var ctrlPos = control.PointToScreen(Point.Empty);
			Size = new Size(Math.Max(8, (int)(bnds.Width / 35)) + (int)bnds.Width, 6 + (int)bnds.Height);
			Location = new Point((ctrlPos.X).If(x => x + Width > SystemInformation.VirtualScreen.Width, ctrlPos.X + control.Width - Width), (ctrlPos.Y - Height).If(x => x < 0, ctrlPos.Y + control.Height));

			Paint += ToolTip_Draw;

			control.MouseLeave += (s, e) =>
			{
				if (!IsDisposed)
					this.TryInvoke(Dismiss);
				if (currentControl?.Value == this)
					currentControl = null;
				DismissTimer.Dispose();
			};

			DismissTimer.Elapsed += (s, e) =>
			{
				if (!IsDisposed)
					this.TryInvoke(Dismiss);
				if (currentControl?.Value == this)
					currentControl = null;
				DismissTimer.Dispose();
			};
		}

		public void Reveal()
		{
			Show();
			animationTimer = new System.Timers.Timer(30) { Enabled = true };
			animationTimer.Elapsed += (s, e) =>
			{
				if (IsDisposed || Opacity >= 1)
					animationTimer.Dispose();
				else
					this.TryInvoke(() => Opacity += .15);
			};
		}

		public void Dismiss()
		{
			animationTimer?.Dispose();
			animationTimer = new System.Timers.Timer(30) { Enabled = true };
			animationTimer.Elapsed += (s, e) =>
			{
				if (IsDisposed || Opacity <= 0)
				{ animationTimer.Dispose(); this.TryInvoke(Dispose); }
				else
					this.TryInvoke(() => Opacity -= .18);
			};
		}

		private void ToolTip_Draw(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.AccentColor), new Rectangle(Point.Empty, Size));

			e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.BackColor), new Rectangle(1, 1, Width - 2, Height - 2));

			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			e.Graphics.DrawString(Text, new Font("Nirmala UI", 8.5F), new SolidBrush(FormDesign.Design.ForeColor), new PointF(4, 3));
		}

		protected override bool ShowWithoutActivation => true;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams baseParams = base.CreateParams;

				const int WS_EX_NOACTIVATE = 0x08000000;
				const int WS_EX_TOOLWINDOW = 0x00000080;
				baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);

				return baseParams;
			}
		}

		#region Statics

		private static Dictionary<Control, string> controlsDictionary = new Dictionary<Control, string>();

		private static KeyValuePair<Control, SlickTip>? currentControl;
		private System.Timers.Timer animationTimer;

		public static void SetTo(Control control, string text, bool recursive = true)
		{
			if (control == null || string.IsNullOrWhiteSpace(text))
				return;

			if (!controlsDictionary.ContainsKey(control))
			{
				control.MouseEnter += Control_MouseEnter;
				control.Disposed += Control_Disposed;
				controlsDictionary.Add(control, text);
			}

			controlsDictionary[control] = text;

			if (recursive && control.Controls.Count > 0)
				foreach (Control ctrl in control.Controls)
					SetTo(ctrl, text);
		}

		private static void Control_Disposed(object sender, EventArgs e)
		{
			var control = sender as Control;
			control.MouseEnter -= Control_MouseEnter;
			control.Disposed -= Control_Disposed;
		}

		private static void Control_MouseEnter(object sender, EventArgs e)
		{
			var control = sender as Control;

			if (control.FindForm() is SlickForm frm && frm.FormIsActive)
			{
				var timer = new System.Timers.Timer(500) { Enabled = true, AutoReset = false };

				timer.Elapsed += (s, et) =>
				control.TryInvoke(() =>
				{
					if (frm.FormIsActive && mouseIsIn(control, MousePosition))
					{
						if (currentControl != null)
						{
							if (currentControl?.Key == control)
								return;
							else
								currentControl?.Value.Dismiss();
						}

						currentControl = new KeyValuePair<Control, SlickTip>(control, new SlickTip(control, controlsDictionary[control]));
						frm.CurrentFormState = FormState.ForcedFocused;
						currentControl?.Value.Reveal();
						frm.Focus();
						frm.CurrentFormState = FormState.NormalFocused;
						timer.Dispose();
					}
				});
			}
		}

		private static bool mouseIsIn(Control control, Point point)
		{
			try
			{ return control.ClientRectangle.Contains(control.PointToClient(point)); }
			catch
			{ return false; }
		}

		#endregion Statics
	}
}