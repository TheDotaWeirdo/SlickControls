using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickControls.Classes
{
	public interface IValidationControl
	{
		bool ValidInput { get; }
		bool Required { get; set; }
		bool Visible { get; set; }

		void SetError(bool warning = false);
	}
}
