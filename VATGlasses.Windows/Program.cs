using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VATGlasses
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UpdateUI updUpd = new UpdateUI();
            if (!updUpd.IsDisposed)
            {
                Application.Run(updUpd);
            }
            Application.Run(new Load());
        }
    }
}
