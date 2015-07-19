using agsXMPP.protocol.client;
using agsXMPP.protocol.iq.roster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoLChat
{
	public partial class Chat : Form
	{
        Dictionary<string, ChatWindow> WindowList;
		List<RosterItem> friends = new List<RosterItem>();
		public Chat()
		{
			InitializeComponent();
		}

		private void Chat_Load(object sender, EventArgs e)
		{
			WindowList = new Dictionary<string, ChatWindow>();
			var XmppConnection = new agsXMPP.XmppClientConnection("pvp.net", 5223)
			{
				AutoResolveConnectServer = false,
				ConnectServer = UserInfo.Region,
				Resource = "xiff",
				UseSSL = true,
				KeepAliveInterval = 10,
				KeepAlive = true
			};
			XmppConnection.UseCompression = true;
			UserInfo.connect = XmppConnection;
			UserInfo.connect.OnError += Connect_OnError;
			UserInfo.connect.OnMessage += Connect_OnMessage;
			UserInfo.connect.OnLogin += Connect_OnLogin;
			UserInfo.connect.OnAuthError += Connect_OnAuthError;
			UserInfo.connect.OnSocketError += Connect_OnSocketError;
			UserInfo.connect.Open(UserInfo.User, UserInfo.Password);
			UserInfo.connect.OnRosterItem += Connect_OnRosterItem;
			
			
        }

		private void Connect_OnRosterItem(object sender, RosterItem item)
		{
			friends.Add(item);
		}

		private void Connect_OnSocketError(object sender, Exception ex)
		{
			MessageBox.Show("SockError: " + ex.Message);
		}

		private void Connect_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
		{
			MessageBox.Show("AuthError: " + e.Value);
		}

		private void Connect_OnLogin(object sender)
		{
			
			UserInfo.connect.Send(new Presence(ShowType.chat, "invalid", 0) { Type = PresenceType.available });
			

        }

		private void Connect_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
		{
			string PseudoName = "";
			foreach(var user in friends)
			{
				if(msg.From.User == user.Jid.User)
				{
					PseudoName = user.Name;
				}
			}
			if (!WindowList.ContainsKey(PseudoName)){
				ChatWindow temp = new ChatWindow(PseudoName);
				WindowList.Add(PseudoName, temp);
			}
			WindowList[PseudoName].Show();
			


		}

		private void Connect_OnError(object sender, Exception ex)
		{
			MessageBox.Show("GenericError: " + ex.Message);
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
