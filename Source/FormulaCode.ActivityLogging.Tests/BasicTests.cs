using FormulaCode.ActivityLogging.Models;
using FormulaCode.ActivityLogging.Utils;
using FormulaCode.ActivityLogging;
using System;
using Xunit;
using FormulaCode.ActivityLogging.Sinks;

namespace FormulaCode.ActivityLogging.Tests
{


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

		
			ActivityLogger log = new ActivityLogger();
			ActivityEntry entry = new ActivityEntry
			{
				ActivityType = DefaultActivityTypes.UserLogin,
				DeviceIpAddress = "",
				TimeStamp = DateTime.Now,
				DeviceUserName = "Raiford",
				DeviceAgent = "Shit Browser"
			};

			log.Log(entry);
		}


		[Fact]
		public void BasicUsage_UsingSink()
		{
			// Create / Setup Logger
			ActivityLogger log = new ActivityLogger();
			log.AddSink(new DebugSink());

			// Build Entry
			ActivityEntry entry = new ActivityEntry
			{
				ActivityType = DefaultActivityTypes.UserLogin,
				DeviceIpAddress = "",
				TimeStamp = DateTime.Now,
				DeviceUserName = "Raiford",
				DeviceAgent = "Shit Browser"
			};

			// Log
			log.Log(entry);
		}

		[Fact]
		public void BasicUsage_UsingWrapper()
		{
			// Build Entry
			ActivityEntry entry = new ActivityEntry
			{
				ActivityType = DefaultActivityTypes.UserLogin,
				DeviceIpAddress = "",
				TimeStamp = DateTime.Now,
				DeviceUserName = "Raiford",
				DeviceAgent = "Shit Browser"
			};

			// Log
			AppActivityLogger.Log(entry);
		}

	}
}
