using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Bitacora;

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
