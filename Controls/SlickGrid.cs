using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Controls
{
	public partial class SlickGrid : DataGridView
	{
		public SlickGrid()
		{
			InitializeComponent();

			if (DesignMode)
				DesignChanged(FormDesign.Design);

			FormDesign.DesignChanged += DesignChanged;
			Disposed += (s,e) => FormDesign.DesignChanged -= DesignChanged;
		}

		private void DesignChanged(FormDesign design)
		{
			BackgroundColor = GridColor = design.BackColor;

			ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
			{
				BackColor = design.MenuColor,
				Font = new Font("Nirmala UI", 9.75F),
				ForeColor = design.MenuForeColor,
				SelectionBackColor = design.MenuColor,
				SelectionForeColor = design.MenuForeColor,
				Alignment = DataGridViewContentAlignment.MiddleCenter
			};

			RowsDefaultCellStyle = new DataGridViewCellStyle()
			{
				BackColor = design.ButtonColor.MergeColor(design.BackColor),
				Font = new Font("Nirmala UI", 8.25F),
				ForeColor = design.ButtonForeColor,
				SelectionBackColor = design.ActiveColor,
				SelectionForeColor = design.ActiveForeColor,
				Alignment = DataGridViewContentAlignment.MiddleLeft
			};
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			BorderStyle = BorderStyle.None;
			CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			ColumnHeadersHeight = 28;
			EnableHeadersVisualStyles = false;
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			RowHeadersVisible = false;

			if (!DesignMode)
				DesignChanged(FormDesign.Design);
		}
	}
}
