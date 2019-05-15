using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlickControls.Controls;

namespace SlickControls.Classes
{
	public static class FormValidation
	{
		public static bool CheckValidation(this Control ctrl)
		{
			var b = true;

			if (ctrl is IValidationControl tb)
			{
				if (tb.Required && tb.Visible)
					b = tb.ValidInput;

				if (!b)
					tb.SetError();
			}

			foreach (Control item in ctrl.Controls)
				b = b & CheckValidation(item);

			return b;
		}

		public static void ClearForm(this Control ctrl)
		{
			if (ctrl is ISupportsReset sr)
				sr.ResetValue();

			foreach (Control item in ctrl.Controls)
				ClearForm(item);
		}
	}
}
