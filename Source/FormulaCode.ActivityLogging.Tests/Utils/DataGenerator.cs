using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FormulaCode.ActivityLogging.Tests.Utils
{
	public class DataGenerator
	{
		public static ActivityEntry CreateNewActivityEntry()
		{
			string seed = Guid.NewGuid().ToString().Substring(0, 3);

			ActivityEntry entry = new ActivityEntry
			{

				TimeStamp = DateTime.Now,

				ActivityType = DefaultActivityTypes.UserLogin,
				ActivityName = "Activity Name",
				ActivityNotes = "Activity Notes " + seed,
				ActivityUid = Guid.NewGuid().ToString(),


				DeviceIpAddress = LocalIPAddress().ToString(),
				DeviceUserName = "Raiford",
				DeviceAgent = "Shit Browser",
				DevicePlatform = "Device Platform",
				DeviceMacAddress = "Device Mac Address",
				DeviceSessionId = "Session Id",

				AccountName = "My Account Name",
			
				AppId = "App Id",
				AppName = "App Name",
				AppPublisher = "App Publisher",

				ServerInfo = LocalIPAddress().ToString(),
				ServerMacAddress = "1.1.1.1.1",
				ServerIpAddress = "192.163.1.1",
				ServerPlatform = "Server Platform",
				ServerUserName = "Server User Name",
			
				OrganizationName = "Organization Name",
				OrganizationKey = "Organization Key",

				Data = "This is the data property contents" + seed
				
				
				
			};

			return entry;

		}

		private static IPAddress LocalIPAddress()
		{
			if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
			{
				return null;
			}

			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

			return host
				.AddressList
				.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		}
	}
}
