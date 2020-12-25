using FormulaCode.ActivityLogging.Utils;
using FormulaCode.ActivityLogging;
using System;
using Xunit;
using FormulaCode.ActivityLogging.Sinks;
using FormulaCode.ActivityLogging.Tests.Utils;
using System.Diagnostics;

namespace FormulaCode.ActivityLogging.Tests
{
	
	// Example of App Specific Logger
	public static class AppActivityLogger
	{
		private static ActivityLogger _logger;

		 static AppActivityLogger()
		{
			_logger = new ActivityLogger();
			_logger.AddSink(new DebugSink());
		}

		public static void Log(ActivityEntry entry) 
		{
			_logger.Log(entry);
		}
	}

	
	public class BasicTests
	{
		[Fact]
		public void BasicUsage()
		{
			ActivityEntry entry = DataGenerator.CreateNewActivityEntry();

			ActivityLogger log = new ActivityLogger();
			log.AddSink(new DebugSink());
			log.Log(entry);
		}

		[Fact]
		public void BasicUsage_UsingSink()
		{
			ActivityEntry entry = DataGenerator.CreateNewActivityEntry();

			// Create / Setup Logger / Log
			ActivityLogger log = new ActivityLogger();
			log.AddSink(new DebugSink());
			log.Log(entry);
		}

		[Fact]
		public void BasicUsage_UsingActionSink()
		{
			ActivityEntry entry = DataGenerator.CreateNewActivityEntry();

			Action<ActivityEntry> action = entry =>
			{
				string s = $"Action Generated: {entry.AccountName} {entry.TimeStamp.ToString()  }";
				Debug.WriteLine(s);
			};

			IActivityLoggerSink sink = new ActionSink(action);


			// Create / Setup Logger / Log
			ActivityLogger log = new ActivityLogger();
			log.AddSink(sink);
			log.Log(entry);





			// Add another sink
			log.AddSink(new ActionSink(entry => Debug.WriteLine(entry.ToString())));
			log.Log(entry);

		}


		[Fact]
		public void BasicUsage_UsingWrapper()
		{
			// Build Entry
			ActivityEntry entry = DataGenerator.CreateNewActivityEntry();

			// Log
			AppActivityLogger.Log(entry);
		}

		[Fact]
		public void ActivityTest()
		{
			// Build Entry
			ActivityEntry entry = DataGenerator.CreateNewActivityEntry();


			Activity a = new Activity(nameof(ActivityTest));
			a.Start();
			AppActivityLogger.Log(entry);

			a.Stop();
			string r = a.TraceStateString;
		}
	}
}
