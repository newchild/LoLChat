using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoLChat
{
	static class Program
	{
		public static bool OpenDetailFormOnClose { get; set; }
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			OpenDetailFormOnClose = false;

			Application.Run(new LoginWindow());

			if (OpenDetailFormOnClose)
			{
				Application.Run(new Chat());
			}
		}
	}
}
