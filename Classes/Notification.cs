using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;
using SlickControls.Enums;
using SlickControls.Forms;

namespace SlickControls.Classes
{
	public class Notification
	{
		public string Title { get; }
		public string Description { get; }
		public PromptIcons Icon { get; }
		public ExtensionClass.action Action { get; }
		public Action<PictureBox, Graphics> OnPaint { get; set; }
		public Size Size { get; }
		public bool LongSound { get; }

		private Notification(string title, string description, PromptIcons icon, ExtensionClass.action action, bool longSound, Size? size)
		{
			Title = title;
			Description = description;
			Icon = icon;
			Action = action;
			LongSound = longSound;
			Size = size ?? new Size(400, 70);
		}

		public NotificationForm Show(Form form = null, int? timeoutSeconds = null)
			=> NotificationForm.Push(this, form, LongSound, timeoutSeconds);

		public static Notification Create(string title, string description, PromptIcons icon, ExtensionClass.action action, bool longSound = false, Size? size = null)
			=> new Notification(title, description, icon, action, longSound, size);

		public static Notification Create(Action<PictureBox, Graphics> onpaint, ExtensionClass.action action, bool longSound = false, Size? size = null)
			=> new Notification(string.Empty, string.Empty, PromptIcons.Input, action, longSound, size) { OnPaint = onpaint };

		public static void Clear() => NotificationForm.Clear();
	}
}
