using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trabajo_Integrador.Controladores;

namespace UnitTests
{
    [TestClass]
    public class TestControladorExamen
    {
        [TestMethod]
        public void TestInicializarExamen()
        {
            try
            {
                ControladorExamen.InicializarExamen("", "", "", "");
            }
            catch (ArgumentNullException) { }

            ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");

            ControladorExamen.InicializarExamen("10", "ConjuntoQueNoExiste", "Science: Computers", "easy");

            ControladorExamen.InicializarExamen("10", "OpentDb", "CategoriaQueNoExiste", "easy");
        }

        [TestMethod]
        public void TestIniciarExamen()
        {
            var examen = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            var examenDto = ControladorExamen.IniciarExamen("leo", examen);

            ///TODO: testear que pasa si el nombre de usuario no existe
            ///que pasa si se hacen dos llamadas consecutivas a iniciarExamen
            ///

        }


        [TestMethod]
        public void TestCantidadRespuestasCorrectas()
        {
            ///TODO: Crear o obtener un examen que tenga todo creado
            ///y verificar que la cantidad de respuestas sea la correcta
        }


    }
}