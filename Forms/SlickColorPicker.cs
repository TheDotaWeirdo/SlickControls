using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using MechanikaDesign.WinForms.UI.ColorPicker;
using SlickControls.Controls;

namespace SlickControls.Forms
{
	public partial class SlickColorPicker : Form
	{
		public Color Color => Color.FromArgb(255, colorRgb);

		#region Fields

		private HslColor colorHsl = HslColor.FromAhsl(0xff);
		private Color colorRgb = Color.Empty;
		private Color originColor = Color.Empty;
		private bool lockUpdates = false;
		private List<Color> LastColors;

		#endregion

		public event EventHandler ColorChanged;

		public SlickColorPicker(Color color)
		{
			InitializeComponent();

			TB_Hex.ValidationCustom = x => Regex.IsMatch(x, @"#?([a-f]|[0-9]){6}", RegexOptions.IgnoreCase);

			ISave.Load(out LastColors, "LastColors.tf", "Shared");
			LastColors = LastColors.Take(21).ToList();
			ShowLastColors();

			originColor = color;
			SetColor(color.If(Color.Empty, Color.Black));

			BackColor = FormDesign.Design.ActiveColor;
			tableLayoutPanel1.BackColor = FormDesign.Design.BackColor;

			ColorChanged += SlickColorPicker_ColorChanged;
		}

		private void SlickColorPicker_ColorChanged(object sender, EventArgs e)
		{
			this.TryInvoke(() => ShowLastColors(true));
		}

		private void ShowLastColors(bool incremental = false)
		{
			if (!incremental)
			{
				FLP_LastColors.Controls.Clear();
				foreach (var color in LastColors)
					AddColor(color);
			}
			else 
			{
				if (LastColors.Any(x => x == Color))
					LastColors.RemoveAll(x => x == Color);

				foreach (var item in FLP_LastColors.Controls.Where(x => x.BackColor == Color))
					FLP_LastColors.Controls.Remove(item);

				if (FLP_LastColors.Controls.Count >= 21)
					FLP_LastColors.Controls.RemoveAt(0);

				LastColors.Insert(0, Color);
				AddColor(LastColors[0]);
			}
		}

		private void AddColor(Color color)
		{
			var ctrl = new Panel() { Size = new Size(28, 28), BackColor = color, Cursor = Cursors.Hand, Margin = new Padding(4) };
			ctrl.Paint += colorPreview_Paint;
			ctrl.Click += (s, e) => SetColor(color);
			FLP_LastColors.Controls.Add(ctrl);
			ctrl.Refresh();
		}

		private void RGB_TextChanged(object sender, EventArgs e)
		{
			(sender as SlickTextBox).Text = (sender as SlickTextBox).Text.SmartParse().Between(0, 255).ToString();
			if (!lockUpdates)
				SetColor(Color.FromArgb(TB_Red.Text.SmartParse(), TB_Green.Text.SmartParse(), TB_Blue.Text.SmartParse()));
		}

		private void HSL_TextChanged(object sender, EventArgs e)
		{
			(sender as SlickTextBox).Text = (sender as SlickTextBox).Text.SmartParse().Between(0, sender == TB_Hue ? 360 : 100).ToString();
			if (!lockUpdates)
				SetColor(HslColor.FromAhsl(TB_Hue.Text.SmartParse() / 360D, TB_Sat.Text.SmartParse() / 100D, TB_Lum.Text.SmartParse() / 100D).RgbValue);
		}

		private void TB_Hex_TextChanged(object sender, EventArgs e)
		{
			if (!lockUpdates && TB_Hex.ValidInput)
			{
				var grps = Regex.Match(TB_Hex.Text.ToLower(), @"#((?:[a-f]|[0-9]){2})((?:[a-f]|[0-9]){2})((?:[a-f]|[0-9]){2})", RegexOptions.IgnoreCase).Groups;
				SetColor(Color.FromArgb(
					int.Parse(grps[1].Value, System.Globalization.NumberStyles.HexNumber),
					int.Parse(grps[2].Value, System.Globalization.NumberStyles.HexNumber),
					int.Parse(grps[3].Value, System.Globalization.NumberStyles.HexNumber)));
			}
		}

		private void SetColor(Color color, bool changeSlider = true)
		{
			lockUpdates = true;

			colorHsl = HslColor.FromColor(color);
			colorRgb = color;

			if (changeSlider)
			{
				colorSlider.ColorRGB = colorRgb;
				colorBox2D.ColorRGB = colorRgb;
			}

			colorPreview.BackColor = colorRgb;
			TB_Hex.Text = ColorTranslator.ToHtml(colorRgb);

			TB_Red.Text = colorRgb.R.ToString();
			TB_Green.Text = colorRgb.G.ToString();
			TB_Blue.Text = colorRgb.B.ToString();

			TB_Hue.Text = ((int)(colorHsl.H * 360D)).ToString();
			TB_Sat.Text = ((int)(colorHsl.S * 100D)).ToString();
			TB_Lum.Text = ((int)(colorHsl.L * 100D)).ToString();
			
			lockUpdates = false;

			WaitIdentifier.Wait(() => ColorChanged?.Invoke(this, new EventArgs()), 250);
		}

		private WaitIdentifier WaitIdentifier = new WaitIdentifier();
		private void colorBox2D_ColorChanged(object sender, ColorChangedEventArgs args)
		{
			if (sender == colorSlider)
				SetColor(HslColor.FromAhsl(colorSlider.ColorHSL.H, colorHsl.S, colorHsl.L).RgbValue);
			else if (sender == colorBox2D)
				SetColor(colorBox2D.ColorRGB, false);
		}

		private void B_Confirm_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();

			ISave.Load(out List<Color> colors, "LastColors.tf", "Shared");
			colors.Insert(0, Color);
			ISave.Save(colors.Take(21), "LastColors.tf", appName: "Shared");
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			SetColor(originColor);
			DialogResult = DialogResult.Cancel;
			Close();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{ B_Confirm_Click(null, null); return true; }

			if (keyData == Keys.Escape)
			{ B_Cancel_Click(null, null); return true; }

			return	base.ProcessCmdKey(ref msg, keyData);
		}

		private void colorPreview_Paint(object sender, PaintEventArgs e)
		{
			var size = (sender as Control).Size;
			var color = (sender as Control).BackColor;
			if (color == null)
				return;

			e.Graphics.Clear(FormDesign.Design.BackColor);
			e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(1, 1, size.Width - 3, size.Height - 3));
			e.Graphics.DrawRectangle(new Pen(Color.FromArgb(175, ExtensionClass.ColorFromHSL(color.GetHue(), color.GetSaturation(), (1D - color.GetBrightness()).Between(.2, .8))), 1), new Rectangle(0, 0, size.Width - 3, size.Height - 3));
		}
	}
}
