using System.Windows.Forms;

namespace SlickControls.Classes
{
	public struct InputResult
	{
		public DialogResult DialogResult;
		public string Input;

		public InputResult(DialogResult dialogResult, string input) : this()
		{
			DialogResult = dialogResult;
			Input = input;
		}
	}
}
