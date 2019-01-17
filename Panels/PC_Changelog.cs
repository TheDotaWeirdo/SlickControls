using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlickControls.Classes;
using Extensions;
using SlickControls.Controls;
using System.Drawing.Drawing2D;

namespace SlickControls.Panels
{
	public partial class PC_Changelog : PanelContent
	{
		private IEnumerable<VersionInfo> VerInfo;
		private VersionInfo Current;

		public PC_Changelog(IEnumerable<string> changelog, string currentVersion)
		{
			InitializeComponent();
			VerInfo = VersionInfo.GenerateInfo(changelog);
			Current = VerInfo.FirstThat(x => x.Version.ToString() == currentVersion);

			foreach (var item in VerInfo.Where(x => Current == null || x != Current).Distinct((x, y) => x.Version.Major == y.Version.Major && x.Version.Minor == y.Version.Minor))
				AddVersion(item);

			if (Current != null)
				AddVersion(VerInfo.FirstThat(x => x.Version.ToString() == currentVersion), "Current Version");

			DesignChanged(FormDesign.Design);
		}

		private void AddVersion(VersionInfo versionInfo, string text = null)
		{
			var M = versionInfo.Version.Major;
			var m = versionInfo.Version.Minor;
			var vers = VerInfo.Where(x => x.Version.Major == M && x.Version.Minor == m);

			var st = new SlickTile()
			{
				Dock = DockStyle.Top,
				DrawLeft = false,
				Font = new Font("Nirmala UI", 9.75F),
				IconSize = 16,
				Image = Properties.Resources.ArrowRight,
				Padding = new Padding(10),
				Size = new Size(175, 45),
				TabStop = false,
				Text = text.IfNull(vers.Count() == 1 ? $"v {versionInfo.Version}" : $"v {M}.{m}.{vers.Min(x => x.Version.Build)} → {M}.{m}.{vers.Max(x => x.Version.Build)}"),

				Selected = text != null,
				Tag = text != null ? null : versionInfo
			};

			st.Click += Tile_Click;

			P_LeftTabs.Controls.Add(st);

			if (text != null)
				Tile_Click(st, null);
		}

		private void Tile_Click(object sender, EventArgs e)
		{
			var inf = (VersionInfo)(sender as Control).Tag;

			P_VersionInfo.SuspendDrawing();
			P_VersionInfo.Controls.Clear();
			if (inf == null)
			{
				if (Current != null)
					P_VersionInfo.Controls.Add(new ChangeLogVersion(Current));
			}
			else
			{
				foreach (var item in VerInfo.Where(x => x.Version.Major == inf.Version.Major && x.Version.Minor == inf.Version.Minor))
					P_VersionInfo.Controls.Add(new ChangeLogVersion(item));
			}
			P_LeftTabs.Controls.ThatAre<SlickTile>().Foreach(x => x.Selected = x == sender);
			P_VersionInfo.ResumeDrawing();
		}

		private void P_Spacer_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(FormDesign.Design.BackColor);
			e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.AccentColor), 0, 0, 1, P_Spacer.Height - 150);

			e.Graphics.FillRectangle(new LinearGradientBrush(
				new RectangleF(0, P_Spacer.Height - 175, 1, 150),
				FormDesign.Design.AccentColor,
				FormDesign.Design.BackColor,
				90),
				new RectangleF(0, P_Spacer.Height - 175, 1, 150));
		}

		private void PC_Changelog_Resize(object sender, EventArgs e)
		{
			P_VersionInfo.MaximumSize = new Size(panel2.Width, 9999);
			P_VersionInfo.MinimumSize = new Size(panel2.Width, 0);

			P_LeftTabs.MaximumSize = new Size(panel1.Width, 9999);
			P_LeftTabs.MinimumSize = new Size(panel1.Width, 0);
		}

		private void P_Spacer_2_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(FormDesign.Design.BackColor);
			e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.AccentColor), 0, 0, P_Spacer_2.Width - 150, 1);

			e.Graphics.FillRectangle(new LinearGradientBrush(
				new RectangleF(P_Spacer_2.Width - 175, 0, 150, 1),
				FormDesign.Design.AccentColor,
				FormDesign.Design.BackColor,
				0F),
				new RectangleF(P_Spacer_2.Width - 175, 0, 150, 1));
		}
	}
}
