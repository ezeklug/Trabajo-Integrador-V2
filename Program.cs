using System;
using System.Windows.Forms;
using Trabajo_Integrador.Ventanas;

namespace Trabajo_Integrador
{
    static class Program
    {



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Ventana_Inicio());
        }
    }
}
