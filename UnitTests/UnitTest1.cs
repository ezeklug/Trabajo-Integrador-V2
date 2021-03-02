using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Dominio;

namespace UnitTests
{
    public class Tests
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


        //  [Test]
        public static void GetPreguntas()
        {
            var pregs = ControladorAdministrativo.GetPreguntas();
            foreach (var p in pregs)
            {
                Console.WriteLine(p.Id);
            }
        }


        //[TestMethod]

        public void testEscribirLog()
        {
            string descripcion = "Un error de prueba 2";
            Bitacora bitacora = new Bitacora();
            bitacora.GuardarLog(descripcion);
        }

        //[Test]
        public void testGetPreguntas()
        {
            IEnumerable<Pregunta> preguntas = ControladorPreguntas.ObtenerPreguntasDeInternet("10", "OpentDb", "Science: Computers", "hard");
            var pre = preguntas.ToList();
            Assert.Equals(10, pre.Count);
        }

        //[Test]
        public void testCargarPreguntas()
        {
            ControladorPreguntas.GetPreguntasOnline("10", "OpentDb", "Science: Computers", "hard");
        }

        //[Test]
        public void testCargarTodasLasCategorias()
        {
            var conj = ControladorPreguntas.GetCategorias("OpentDb");
            foreach (var c in conj)
            {
                Console.WriteLine(c.Id);
            }
        }
        // [TestMethod]
        public void ChechGetLogs()
        {
            foreach (Log l in ControladorAdministrativo.getLogs())
            {
                Console.WriteLine(l.Descripcion);
            }
        }

        public static void testCategoriaConMasDeN()
        {
            string nombreConjunto = "OpentDb";
            var categorias = ControladorPreguntas.GetCategoriasConMasDeNPreguntas(nombreConjunto, 0);
            foreach (var c in categorias)
            {
                Console.WriteLine($"{c.Id}");
            }
        }


        public static void cargarTodasPreguntas()
        {
            var dificultades = new List<Dificultad>();

            dificultades.Add(new Dificultad("easy"));
            dificultades.Add(new Dificultad("medium"));
            dificultades.Add(new Dificultad("hard"));
            List<(String, int, String)> lista = new List<(string, int, string)>()
            {
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


            foreach (var value in lista)
            {
                foreach (var d in dificultades)
                {
                    ConjuntoPreguntas conj = new ConjuntoPreguntas("OpentDb", d, new CategoriaPregunta(value.Item1, value.Item2.ToString()));
                    conj.TiempoEsperadoRespuesta = 1;
                    conj.Id = conj.Nombre + "," + conj.Dificultad.Id + "," + conj.Categoria.Id;

                    Console.WriteLine($"Cargando {conj.Categoria.Id} {conj.Dificultad.Id}");
                    int cargadas = 0;
                    try
                    {
                        cargadas = ControladorPreguntas.GetPreguntasOnline("10", conj.Nombre, conj.Categoria.Id, conj.Dificultad.Id);
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException e)
                    {

                    }
                    Console.WriteLine($"Se cargaron {cargadas} preguntas");
                }
            }


        }


        //[TestMethod]
        public void testUrl()
        {
            //OpentDB op = new OpentDB();
            //Console.WriteLine(op.CrearURL("10", "hard", "24"));
        }

    }
}
