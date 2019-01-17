using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlickControls.Controls
{
	public partial class CustomListBox : ListBox
	{
		public event DrawItemEventHandler OnDrawOfItem;
		int? lastindex;

		public CustomListBox() { DoubleBuffered = true; }
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (lastindex != null && lastindex != -1 && lastindex != e.Index && lastindex < Items.Count)
			{
				var rect = GetItemRectangle((int)lastindex);
				//rect.Location = new Point(rect.X, rect.Y - 1);
				//rect.Height += 2;
				var newargs = new DrawItemEventArgs(e.Graphics, e.Font, rect, (int)(lastindex), e.State);
				OnDrawItem(newargs);
			}

			if (e.Index != -1)
				OnDrawOfItem?.Invoke(this, e);

			lastindex = e.Index;
		}
	}
}
