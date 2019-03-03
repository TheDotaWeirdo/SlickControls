using Extensions;
using System;
using System.ComponentModel;

namespace SlickControls.Controls
{
	[DefaultEvent("CheckChanged")]
	public partial class SlickCheckbox : SlickLabel
	{
		private bool @checked;

		private string checkedText;

		private string uncheckedText;

		public SlickCheckbox()
		{
			InitializeComponent();
		}

		public event EventHandler CheckChanged;

		[Category("Behavior")]
		public bool Checked
		{
			get => @checked;
			set
			{
				var chkChanged = @checked == !value;
				@checked = value;

				Image = @checked ? Properties.Resources.Tiny_ToggleOn : Properties.Resources.Tiny_ToggleOff;
				if (!string.IsNullOrEmpty(CheckedText))
					Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText);

				if (chkChanged)
					CheckChanged?.Invoke(this, new EventArgs());
			}
		}

		[Category("Appearance"), DisplayName("Checked Text")]
		public string CheckedText
		{
			get => checkedText;
			set
			{
				checkedText = value;
				if (!string.IsNullOrEmpty(value))
					Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText);
			}
		}

		[Category("Appearance"), DisplayName("Unchecked Text")]
		public string UncheckedText
		{
			get => uncheckedText;
			set
			{
				uncheckedText = value;
				if (!string.IsNullOrEmpty(value))
					Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText);
			}
		}

		private void SlickCheckbox_Click(object sender, EventArgs e)
		{
			Checked = !Checked;
		}
	}
}