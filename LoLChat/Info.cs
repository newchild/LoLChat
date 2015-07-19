using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLChat
{
	static class UserInfo
	{
		public static agsXMPP.XmppClientConnection connect = null;
		private static string username = "";
		private static string pw = "";
		public static string User
		{
			get
			{
				return username;
			}
			set
			{
					username = value;
			}
				
            
		}
		public static string Password
		{
			get
			{
				return pw;
			}
			set
			{
				
					pw = "AIR_" + value;
				
			}
		}

		public static string Region = "";
	}
	static class ServerInfo
	{
		public static Dictionary<string, string> Regions = new Dictionary<string, string>() {
			{ "EUW", "chat.euw1.lol.riotgames.com" },
			{ "EUNE", "chat.eun1.lol.riotgames.com" },
			{ "NA", "chat.na1.lol.riotgames.com" }

		};
	}
}
