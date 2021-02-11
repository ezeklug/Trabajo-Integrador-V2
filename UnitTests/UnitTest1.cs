using NUnit.Framework;
using System;
using System.Collections.Generic;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Dominio;

namespace UnitTests
{
    public class Tests
    {
        //[TestMethod]

        public void testEscribirLog()
        {
            string descripcion = "Un error de prueba 2";
            Bitacora bitacora = new Bitacora();
            bitacora.GuardarLog(descripcion);
        }

        [Test]
        public void testGetPreguntas()
        {
            OpentDB op = new OpentDB();
            ICollection<Pregunta> preguntas;
            List<Respuesta> respuestas;


            CategoriaPregunta cat = new CategoriaPregunta("Science: Computers", "18");
            Dificultad dif = new Dificultad("hard");
            ConjuntoPreguntas conj = new ConjuntoPreguntas("OpentDB", dif, cat);
            preguntas = op.getPreguntas(10, conj);
            foreach (Pregunta pre in preguntas)
            {
                Console.WriteLine($"La pregunta es: {pre.Id}, idConj: {pre.Conjunto.Nombre}, idCat: {pre.Conjunto.Categoria.Id}");
            }
        }





        //[TestMethod]
        public void TestCategoriaMayorN()
        {
            int n = 10;
            ControladorPreguntas cont = new ControladorPreguntas();
            ICollection<CategoriaPregunta> categorias = cont.GetCategoriasConMasDeNPreguntas(n);
            Console.WriteLine("Tamanio: " + categorias.Count);
            foreach (CategoriaPregunta cat in categorias)
            {
                Console.WriteLine(cat.Id);
            }
            Console.WriteLine("LLego aca");
        }

        // [TestMethod]
        public void ChechGetLogs()
        {
            ControladorAdministrativo cont = new ControladorAdministrativo();
            foreach (Log l in cont.getLogs())
            {
                Console.WriteLine(l.Descripcion);
            }
        }


        //[TestMethod]
        public void testUrl()
        {
            OpentDB op = new OpentDB();
            Console.WriteLine(op.CrearURL("10", "hard", "24"));
        }

    }
}
