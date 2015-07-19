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
	public partial class ChatWindow : Form
	{
		public ChatWindow(string Partner)
		{
			
			InitializeComponent();
			Text = Partner;
			textBox1.Text = "Thank you for using LoLChat" + Environment.NewLine;
		}

		private void ChatWindow_Load(object sender, EventArgs e)
		{
			
		}
		public void ReceiveMessage(string MSG)
		{
			textBox1.Text+="[" + DateTime.Now.ToString() + "] " + Text + ": " + Environment.NewLine;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
