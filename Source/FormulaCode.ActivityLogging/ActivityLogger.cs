using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FormulaCode.ActivityLogging
{
	public  sealed class ActivityLogger
	{

		private IList<IActivityLoggerSink> _sinks;


		public ActivityLogger()
		{
			_sinks = new List<IActivityLoggerSink>();
		}



		public void Log(ActivityEntry entry)
		{		
			if(_sinks.Count<1)
			{
				Debug.WriteLine($"nameof(this) Does not have any Sinks assigned... there will be no Activities Logged");
			}
			foreach(var sink in _sinks)
			{
				sink.Log(entry);
			}

		}

		public void AddSink(IActivityLoggerSink sink)
		{
			_sinks.Add(sink);
		}






	}
}
