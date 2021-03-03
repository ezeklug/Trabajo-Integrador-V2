using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Excepciones;
using Trabajo_Integrador.DTO;

namespace UnitTests
{
    [TestClass]
    public class TestControladorExamen
    {
        [TestMethod]
        public void TestInicializarExamen()
        {
            var examenDto = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            Assert.IsTrue(examenDto.ExamenPreguntas.ToList().Count == 10);

            Assert.ThrowsException<ArgumentNullException>(() => ControladorExamen.InicializarExamen("", "", "", ""));
            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.InicializarExamen("10", "ConjuntoQueNoExiste", "Science: Computers", "easy"));
            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.InicializarExamen("10", "OpentDb", "CategoriaQueNoExiste", "easy"));
        }

        [TestMethod]
        public void TestFuncionalidadExamen()
        {
            var examen = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            Assert.ThrowsException<UsrNoEncontradoException>(() => ControladorExamen.IniciarExamen("usuarioQueNoExiste", examen));
            examen = ControladorExamen.IniciarExamen("leo", examen);

            TestGuardarPreguntas(examen);
        }


        public void TestGuardarPreguntas(ExamenDTO pExamen)
        {
            var preguntas = ControladorExamen.GetPreguntasDeExamen(pExamen.Id);

            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.GuardarRespuesta(pExamen, preguntas.First(), 0));

            foreach (var p in preguntas)
            {
                ControladorExamen.GuardarRespuesta(pExamen, p, p.Respuestas.First().Id);
            }
            ControladorExamen.FinalizarExamen(pExamen);

            /// Chequea que el examen se haya guardado correctamente el DB
            var examenGuardadoDTO = ControladorAdministrativo.GetExamenes().First(e => e.Id == pExamen.Id);
            Assert.IsTrue(examenGuardadoDTO.ExamenPreguntas.Where(ep => ep.RespuestaElegidaId == 1).ToList().Count == preguntas.Count());
        }


        [TestMethod]
        public void TestCantidadRespuestasCorrectas()
        {
            ///TODO: Crear o obtener un examen que tenga todo creado
            ///y verificar que la cantidad de respuestas sea la correcta
        }


    }
}
