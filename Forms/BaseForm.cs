using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Extensions;

namespace SlickControls.Forms
{
	public partial class BaseForm : SlickForm
	{
		#region Private Fields

		private Image formIcon;
		private bool showControls = false;
		private bool showSpacer = true;

		#endregion Private Fields

		#region Public Constructors

		public BaseForm() : this(false)
		{ }

		public BaseForm(bool initialized)
		{
			InitializeComponent();

			LoadingTimer.Elapsed += LoadingTimer_Elapsed;

			if (!initialized)
				FormDesign.DesignChanged += DesignChanged;

			base_L_Title.MouseDown += Form_MouseDown;
			base_P_Controls.MouseDown += Form_MouseDown;
		}

		#endregion Public Constructors

		#region Properties

		[Category("Appearance")]
		public override Image FormIcon { get => formIcon; set { base_PB_Icon.Image = formIcon = value.Color(FormDesign.Design.IconColor); } }

		[Category("Appearance")]
		public override Rectangle IconBounds { get => base_PB_Icon.Bounds; set => base_PB_Icon.Bounds = value; }

		[Category("Behavior"), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
		public bool ShowControls
		{
			get => base_P_Controls.Visible = showControls;
			set
			{
				base_P_Controls.Visible = showControls = value;
				if (value && base_P_Controls.Height == 0)
					base_P_Controls.Height = 45;
			}
		}

		[Category("Behavior"), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
		public bool ShowTopSpacer { get => base_P_Top_Spacer.Visible = showSpacer; set => base_P_Top_Spacer.Visible = showSpacer = value; }

		protected new bool MaximizeBox { get => base.MaximizeBox; set => base_B_Max.Visible = base.MaximizeBox = value; }

		protected new bool MinimizeBox { get => base.MinimizeBox; set => base_B_Min.Visible = base.MinimizeBox = value; }

		#endregion Properties

		#region General Methods

		protected override void DesignChanged(FormDesign design)
		{
			base.DesignChanged(design);

			base_P_Top.BackColor = base_P_Controls.BackColor = design.MenuColor;
			base_L_Title.ForeColor = base_P_Controls.ForeColor = design.MenuForeColor;
			base_P_Content.BackColor = design.BackColor;
			ForeColor = design.ForeColor;
			base_P_Top_Spacer.BackColor = design.AccentColor;

			base_B_Close.Color(design.RedColor);
			base_B_Max.Color(design.YellowColor);
			base_B_Min.Color(design.GreenColor);
			base_PB_Icon.Color(design.MenuForeColor);
		}

		private void BaseForm_Load(object sender, EventArgs e)
		{
			foreach (Control ctrl in base_P_Controls.Controls)
			{
				if (ctrl is Panel || ctrl is Label)
					ctrl.MouseDown += Form_MouseDown;
			}
		}

		private void L_Title_TextChanged(object sender, EventArgs e)
		{
			if (base_L_Title.Text != Text)
				Text = base_L_Title.Text;
		}

		#endregion General Methods

		#region Loader

		private System.Timers.Timer LoadingTimer = new System.Timers.Timer(30);

		private double perc = -100;

		public void StartLoader()
		{
			LoadingTimer.Start();
			perc = -20;
		}

		public void StopLoader()
		{
			LoadingTimer.Stop();
			perc = -100;

			if (base_P_Top_Spacer.InvokeRequired)
				base_P_Top_Spacer.Invoke(new Action(base_P_Top_Spacer.Refresh));
			else
				base_P_Top_Spacer.Refresh();
		}

		private void LoadingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				perc += 3;
				if (perc >= 100)
					perc = -20;
				if (base_P_Top_Spacer.InvokeRequired)
					base_P_Top_Spacer.Invoke(new Action(base_P_Top_Spacer.Refresh));
				else
					base_P_Top_Spacer.Refresh();
			}
			catch { }
		}

		private void P_Top_Spacer_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(base_P_Top_Spacer.BackColor);

			if (perc >= -20)
				e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ActiveColor), new RectangleF((float)(perc * base_P_Top_Spacer.Width / 100), 0, (base_P_Top_Spacer.Width * 2 / 10), base_P_Top_Spacer.Height));

			if (perc > 100)
				e.Graphics.FillRectangle(new SolidBrush(FormDesign.Design.ActiveColor), new RectangleF(0, 0, (float)((base_P_Top_Spacer.Width * 2 / 10) * (perc - 100) / 100), base_P_Top_Spacer.Height));
		}

		#endregion Loader
	}
}