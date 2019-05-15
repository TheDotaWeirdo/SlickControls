using Extensions;
using SlickControls.Enums;
using SlickControls.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SlickControls.Controls
{
    public partial class SlickDateTime : SlickTextBox
    {
        private DateType dateType;
        private bool disableChange = false;

        private int lastIndex = 0;

        public SlickDateTime()
        {
            InitializeComponent();
            TB.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            TB.PromptChar = '-';
            TB.PreviewKeyDown += TB_PreviewKeyDown;
            TB.Enter += TB_Enter;
            TB.TextChanged += TB_TextChanged;
        }

        [Category("Design"), DisplayName("Date Type")]
        public DateType DateType
        {
            get => dateType;
            set
            {
                dateType = value;
                switch (value)
                {
                    case DateType.DateTime:
                        TB.Mask = @"00 \/ 00 \/ 0000  \a\t  00\:00";
                        SlickTip.SetTo(PB, "Set value to Now");
                        break;

                    case DateType.Time:
                        TB.Mask = @"00\:00";
                        SlickTip.SetTo(PB, "Set value to Now");
                        break;

                    default:
                        TB.Mask = @"00 \/ 00 \/ 0000";
                        SlickTip.SetTo(PB, "Set value to Today");
                        break;
                }
            }
        }

        [Category("Behavior")]
        public new DateTime? DefaultValue { get; set; }

        [Category("Behavior")]
        public DateTime MaximumValue { get; set; } = DateTime.MaxValue;

        [Category("Behavior")]
        public DateTime MinimumValue { get; set; } = DateTime.MinValue;

        public override bool ValidInput => Value != null;

        public DateTime? Value
        {
            get
            {
                try
                {
                    var dateMatch = Regex.Match(TB.Text, @"(\d{2}) / (\d{2}) / (\d{4})");
                    var timeMatch = Regex.Match(TB.Text, @"(\d{2}):(\d{2})");

                    var d = dateMatch.Groups[1].Value.SmartParse(DefaultValue?.Day ?? 0);
                    var M = dateMatch.Groups[2].Value.SmartParse(DefaultValue?.Month ?? 0);
                    var y = dateMatch.Groups[3].Value.SmartParse(DefaultValue?.Year ?? 0);
                    var h = timeMatch.Groups[1].Value.SmartParse(DefaultValue?.Hour ?? 0);
                    var m = timeMatch.Groups[2].Value.SmartParse(DefaultValue?.Minute ?? 0);

                    switch (DateType)
                    {
                        case DateType.Date:
                            return new DateTime(y, M, d);
                        case DateType.DateTime:
                            return new DateTime(y, M, d, h, m, 0);
                        case DateType.Time:
                            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, h, m, 0);
                        default:
                            return DefaultValue;
                    }
                }
                catch { }
                return null;
            }
            set
            {
                switch (DateType)
                {
                    case DateType.Date:
                        TB.Text = value == null ? "" :
                         value.Value.Day.ToString("00") +
                         value.Value.Month.ToString("00") +
                         value.Value.Year.ToString("0000");
                        break;
                    case DateType.DateTime:
                        TB.Text = value == null ? "" :
                         value.Value.Day.ToString("00") +
                         value.Value.Month.ToString("00") +
                         value.Value.Year.ToString("0000") +
                         value.Value.Hour.ToString("00") +
                         value.Value.Minute.ToString("00");
                        break;
                    case DateType.Time:
                        TB.Text = value == null ? "" :
                         value.Value.Hour.ToString("00") +
                         value.Value.Minute.ToString("00");
                        break;
                    default:
                        break;
                }
            }
        }

        private void SlickDateTime_IconClicked(object sender, EventArgs e)
        {
            Value = DateType == DateType.Date ? DateTime.Today : DateTime.Now;
        }

        private void TB_Enter(object sender, EventArgs e)
        {
            if (!TB.Text.Any(char.IsDigit))
                BeginInvoke(new Action(() => TB.SelectionStart = 0));
        }

        private void TB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = TB.SelectionStart;

            if (e.KeyData.IsDigit() && !Text.Contains(TB.PromptChar))
            {
                if (TB.SelectionStart == TB.Text.Length)
                {
                    TB.SelectionStart = 0;
                    return;
                }

                disableChange = true;
                if (TB.SelectionLength == 0 && TB.SelectionStart < TB.Text.Length)
                {
                    var ind = TB.SelectionStart;
                    for (; ind < TB.Text.Length && !char.IsDigit(TB.Text[ind]); ind++) ;
                    if (ind < TB.Text.Length)
                    {
                        Text = (TB.Text.Substring(0, ind) + TB.Text.Substring(ind + 1)).Where(Char.IsDigit);
                        BeginInvoke(new Action(() => TB.SelectionStart = ind));
                    }
                }
                else if (TB.SelectionLength > 0 && TB.SelectedText.Count(char.IsDigit) > 1)
                {
                    var ind = TB.SelectionStart;
                    Text = TB.Text.Remove(ind, TB.SelectionLength).Insert(ind, "0".Copy(TB.SelectedText.Count(char.IsDigit) - 1)).Where(char.IsDigit);
                    BeginInvoke(new Action(() => TB.SelectionStart = ind));
                }
                disableChange = false;
            }
        }

        private void TB_TextChanged(object sender, EventArgs e)
        {
            if (disableChange)
                return;

            disableChange = true;
            var match = Regex.Match(TB.Text, @"(\d{2}) / (\d{2})");

            if (match.Success)
            {
                try
                {
                    var d = match.Groups[1].Value.SmartParse();
                    var m = match.Groups[2].Value.SmartParse();

                    if (m > 12)
                    {
                        var txt = TB.Text.Where(char.IsDigit);
                        Text = d.ToString("00") + 12 + txt.Substring(4);
                        BeginInvoke(new Action(() => TB.SelectionStart = 7));
                    }
                }
                catch { }
            }

            match = Regex.Match(TB.Text, @"(\d{2}) / (\d{2}) / (\d{4})");

            if (match.Success && lastIndex >= 13)
            {
                try
                {
                    var d = match.Groups[1].Value.SmartParse();
                    var m = match.Groups[2].Value.SmartParse();
                    var y = match.Groups[3].Value.SmartParse();

                    var days = DateTime.DaysInMonth(y, m);

                    if (d > days)
                    {
                        var txt = TB.Text.Where(char.IsDigit);
                        Text = days.ToString("00") + m.ToString("00") + y.ToString("0000") + txt.Substring(8);
                        BeginInvoke(new Action(() => TB.SelectionStart = lastIndex + 1));
                    }
                }
                catch { }
            }

            match = Regex.Match(TB.Text, @"(\d{2}):(\d{2})?");

            if (match.Success)
            {
                try
                {
                    var h = match.Groups[1].Value.SmartParse();
                    var m = match.Groups[2].Value.SmartParse();

                    if (h > 23 || m > 59)
                    {
                        Text = TB.Text.Replace(match.Value, (Math.Min(h, 23).ToString("00") + ":" + Math.Min(m, 59).ToString("00")).Substring(0, match.Length));
                        BeginInvoke(new Action(() => TB.SelectionStart = lastIndex + 1));
                    }
                }
                catch { }
            }

            disableChange = false;
        }
    }
}