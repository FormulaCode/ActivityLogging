using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaCode.ActivityLogging
{
	public interface IActivityLoggerSink
	{

		void Log(ActivityEntry entry);


	}
}
