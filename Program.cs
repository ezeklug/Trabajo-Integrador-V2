using System;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores.ObtenerPreguntas;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Ventanas;

namespace Trabajo_Integrador
{
    static class Program
    {


        public static void asd()
        {
            IEstrategiaObtenerPreguntas es = new ObtenerPreguntasOpentDb();
            Dificultad d = new Dificultad("easy");
            CategoriaPregunta cat = new CategoriaPregunta("Science: Computers", "18");
            ConjuntoPreguntas conj = new ConjuntoPreguntas("OpentDb", d, cat);
            var pregs = es.DescargarPreguntas(19, conj);
            foreach (var p in pregs)
            {
                Console.WriteLine($"{p.Id}");
            }

        }


        [STAThread]
        static void Main()
        {
            asd();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Ventana_Inicio());
        }
    }
}
