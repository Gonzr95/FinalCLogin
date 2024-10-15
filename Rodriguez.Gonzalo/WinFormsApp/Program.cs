using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult rta;

            do
            {
                frm.ShowDialog();

                rta = frm.DialogResult;

            } while (rta == DialogResult.Retry);

            if (rta == DialogResult.OK)
            {
                frm.Close();

                Application.Run(new FrmPrincipal());
            }
        }
    }
}
