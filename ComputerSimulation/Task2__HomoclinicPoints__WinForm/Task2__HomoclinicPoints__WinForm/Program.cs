using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task2__HomoclinicPoints__WinForm.Diffeomorphisms;

namespace Task2__HomoclinicPoints__WinForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            MainForm form = new MainForm();

            Application.Run(form);
        }
    }
}
