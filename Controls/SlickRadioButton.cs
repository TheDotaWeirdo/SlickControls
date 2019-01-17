using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace SlickControls.Controls
{
	[DefaultEvent("CheckChanged")]
	public partial class SlickRadioButton : SlickLabel
	{
		public SlickRadioButton()
		{
			InitializeComponent();
			Click += (s, e) => Checked = !Checked;
			Cursor = System.Windows.Forms.Cursors.Hand;
			Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
		}

		public EventHandler CheckChanged;
		private bool @checked;
		private DisableIdentifier checkIdentifier = new DisableIdentifier();

		[Browsable(false)]
		public object Data { get; set; }

		[Category("Appearance")]
		public bool Checked
		{
			get => @checked;
			set
			{
				if (@checked != value && !checkIdentifier.Disabled)
				{
					@checked = value;
					checkIdentifier.Disable();
					CheckChanged?.Invoke(this, new EventArgs());
					checkIdentifier.Enable();
				}
				else
					@checked = value;

				if (checkIdentifier.Disabled)
					return;

				if (@checked && RadioGroup != null)
					foreach (var item in RadioGroup.Where(x => x != this && x.Checked))
						item.Checked = false;

				Image = @checked ? Properties.Resources.Tiny_Circle_Filled : Properties.Resources.Tiny_Circle_Empty;
			}
		}

		public IEnumerable<SlickRadioButton> RadioGroup
		{
			get
			{
				if (CustomGroup?.Any() ?? false)
					return CustomGroup;

				return Parent.Controls.ThatAre<SlickRadioButton>();
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IEnumerable<SlickRadioButton> CustomGroup { get; set; }
	}

	public static class SlickRadiobuttonExtensions
	{
		public static bool GroupChecked(this IEnumerable<SlickRadioButton> group)
			=> group.Any(x => x.Checked);

		public static object GetSelectedData(this IEnumerable<SlickRadioButton> group)
			=> group.FirstThat(x => x.Checked)?.Data;
	}
}
