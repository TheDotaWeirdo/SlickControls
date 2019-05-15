using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlickControls.Forms;
using Extensions;
using System.Media;

namespace SlickControls.Controls
{
	public partial class SlickDropdown : SlickTextBox
	{
		private object[] _items;

		private DropDownItems DropDownItems;

		public SlickDropdown()
		{
			InitializeComponent();

			TB.TextChanged += TB_TextChanged;
			TB.Leave += TB_Leave;
			TB.MouseWheel += TB_MouseWheel;
			TB.KeyPress += TB_KeyPress;
			TB.MouseDoubleClick += TB_MouseDoubleClick;
		}

		protected override void DesignChanged(FormDesign design)
		{
			base.DesignChanged(design);

			if (!DesignMode && (Items?.Length ?? 0) == 0)
				Image = FormDesign.Loader;
		}

		private void TB_MouseWheel(object sender, MouseEventArgs e)
		{
			if (SelectedItem != null && !ReadOnly)
			{
				if (e.Delta > 0)
					Text = Items[Math.Max(0, Items.ToList().IndexOf(SelectedItem) - 1)].If(x => Conversion == null, x => x.ToString(), x => Conversion(x));
				else if (e.Delta < 0)
					Text = Items[Math.Min(Items.Length - 1, Items.ToList().IndexOf(SelectedItem) + 1)].If(x => Conversion == null, x => x.ToString(), x => Conversion(x));
			}
		}

		[Browsable(true)]
		public new event EventHandler TextChanged;

		[Category("Data")]
		public Func<object, string> Conversion { get; set; }

		[Category("Data")]
		public object[] Items { get => _items; set { _items = value; Image = Properties.Resources.ArrowDown; } }

		public object SelectedItem
		{
			get
			{
				return Items?.FirstOrDefault(x => Text == (Conversion == null ? x.ToString() : Conversion(x)));
			}
			set
			{
				Text = value == null ? "" : Conversion == null ? value.ToString() : Conversion(value);
			}
		}
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		public override string Text { get => base.Text; set { base.Text = TB.Text = value; TextChanged?.Invoke(this, new EventArgs()); } }

		public override bool ValidInput
		{
			get
			{
				if (Required && Items != null && Items.Any() && Validation == Enums.ValidationType.None)
					return SelectedItem != null;

				return base.ValidInput;
			}
		}

		private void ActiveDropDown_Load(object sender, EventArgs e)
		{
			if (!DesignMode && (Items?.Length ?? 0) == 0)
				Image = FormDesign.Loader;

			var frm = FindForm();
			if (frm != null)
			{
				LocationChanged += (s, ea) =>
				{
					if (DropDownItems != null)
						DropDownItems.Location = PointToScreen(new Point(0, P_Bar.Location.Y));
				};

				frm.LocationChanged += (s, ea) =>
				{
					if (DropDownItems != null)
						DropDownItems.Location = PointToScreen(new Point(0, P_Bar.Location.Y));
				};

				frm.Resize += (s, ea) =>
				{
					if (DropDownItems != null && DropDownItems.Visible)
					{
						if (frm.WindowState == FormWindowState.Minimized)
						{
							DropDownItems.Close();
							DropDownItems = null;
						}
						else
						{

							DropDownItems.Location = PointToScreen(new Point(0, P_Bar.Location.Y));
							DropDownItems.MaximumSize = new Size(Width, 9999);
							DropDownItems.MinimumSize = new Size(Width, 0);
						}
					}
				};
			}
		}

		private void Label1_Click(object sender, EventArgs e)
		{
			TB.Focus();
		}

		private void PB_Arrow_Click(object sender, EventArgs e)
		{
			if (DropDownItems == null)
			{
				if (Items != null && !ReadOnly)
				{
					P_Bar.BackColor = FormDesign.Design.ActiveColor;
					DropDownItems = new DropDownItems(Items, Conversion)
					{
						Location = PointToScreen(new Point(0, P_Bar.Location.Y)),
						MaximumSize = new Size(Width, 9999),
						MinimumSize = new Size(Width, 0)
					};
                    DropDownItems.Height = Math.Min(DropDownItems.Height, SystemInformation.VirtualScreen.Height - DropDownItems.Top - 15);
                    DropDownItems.ItemSelected += (item) => { Text = Conversion == null ? item.ToString() : Conversion(item); DropDownItems = null; };
					DropDownItems.FormClosed += (s, ea) => Image = Properties.Resources.ArrowDown.Color(P_Bar.BackColor);
					DropDownItems.Show();
					Image = Properties.Resources.ArrowUp.Color(P_Bar.BackColor);
					TB.Focus();
				}
				else
					SystemSounds.Exclamation.Play();
			}
			else
			{
				DropDownItems.Close();
				DropDownItems = null;
			}
		}

		private void TB_KeyPress(object sender, KeyPressEventArgs e)
		{
			OnKeyPress(e);
		}

		private void TB_Leave(object sender, EventArgs e)
		{
			if (DropDownItems != null)
			{
				DropDownItems.Close();
				DropDownItems = null;
			}
		}

		private void TB_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			PB_Arrow_Click(sender, e);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (Keys.Up == keyData)
			{
				if (DropDownItems != null)
				{
					DropDownItems.SelectNextControl(DropDownItems, true, true, true, true);
					var item = DropDownItems.CurrentItem;
					if (item != null)
						Text = Conversion == null ? item.ToString() : Conversion(item);
					FindForm().Focus();
					TB.Focus();
					BeginInvoke((MethodInvoker)TB.SelectAll);
					return true;
				}
			}
			else if (Keys.Down == keyData)
			{
				if (DropDownItems != null)
				{
					DropDownItems.SelectNextControl(DropDownItems, false, true, true, true);
					var item = DropDownItems.CurrentItem;
					if (item != null)
						Text = Conversion == null ? item.ToString() : Conversion(item);
					FindForm().Focus();
					TB.Focus();
					BeginInvoke((MethodInvoker)TB.SelectAll);
					return true;
				}
				else
					PB_Arrow_Click(null, null);
				return true;
			}
			else if (Keys.Enter == keyData)
			{
				if (DropDownItems != null)
				{
					if (DropDownItems.CurrentItem != null)
					{
						var item = DropDownItems.CurrentItem;
						if (item != null)
							Text = Conversion == null ? item.ToString() : Conversion(item);
					}
					FindForm().Focus();
					TB.Focus();
					BeginInvoke((MethodInvoker)TB.SelectAll);
					DropDownItems.Close();
					DropDownItems = null;
					return true;
				}
				else
					OnKeyPress(new KeyPressEventArgs((char)keyData));
			}
			else if (Keys.Back == keyData && TB.SelectionStart > 0 && TB.SelectionLength > 0)
			{
				TB.SelectionStart--;
				TB.SelectionLength++;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void TB_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (TB.Text != "")
				{
					if (Items == null || Items.Any(x => (Conversion == null ? x.ToString() : Conversion(x)) == TB.Text))
						return;

					var items = Items.Convert(x => Conversion == null ? x.ToString() : Conversion(x));
					var txt = TB.Text.ToLower();

					var match = items.Where(x => x.ToLower() != txt && x.ToLower().StartsWith(txt)).FirstOrDefault();

					if (match != null)
					{
						var index = TB.Text.Length;
						Text = match;
						if (DropDownItems != null)
							DropDownItems.SetItems(items.Where(x => x.ToLower() != txt && x.ToLower().StartsWith(txt)));
						else
						{
							DropDownItems = new DropDownItems(items.Where(x => x.ToLower() != txt && x.ToLower().StartsWith(txt)), Conversion)
							{
								Location = PointToScreen(new Point(0, P_Bar.Location.Y)),
								MaximumSize = new Size(Width, 9999),
								MinimumSize = new Size(Width, 0)
							};
                            DropDownItems.Height = Math.Min(DropDownItems.Height, SystemInformation.VirtualScreen.Height - DropDownItems.Top - 15);
                            DropDownItems.ItemSelected += (item) => { Text = Conversion == null ? item.ToString() : Conversion(item); DropDownItems = null; };
							DropDownItems.FormClosed += (s, ea) => Image = Properties.Resources.ArrowDown.Color(P_Bar.BackColor);
							DropDownItems.Show();
							Image = Properties.Resources.ArrowUp.Color(P_Bar.BackColor);
							TB.Focus();
						}
						TB.Select(index, TB.Text.Length - index);
					}

					if (DropDownItems != null && items.Count(x => x.ToLower() != txt && x.ToLower().StartsWith(txt)) == 1)
					{
						DropDownItems.Close();
						DropDownItems = null;
					}
				}
				else
				{
					if (DropDownItems != null)
					{
						DropDownItems.Close();
						DropDownItems = null;
					}
				}
			}
			finally { Text = TB.Text; }
		}
	}
}
