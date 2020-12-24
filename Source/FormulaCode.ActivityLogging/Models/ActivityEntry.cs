using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FormulaCode.ActivityLogging.Models
{
	public sealed class ActivityEntry
	{
		// Basic Info
		public string ActivityUid{ get; set; }
		public string ActivityType { get; set; }
		public string ActivityName { get; set; }
		public string ActivityNotes { get; set; }
		public DateTime TimeStamp { get; set; }


		// Person Info
		public string AccountName { get; set; }
		public string SessionId { get; set; }

		
		// Organization Info   (Optional)
		public string OrganizationName { get; set; }
		public string OrganizationKey { get; set; }


		// Application Info (Optional)
		public string AppId { get; set; }
		public string AppName { get; set; }
		public string AppPublisher { get; set; }


		// Device Info
		public string DeviceIpAddress { get; set; }
		public string DeviceMacAddress{ get; set; }
		public string DeviceUserName { get; set; }
		public string DevicePlatform { get; set; } // Windows 10
		public string DeviceAgent { get; set; } // Chrome 8


		// Server / Machine  Info
		public string ServerIpAddress { get; set; }
		public string ServerMacAddress { get; set; }
		public string ServerUserName { get; set; }
		public string ServerPlatform { get; set; } // Windows 10
		public string ServerInfo{ get; set; } // Chrome 8


		// Security Validation Info
		public string ValidationChecksum { get; set; }
		public string Hash { get; set; }


		// Defined Data
		public KeyValuePair<string, string> DataDictionary { get; set; }
		public string Data { get; set; }





		public override string ToString()
		{
			string json = JsonSerializer.Serialize<ActivityEntry>(this, new JsonSerializerOptions() { WriteIndented = true });
			return json;
		}





	}
}
