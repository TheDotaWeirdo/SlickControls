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

namespace SlickControls.Forms
{
	public interface ISlickForm
	{
		bool CloseForm { get; set; }
		Image FormIcon { get; set; }
		Rectangle IconBounds { get; set; }
		FormState CurrentFormState { get; set; }
	}
}
