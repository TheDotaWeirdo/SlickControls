using Extensions;
using System;

namespace SlickControls.Controls
{
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

		public bool Checked
		{
			get => @checked;
			set
			{
				var chkChanged = @checked = !value;
				@checked = value;

				Image = @checked ? Properties.Resources.Tiny_ToggleOn : Properties.Resources.Tiny_ToggleOff;
				Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText);

				if (chkChanged)
					CheckChanged?.Invoke(this, new EventArgs());
			}
		}

		public string CheckedText
		{
			get => checkedText;
			set { checkedText = value; Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText); }
		}

		public string UncheckedText
		{
			get => uncheckedText;
			set { uncheckedText = value; Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText); }
		}

		private void SlickCheckbox_Click(object sender, EventArgs e)
		{
			Checked = !Checked;
		}
	}
}