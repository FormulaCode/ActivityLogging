using FormulaCode.ActivityLogging.Models;
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
			//if()

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
