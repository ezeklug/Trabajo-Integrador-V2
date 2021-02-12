using System;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Ventanas;


namespace Trabajo_Integrador
{
    static class Program
    {

        public static void MostrarCategorias()
        {
            var usuarios = ControladorAdministrativo.GetUsuarios();
            foreach (var u in usuarios)
            {
                Console.WriteLine($"El usr es: {u.Id}");
            }
        }
        public static void CargarPreguntas()
        {
            var cant = ControladorPreguntas.GetPreguntasOnline("10", "OpentDb", "Science: Computers", "hard");
            Console.WriteLine($"Se cargaron {cant} preguntas");
        }


        [STAThread]
        static void Main()
        {
            MostrarCategorias();
            Console.ReadKey();
            CargarPreguntas();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Ventana_Inicio());
        }
    }
}
