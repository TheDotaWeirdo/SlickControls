using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlickControls.Panels
{

	[DefaultEvent("OnClick")]
	public class PanelItem : Component
	{
		public string Text { get; set; }
		public Bitmap Icon { get; set; }
		public bool Selected { get; set; }
		public string Group { get; set; }
		public bool ForceReopen { get; set; }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Bindable(true)]
		public event MouseEventHandler OnClick;

		internal void MouseClick(MouseEventArgs e) => OnClick?.Invoke(this, e);

		public override string ToString() => $"[{Group}] {Text}";

		public static PanelItem Empty = new PanelItem();
	}
}
