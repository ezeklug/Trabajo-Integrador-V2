using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Excepciones;



namespace UnitTests
{
    [TestClass]
    public class TestControladorAdministrativo
    {
        [TestMethod]
        public void AutenticarUsuario_UsuarioValido_DevuelveElUsuario()
        {
            var usr = ControladorAdministrativo.AutenticarUsuario("admin", "admin");
            Assert.AreEqual(usr.Id, "admin");
        }

        [TestMethod]
        public void AutenticarUsuario_UsuarioVacio_DevuelveExcepcion()
        {
            try
            {
                ControladorAdministrativo.AutenticarUsuario("", "");
                Assert.Fail();
            }
            catch (UsrNoEncontradoException) { }
        }

        [TestMethod]
        public void AutenticarUsuario_UsuarioInexistente_DevuelveExcepcion()
        {
            try
            {
                ControladorAdministrativo.AutenticarUsuario("usuarioInexistente", "contraseñaInexistente");
                Assert.Fail();
            }
            catch (UsrNoEncontradoException) { }
        }

        [TestMethod]
        public void GetUsuarios_DevuelveListaDeUsuarios()
        {
            var count = ControladorAdministrativo.GetUsuarios().ToList().Count;
            Assert.IsTrue(count >= 1);
        }


        [TestMethod]
        public void GetPreguntas_DevuelveListaDePreguntas()
        {
            var count = ControladorAdministrativo.GetPreguntas().ToList().Count;
            Assert.IsTrue(count >= 1);
        }


        [TestMethod]
        public void GetExamenes_DevuelveListaDeExamenes()
        {
            var count = ControladorAdministrativo.GetExamenes().ToList().Count;
            Assert.IsTrue(count >= 1);
        }

        [TestMethod]
        public void GetNombresConjuntosPreguntas_DevuelveListaConjuntosPregunta()
        {
            var nombres = ControladorAdministrativo.GetNombresConjuntosPreguntas().ToList();
            // OpentDb es el unico conjunto actualmente en la DB
            CollectionAssert.Contains(nombres, "OpentDb");
        }

        [TestMethod]
        public void SetAdministrador_UsuarioValido()
        {
            var id = "admin";
            var pass = "admin";

            ControladorAdministrativo.SetAdministrador(id);
            var usr = ControladorAdministrativo.AutenticarUsuario(id, pass);
            Assert.AreEqual(usr.Administrador, true);
        }

        [TestMethod]
        public void SetNoAdministrador_UsuarioValido()
        {
            var id = "admin";
            var pass = "admin";

            ControladorAdministrativo.SetNoAdministrador(id);
            var usr = ControladorAdministrativo.AutenticarUsuario(id, pass);
            Assert.AreEqual(usr.Administrador, false);
        }


        [TestMethod]
        public void GetRanking_UsuarioValido_DevuelveListaDeExamenesOrdenadasPorPuntaje()
        {
            var idUser = "leo";
            var count = ControladorAdministrativo.GetRanking(idUser).ToList().Count;
            Assert.IsTrue(count >= 1);
        }


        [TestMethod]
        public void GetRanking_UsuarioNoValido_DevuelveListaVacia()
        {
            var idInexsistente = "UsuarioQueNoExiste";
            var count = ControladorAdministrativo.GetRanking(idInexsistente).ToList().Count;
            Assert.AreEqual(count, 0);
        }


        [TestMethod]
        public void GuardarUsuario_UsuarioExistente_DevuelveExcepcion()
        {
            try
            {
                ControladorAdministrativo.GuardarUsuario("leo", "leonardo");
                Assert.Fail();
            }
            catch (UsrYaExisteException) { }
        }
    }
}
