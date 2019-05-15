using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Extensions;
using SlickControls.Classes;
using SlickControls.Enums;

namespace SlickControls.Controls
{
	[DefaultEvent("TextChanged")]
	public partial class SlickTextBox : SlickControl, IValidationControl, ISupportsReset
	{
		[EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new event EventHandler TextChanged;

		[Category("Action")]
		public event EventHandler IconClicked;

		public Func<string, bool> ValidationCustom;

		private string labelText = "Textbox";

		private string placeholder;

		private bool showLabel = true;

		public SlickTextBox()
		{
			InitializeComponent();

			label.Click += (s, e) => TB.Focus();
			TB.TextChanged += TB_TextChanged;
			TB.Enter += TB_Enter;
			TB.Leave += TB_Leave;
		}

		[Category("Appearance")]
		public Image Image
		{
			get => PB.Image;
			set
			{
            PB.TryInvoke(() =>
            {
               PB.Image = value.Color(FormDesign.Design.IconColor);
               TLP.ColumnStyles[1].Width = (PB.Visible = value != null) ? 20 : 0;
            });
			}
		}

		[Category("Behavior")]
		public bool Password { get => TB.UseSystemPasswordChar; set => TB.UseSystemPasswordChar = value; }

		[Category("Behavior")]
		public bool ReadOnly { get => TB.ReadOnly; set => TB.ReadOnly = value; }

		[Category("Behavior")]
		public bool Required { get; set; }

		[Category("Behavior"), DisplayName("Select All On Focus")]
		public bool SelectAllOnFocus { get; set; }

		[Category("Behavior")]
		public int MaxLength { get => TB.MaxLength; set => TB.MaxLength = value; }

		[Category("Appearance"), DisplayName("Label Text"), DefaultValue("Textbox")]
		public string LabelText { get => labelText; set => label.Text = labelText = value; }

		[Category("Appearance")]
		public string Placeholder { get => placeholder; set => placeholder = L_Placerholder.Text = value; }

		[Browsable(false)]
		public string SelectedText { get => TB.SelectedText; set => TB.SelectedText = value; }

		[Browsable(false)]
		public int SelectionLength { get => TB.SelectionLength; set => TB.SelectionLength = value; }

		[Browsable(false)]
		public int SelectionStart { get => TB.SelectionStart; set => TB.SelectionStart = value; }

		public new bool Focused => TB.Focused;

		[Category("Behavior"), DisplayName("Show Text"), DefaultValue(true)]
		public bool ShowLabel
		{
			get => showLabel;
			set
			{
				label.Visible = showLabel = value;
				MinimumSize = new Size(MinimumSize.Width, value ? 35 : 21);
				MaximumSize = new Size(MaximumSize.Width, value ? 35 : 21);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override string Text { get => base.Text; set { TB.Text = base.Text = value; if (DefaultValue != null) DefaultValue = value; } }

		[Category("Appearance")]
		public HorizontalAlignment TextAlign { get => TB.TextAlign; set => TB.TextAlign = value; }

		[Category("Behavior")]
		public virtual ValidationType Validation { get; set; } = ValidationType.None;

		[Category("Behavior"), DefaultValue(null)]
		public string DefaultValue { get; set; } = null;

		[Category("Behavior"), DisplayName("Regex Validation")]
		public string ValidationRegex { get; set; } = "";

		public virtual bool ValidInput
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(TB.Text))
					switch (Validation)
					{
						case ValidationType.Number:
							return TB.Text.All(char.IsDigit);

						case ValidationType.Decimal:
							return decimal.TryParse(TB.Text, out var d);

						case ValidationType.Regex:
							return string.IsNullOrWhiteSpace(ValidationRegex) || Regex.IsMatch(TB.Text, ValidationRegex);

						case ValidationType.Custom:
							return ValidationCustom == null || ValidationCustom(TB.Text);

						default:
							return true;
					}

				return !Required;
			}
		}

		public new void Select() => TB.Select();

		public void Select(int start, int length) => TB.Select(start, length);

		public void SelectAll() => TB.SelectAll();

		public void ResetValue() => Text = DefaultValue;

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			MinimumSize = new Size(MinimumSize.Width, ShowLabel ? 34 : 20);
			MaximumSize = new Size(MaximumSize.Width, ShowLabel ? 34 : 20);
			TLP.ColumnStyles[1].Width = (PB.Visible = Image != null) ? 20 : 0;
		}

		protected override void DesignChanged(FormDesign design)
		{
			label.ForeColor = design.LabelColor;
			L_Placerholder.ForeColor = design.InfoColor;
			TB.ForeColor = design.ForeColor;
			PB.Color(FormDesign.Design.IconColor);
			P_Bar.TryInvoke(() => P_Bar.BackColor = TB.Focused ? design.ActiveColor : design.AccentColor);
		}

		private void SlickTextBox_BackColorChanged(object sender, EventArgs e)
			=> TB.BackColor = BackColor;

		private void TB_Enter(object sender, EventArgs e)
		{
			P_Bar.BackColor = FormDesign.Design.ActiveColor;
		}

		private void TB_Leave(object sender, EventArgs e)
		{
			P_Bar.BackColor = FormDesign.Design.AccentColor;
		}

		private void TB_TextChanged(object sender, EventArgs e)
		{
			if (TB.Text != "")
				switch (Validation)
				{
					case ValidationType.Number:
						if (TB.Text.All(char.IsDigit))
						{ Text = TB.Text; TextChanged?.Invoke(this, e); }
						else
							TB.Text = TB.Text.Where(char.IsDigit);
						break;

					case ValidationType.Decimal:
						if (!ValidInput)
							TB.Text = Regex.Match(TB.Text, @"\d+\.?(\d+)?").Value;
						else
						{ Text = TB.Text; TextChanged?.Invoke(this, e); }
						break;

					case ValidationType.Custom:
						Text = TB.Text;
						TextChanged?.Invoke(this, e);
						break;

					case ValidationType.Regex:
						Text = TB.Text;
						if (Regex.IsMatch(TB.Text, ValidationRegex))
							TextChanged?.Invoke(this, e);
						break;

					default:
						{ Text = TB.Text; TextChanged?.Invoke(this, e); }
						break;
				}
			else
			{ Text = TB.Text; TextChanged?.Invoke(this, e); }

			L_Placerholder.Visible = TB.Text == "";
		}

		private void L_Placerholder_Click(object sender, EventArgs e)
		{
			TB.Focus();
		}

		private void PB_Click(object sender, EventArgs e)
		{
			IconClicked?.Invoke(this, e);
		}

		private void SlickTextBox_Load(object sender, EventArgs e)
		{
			if (TB.Focused)
				P_Bar.BackColor = FormDesign.Design.ActiveColor;
		}

		public void SetError(bool warning = false)
		{
			P_Bar.BackColor = warning ? FormDesign.Design.YellowColor : FormDesign.Design.RedColor;
		}
	}
}