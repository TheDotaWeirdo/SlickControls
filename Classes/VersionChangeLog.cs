using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SlickControls.Classes
{
	public class VersionChangeLog
	{
		[JsonIgnore()]
		public Version Version => new Version(VersionString);
		public string VersionString { get; set; }
		public DateTime? Date { get; set; }
		public string Tagline { get; set; }
		public VersionChangeLogGroup[] ChangeGroups { get; set; }
	}
}
