using System.Drawing;

namespace SlickControls.Classes
{
	public class FlatStripItem
	{
		public delegate void action();

		public string Text { get; set; }
		public Bitmap Image { get; set; }
		public action Action { get; set; }
		public bool Fade { get; set; }
		public bool Show { get; set; }
		public bool CloseOnClick { get; set; }
		public int Tab { get; set; }
		public bool IsEmpty => Text == "" && Image == null;

		public FlatStripItem(string text, action action = null, Bitmap image = null, bool show = true, bool fade = false, int tab = 0, bool closeOnClick = true)
		{
			Text = text;
			Image = image;
			Action = action;
			Fade = fade;
			Show = show;
			Tab = tab;
			CloseOnClick = closeOnClick;
		}

		public static FlatStripItem Empty => new FlatStripItem("");
	}
}
