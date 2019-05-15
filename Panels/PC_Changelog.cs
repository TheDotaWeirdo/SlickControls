﻿using System;
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
using System.Reflection;
using System.IO;

namespace SlickControls.Panels
{
	public partial class PC_Changelog : PanelContent
	{
		private VersionChangeLog Current;
		private VersionChangeLog[] ChangeLogs;

		public PC_Changelog(Assembly assembly, string resourceName, Version currentVersion)
		{
			InitializeComponent();

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			using (StreamReader reader = new StreamReader(stream))
				ChangeLogs = Newtonsoft.Json.JsonConvert.DeserializeObject<VersionChangeLog[]>(reader.ReadToEnd());

			Current = ChangeLogs.FirstThat(x => x.Version == currentVersion);

			foreach (var grp in ChangeLogs
				.Where(x => Current == null || x != Current)
				.Distinct((x, y) => x.Version.Major == y.Version.Major && x.Version.Minor == y.Version.Minor)
				.OrderBy(x => x.Version)
				.GroupBy(x => x.Version.Major))
			{
				foreach (var item in grp)
					AddVersion(item);

				P_LeftTabs.Controls.Add(new Panel() { Dock = DockStyle.Top, Height = 20 });
			}

			if (Current != null)
				AddVersion(Current, "Current Version");
		}

		protected override void DesignChanged(FormDesign design)
		{
			base.DesignChanged(design);

			base_Text.BackColor =
			TLP_Mainzs.BackColor = design.BackColor.Tint(Lum: design.Type.If(FormDesignType.Dark, 3, -3));
			panel2.BackColor = design.BackColor;
			P_Spacer.BackColor = design.AccentColor;
		}

		private void AddVersion(VersionChangeLog versionInfo, string text = null)
		{
			var M = versionInfo.Version.Major;
			var m = versionInfo.Version.Minor;
			var vers = ChangeLogs.Where(x => x.Version.Major == M && x.Version.Minor == m);

			var st = new SlickTile()
			{
				Dock = DockStyle.Top,
				DrawLeft = false,
				Font = new Font("Nirmala UI", 9.75F),
				IconSize = 16,
				Image = Properties.Resources.ArrowRight,
				Padding = new Padding(10),
				Margin = new Padding(0),
				Size = new Size(175, 30),
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
			var inf = (VersionChangeLog)(sender as Control).Tag;

			P_VersionInfo.SuspendDrawing();
			P_VersionInfo.Controls.Clear();
			if (inf == null)
			{
				if (Current != null)
					P_VersionInfo.Controls.Add(new ChangeLogVersion(Current));
			}
			else
			{
				foreach (var item in ChangeLogs.Where(x => x.Version.Major == inf.Version.Major && x.Version.Minor == inf.Version.Minor))
					P_VersionInfo.Controls.Add(new ChangeLogVersion(item));
			}
			P_LeftTabs.Controls.ThatAre<SlickTile>().Foreach(x => x.Selected = x == sender);
			P_VersionInfo.ResumeDrawing();
		}

		private void PC_Changelog_Resize(object sender, EventArgs e)
		{
			P_VersionInfo.MaximumSize = new Size(panel2.Width, 9999);
			P_VersionInfo.MinimumSize = new Size(panel2.Width, 0);

			P_LeftTabs.MaximumSize = new Size(panel1.Width, 9999);
			P_LeftTabs.MinimumSize = new Size(panel1.Width, 0);
		}
	}
}
