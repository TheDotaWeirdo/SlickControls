using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;
using SlickControls.Controls;

namespace SlickControls.Forms
{
	public partial class FlatToolStrip : Form
	{
		private SlickForm form;

		public FlatToolStrip(IEnumerable<FlatStripItem> items, SlickForm form = null)
		{
			InitializeComponent();

			var hideImg = items.All(x => x.Image == null);

			this.form = form;
			Location = Cursor.Position;
			var graphics = CreateGraphics();
			MinimumSize = new Size(Width = Math.Max(150, hideImg.If(0, 23) + (int)items.Max(x => (x.Tab * 12) + graphics.MeasureString(x.Text, Font).Width)), 0);
		
			foreach (var item in items.Where(x => x.Show))
				TLP_Container.Controls.Add(new SlickStrip(item, hideImg) { Dock = DockStyle.Top });

			BackColor = FormDesign.Design.AccentColor;
			if (form != null)
				form.CurrentFormState = FormState.ForcedFocused;

			Disposed += FlatToolStrip_Disposed;

			if (Cursor.Position.Y + Height > SystemInformation.VirtualScreen.Height)
			{
				if (Cursor.Position.X + Width > SystemInformation.VirtualScreen.Width)
					Location = new Point(Cursor.Position.X - Width, Cursor.Position.Y - Height);
				else
					Location = new Point(Cursor.Position.X, Cursor.Position.Y - Height);
			}
			else if (Cursor.Position.X + Width > SystemInformation.VirtualScreen.Width)
				Location = new Point(Cursor.Position.X - Width, Cursor.Position.Y);
		}

		public static void Show(SlickForm form = null, params FlatStripItem[] stripItems)
			=> new FlatToolStrip(stripItems, form).ShowUp();

		private void FlatToolStrip_Disposed(object sender, EventArgs e)
		{
			if (form != null)
			{
				form.Focus();
				form.CurrentFormState = FormState.NormalFocused;
			}
		}

		private void FlatToolStrip_Leave(object sender, EventArgs e)
		{
			Dispose();
		}

		private void FlatToolStrip_Load(object sender, EventArgs e)
		{
			BeginInvoke(new Action(() => Focus()));
		}
	}
}