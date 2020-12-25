using System;
using System.Diagnostics;

namespace FormulaCode.ActivityLogging.Sinks
{
	public class ActionSink : IActivityLoggerSink
	{
		private Action<ActivityEntry>_action;

		public ActionSink(Action<ActivityEntry> action)
		{
			_action = action;
		}

		public void Log(ActivityEntry entry)
		{
			_action(entry);
		}
	}
}