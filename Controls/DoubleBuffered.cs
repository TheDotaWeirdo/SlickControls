using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlickControls.Controls
{
	public class DBPanel : Panel
	{
		public DBPanel()
		{
			DoubleBuffered = true;
			ResizeRedraw = true;
		}
	}

	public class DBTableLayoutPanel : TableLayoutPanel
	{
		public DBTableLayoutPanel()
		{
			DoubleBuffered = true;
			ResizeRedraw = true;
		}
	}

	public class DBFlowLayoutPanel : FlowLayoutPanel
	{
		public DBFlowLayoutPanel()
		{
			DoubleBuffered = true;
			ResizeRedraw = true;
		}
	}
}
