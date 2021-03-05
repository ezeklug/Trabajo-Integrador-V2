using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Excepciones;

namespace UnitTests
{
    [TestClass]
    public class TestControladorExamen
    {
        [TestMethod]
        public void InicializarExamen_ExamenValido_DevuelveExamen()
        {
            var examenDto = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            Assert.IsTrue(examenDto.ExamenPreguntas.ToList().Count == 10);
        }

        [TestMethod]
        public void InicializarExamen_ExamenVacio_DevuelveExcepcionNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ControladorExamen.InicializarExamen("", "", "", ""));
        }

        [TestMethod]
        public void InicializarExamen_ExamenConConjuntoInexistente_DevuelveArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.InicializarExamen("10", "ConjuntoQueNoExiste", "Science: Computers", "easy"));
        }

        [TestMethod]
        public void InicializarExamen_ExamenConCategoriaInexistente_DevuelveArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.InicializarExamen("10", "OpentDb", "CategoriaQueNoExiste", "easy"));
        }

        [TestMethod]
        public void IniciarExamen_UsuarioValidoExamenValido_DevuelveExamen()
        {
            var examen = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            examen = ControladorExamen.IniciarExamen("leo", examen);
            Assert.IsTrue(examen.CantidadPreguntas == 10);
        }

        [TestMethod]
        public void IniciarExamen_UsuarioInexistenteExamenValido_DevuelveUsrNoEncontradoException()
        {
            var examen = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            Assert.ThrowsException<UsrNoEncontradoException>(() => ControladorExamen.IniciarExamen("usuarioQueNoExiste", examen));
        }

        [TestMethod]
        public void GuardarRespuestaFinalizarExamen_ExamenValidoPreguntaValidaRespuestaValida_DevuelveExamen()
        {
            var examen = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            examen = ControladorExamen.IniciarExamen("leo", examen);
            var preguntas = ControladorExamen.GetPreguntasDeExamen(examen.Id);
            var idRespuestasElegidas = new List<int>();
            foreach (var p in preguntas)
            {
                var idRespuesta = p.Respuestas.First().Id;
                idRespuestasElegidas.Add(idRespuesta);
                ControladorExamen.GuardarRespuesta(examen, p, idRespuesta);
            }
            ControladorExamen.FinalizarExamen(examen);
            var examenGuardadoDTO = ControladorAdministrativo.GetExamenes().First(e => e.Id == examen.Id);
            foreach (var ep in examenGuardadoDTO.ExamenPreguntas)
            {
                Assert.IsTrue(idRespuestasElegidas.Contains(ep.RespuestaElegidaId));
            }
            Assert.IsTrue(examenGuardadoDTO.ExamenPreguntas.ToList().Count == preguntas.Count());
        }

        [TestMethod]
        public void GuardarRespuesta_ExamenValidoPreguntaValidaRespuestaInvalida_DevuelveArgumentException()
        {
            var examen = ControladorExamen.InicializarExamen("10", "OpentDb", "Science: Computers", "easy");
            examen = ControladorExamen.IniciarExamen("leo", examen);
            var preguntas = ControladorExamen.GetPreguntasDeExamen(examen.Id);
            var idRespuestasElegidas = new List<int>();
            Assert.ThrowsException<ArgumentException>(() => ControladorExamen.GuardarRespuesta(examen, preguntas.First(), 0));
        }
    }
}
