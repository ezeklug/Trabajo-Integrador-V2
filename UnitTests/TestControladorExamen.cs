using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var idRespuestasElegidas = new List<int>();

            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.GuardarRespuesta(pExamen, preguntas.First(), 0));

            //Guardar las respuestas y finalizar examen
            foreach (var p in preguntas)
            {
                var idRespuesta = p.Respuestas.First().Id;
                idRespuestasElegidas.Add(idRespuesta);
                ControladorExamen.GuardarRespuesta(pExamen, p, idRespuesta);
            }
            ControladorExamen.FinalizarExamen(pExamen);

            /// Chequea que el examen se haya guardado correctamente el DB
            var examenGuardadoDTO = ControladorAdministrativo.GetExamenes().First(e => e.Id == pExamen.Id);
            foreach (var ep in examenGuardadoDTO.ExamenPreguntas)
            {
                Assert.IsTrue(idRespuestasElegidas.Contains(ep.RespuestaElegidaId));
            }
            Assert.IsTrue(examenGuardadoDTO.ExamenPreguntas.ToList().Count == preguntas.Count());
        }


    }
}
