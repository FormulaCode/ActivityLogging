using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FormulaCode.ActivityLogging.Sinks
{
	public class DebugSink : IActivityLoggerSink
	{
		public void Log(ActivityEntry entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(EntryPointNotFoundException));
			var e = entry;
			Debug.WriteLine(entry.ToString());
		}
	}
}
