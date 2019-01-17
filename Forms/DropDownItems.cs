using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using SlickControls.Controls;

namespace SlickControls.Forms
{
	public partial class DropDownItems : Form
	{
		private Func<object, string> Conversion;

		public DropDownItems(IEnumerable<object> list, Func<object, string> conversion = null)
		{
			InitializeComponent();
			Conversion = conversion;
			DesignChanged(FormDesign.Design);

			SetItems(list);
			Height = Math.Min(400, 2 + P_Items.Height);
		}

		private void Ctrl_Click(object sender, EventArgs e)
		{
			ItemSelected?.Invoke((sender as Control).Tag);
			Close();
		}

		private void DesignChanged(FormDesign design)
		{
			BackColor = design.AccentColor;
			panel.BackColor = design.BackColor;
		}

		public event Action<object> ItemSelected;

		#region Move/Resize

		public const int HT_CAPTION = 0x2;
		public const int WM_NCLBUTTONDOWN = 0xA1;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= 0x20000; // <--- use 0x20000
				return cp;
			}
		}

		public object CurrentItem => P_Items.Controls.ThatAre<DropDownItem>().FirstThat(x => x.Focused)?.Tag;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		protected override void WndProc(ref Message m)
		{
			const int RESIZE_HANDLE_SIZE = 10;

			switch (m.Msg)
			{
				case 0x0084/*NCHITTEST*/ :
					base.WndProc(ref m);

					if ((int)m.Result == 0x01/*HTCLIENT*/)
					{
						Point screenPoint = new Point(m.LParam.ToInt32());
						Point clientPoint = this.PointToClient(screenPoint);
						if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
							else if (clientPoint.X < ( Size.Width - RESIZE_HANDLE_SIZE ))
								m.Result = (IntPtr)12/*HTTOP*/ ;
							else
								m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
						}
						else if (clientPoint.Y <= ( Size.Height - RESIZE_HANDLE_SIZE ))
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)10/*HTLEFT*/ ;
							else if (clientPoint.X < ( Size.Width - RESIZE_HANDLE_SIZE ))
								m.Result = (IntPtr)2/*HTCAPTION*/ ;
							else
								m.Result = (IntPtr)11/*HTRIGHT*/ ;
						}
						else
						{
							if (clientPoint.X <= RESIZE_HANDLE_SIZE)
								m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
							else if (clientPoint.X < ( Size.Width - RESIZE_HANDLE_SIZE ))
								m.Result = (IntPtr)15/*HTBOTTOM*/ ;
							else
								m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
						}
					}
					return;
			}
			base.WndProc(ref m);
		}

		#endregion Move/Resize

		private void DropDownItems_Resize(object sender, EventArgs e)
		{
			P_Items.MaximumSize = new Size(panel.Width, 9999);
			P_Items.MinimumSize = new Size(panel.Width, 0);
		}

		internal void SetItems(IEnumerable<object> list)
		{
			P_Items.SuspendDrawing();
			P_Items.Controls.Clear(true);
			foreach (var item in list)
			{
				var ctrl = new DropDownItem()
				{
					Text = Conversion == null ? item.ToString() : Conversion(item),
					Tag = item,
					Dock = DockStyle.Top
				};

				ctrl.Click += Ctrl_Click;
				P_Items.Controls.Add(ctrl);
				ctrl.BringToFront();
			}
			P_Items.ResumeDrawing();
		}
	}
}