﻿using Extensions;
using SlickControls.Classes;
using System;
using System.ComponentModel;

namespace SlickControls.Controls
{
	[DefaultEvent("CheckChanged")]
	public partial class SlickCheckbox : SlickLabel, ISupportsReset
	{
		private bool @checked;

		private string checkedText;

		private string uncheckedText;
		private bool _useToggleIcon = true;

		public SlickCheckbox()
		{
			InitializeComponent();
		}

		public event EventHandler CheckChanged;

		[Category("Appearance"), DefaultValue(true), DisplayName("Use Toggle Icon")]
		public bool UseToggleIcon { get => _useToggleIcon; set { _useToggleIcon = value; Checked = Checked; } }

		[Category("Behavior")]
		public bool Checked
		{
			get => @checked;
			set
			{
				var chkChanged = @checked == !value;
				@checked = value;

				if (UseToggleIcon)
					Image = @checked ? Properties.Resources.Tiny_ToggleOn : Properties.Resources.Tiny_ToggleOff;
				else
					Image = @checked ? Properties.Resources.Tiny_Checked : Properties.Resources.Tiny_Unchecked;

				if (!string.IsNullOrEmpty(CheckedText))
					Text = @checked ? CheckedText : UncheckedText.IfEmpty(CheckedText);

				if (DefaultValue == null)
					DefaultValue = value;

				if (chkChanged)
					CheckChanged?.Invoke(this, new EventArgs());
			}
		}

		[Category("Behavior"), DefaultValue(null)]
		public bool? DefaultValue { get; set; } = null;

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

		public void ResetValue()
			=> Checked = DefaultValue ?? true;

		private void SlickCheckbox_Click(object sender, EventArgs e)
		{
			Checked = !Checked;
		}
	}
}