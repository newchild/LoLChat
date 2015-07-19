using System;
using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using agsXMPP.protocol.iq.roster;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoLChat
{
	public partial class LoginWindow : Form
	{
		public LoginWindow()
		{
			InitializeComponent();
			comboBox1.DataSource = new BindingSource(ServerInfo.Regions, null);
			comboBox1.DisplayMember = "Key";
			comboBox1.ValueMember = "Value";
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void LoginWindow_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			UserInfo.User = textBox1.Text;
			UserInfo.Password = textBox2.Text;
			UserInfo.Region = comboBox1.SelectedValue.ToString();
			Program.OpenDetailFormOnClose = true;

			this.Close();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
