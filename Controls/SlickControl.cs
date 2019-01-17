using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public class SlickControl : UserControl
	{
		public SlickControl()
		{
			FormDesign.DesignChanged += DesignChanged;
			Disposed += (s, e) => FormDesign.DesignChanged -= DesignChanged;
		}

		protected virtual void DesignChanged(FormDesign design) { }

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			if (!DesignMode)
				DesignChanged(FormDesign.Design);
		}
	}
}
