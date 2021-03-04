using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Trabajo_Integrador;
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
        public void TestCargarPreguntasDeInternet()
        {
            string pCantidad = "20";
            string pConjunto = "OpentDb";
            string pCategoria = "Sports";
            string pDificultad = "easy";

            var count = ControladorPreguntas.ObtenerPreguntasDeInternet(pCantidad,pConjunto,pCategoria,pDificultad).ToList().Count;
            Console.WriteLine(count);
            Assert.IsTrue(count >= 1);


        }

        [TestMethod]
        public void TestGetCategorias()
        {
            string nombreConjunto = "OpentDb";
            int count = ControladorPreguntas.GetCategorias(nombreConjunto).ToList().Count;
            Console.WriteLine(count);
            Assert.IsTrue(count >= 1);
        }

        [TestMethod]
        public void TestGetCategoriasConMasDeNPreguntas()
        {
            String pNombreConjunto= "OpentDb";
            int n = 35;
            int count = ControladorPreguntas.GetCategoriasConMasDeNPreguntas(pNombreConjunto, n).ToList().Count;
            Console.WriteLine(count);
            Assert.IsTrue(count >= 1);

        }

        [TestMethod]
        public void TestCantidadDePreguntasParaCategoria()
        {
            String pIdCategoria = "History";
            int count = ControladorPreguntas.CantidadDePreguntasParaCategoria(pIdCategoria);
            Assert.IsNotNull(count);
            Console.WriteLine(count);
        }

        [TestMethod]
        public void GetDificultades()
        {
            string nombreConjunto = "OpentDb";
            int count = ControladorPreguntas.GetDificultades(nombreConjunto).ToList().Count;
            Console.WriteLine(count);
            Assert.IsTrue(count == 3);
        }




    }
}
