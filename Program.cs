using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Ventanas;


namespace Trabajo_Integrador
{
    static class Program
    {


        public static void CargarTodo()
        {
            var dificultades = new List<Dificultad>();
            dificultades.Add(new Dificultad("easy"));
            dificultades.Add(new Dificultad("medium"));
            dificultades.Add(new Dificultad("hard"));
            List<(String, int, String)> lista = new List<(string, int, string)>()
            {
                ("General Knowledge"    ,9  ,"General Knowledge"),
                ("Entertainment: Books" ,10 ,"Entertainment: Books"),
                ("Entertainment: Film"  ,11 ,"Entertainment: Film"),
                ("Entertainment: Music" ,12 ,"Entertainment: Music"),
                ("Entertainment: Musicals & Theatres"   ,13,    "Entertainment: Musicals & Theatres"),
                ("Entertainment: Television"    ,14,    "Entertainment: Television"),
                ("Entertainment: Video Games"   ,15,    "Entertainment: Video Games"),
                ("Entertainment: Board Games"   ,16,    "Entertainment: Board Games"),
                ("Science & Nature" ,17,    "Science & Nature"),
                ("Science: Computers",  18, "Science: Computers"),
                ("Science: Mathematics",    19, "Science: Mathematics"),
                ("Mythology"    ,20,    "Mythology"),
                ("Sports"   ,21,    "Sports"),
                ("Geography",   22, "Geography"),
                ("History"  ,23,    "History"),
                ("Art"  ,25,    "Art"),
                ("Celebrities", 26, "Celebrities"),
                ("Animals"  ,27,    "Animals"),
                ("Vehicles" ,28,    "Vehicles"),
                ("Entertainment: Comics"    ,29,    "Entertainment: Comics"),
                ("Science: Gadgets" ,30,"Science: Gadgets"),
                ("Entertainment: Japanese Anime & Manga",   31  ,"Entertainment: Japanese Anime & Manga"),
                ("Entertainment: Cartoon & Animations", 32, "Entertainment: Cartoon & Animations"),
                ("Politics" ,24,    "Politics"),
            };
            var conjuntos = new List<ConjuntoPreguntas>();
            foreach (var value in lista)
            {
                foreach (var d in dificultades)
                {
                    ConjuntoPreguntas conj = new ConjuntoPreguntas("OpentDb", d, new CategoriaPregunta(value.Item1, value.Item2.ToString()));
                    conj.TiempoEsperadoRespuesta = 1;
                    conj.Id = conj.Nombre + "," + conj.Dificultad.Id + "," + conj.Categoria.Id;
                    conjuntos.Add(conj);
                }
            }
            ControladorPreguntas.GuardarConjuntos(conjuntos);
        }
        public static void CargarPreguntas()
        {
            var cant = ControladorPreguntas.GetPreguntasOnline("10", "OpentDb", "Science: Computers", "hard");
            Console.WriteLine($"Se cargaron {cant} preguntas");
        }
        [STAThread]
        static void Main()
        {
            // CargarTodo();
            //CargarPreguntas();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Ventana_Inicio());
        }
    }
}
