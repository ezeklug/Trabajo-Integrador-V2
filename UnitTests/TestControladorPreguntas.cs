using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Trabajo_Integrador.Controladores;

namespace UnitTests
{
    [TestClass]
    public class TestControladorPreguntas
    {

        [TestMethod]
        public void TestGetEstrategia()
        {
            string nombre = "OpentDb";
            Console.WriteLine(ControladorPreguntas.GetEstrategia(nombre));
            Assert.IsNotNull(ControladorPreguntas.GetEstrategia(nombre).ToString());
        }

        [TestMethod]
        public void TestObtenerPreguntasDeInternet()
        {
            string cantidad = "20";
            string conjunto = "OpentDb";
            string categoria = "Sports";
            string dificultad = "easy";

            var count = ControladorPreguntas.ObtenerPreguntasDeInternet(cantidad, conjunto, categoria, dificultad).ToList().Count;
            // Se chequea que tenga mas de una pregunta ya que la API puede devolver menos preguntas
            Assert.IsTrue(count >= 1);
        }

        [TestMethod]
        public void TestGetCategoriasConMasDeNPreguntas()
        {
            String nombreConjunto = "OpentDb";
            int cantidadDePreguntas = 35;
            var categorias = ControladorPreguntas.GetCategoriasConMasDeNPreguntas(nombreConjunto, cantidadDePreguntas);

            foreach (var categoria in categorias)
            {
                Assert.IsTrue(ControladorPreguntas.CantidadDePreguntasParaCategoria(categoria.Id) >= cantidadDePreguntas);
            }
        }




    }
}
