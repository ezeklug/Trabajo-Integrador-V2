using System.Linq;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTests
{
    [TestClass]
    public class TestControladorAdministrativo
    {
        [TestMethod]
        public void TestGetUsuario()
        {
            var usr = ControladorAdministrativo.AutenticarUsuario("leo", "leonardo");
            Assert.Equals(usr.Id, "leo");
            try
            {
                ControladorAdministrativo.AutenticarUsuario("", "");
            }
            catch (UsrNoEncontradoException) { }

            try
            {
                ControladorAdministrativo.AutenticarUsuario("asdasd", "lsoebfdia");
            }
            catch (UsrNoEncontradoException) { }
        }


        [TestMethod]
        public void TestGetUsuarios()
        {
            var count = ControladorAdministrativo.GetUsuarios().ToList().Count;
            Assert.IsTrue(count >= 1);
        }


        [TestMethod]
        public void TestGetPreguntas()
        {
            var count = ControladorAdministrativo.GetPreguntas().ToList().Count;
            Assert.IsTrue(count >= 1);
        }


        [TestMethod]
        public void TestGetExamenes()
        {
            var count = ControladorAdministrativo.GetExamenes().ToList().Count;
            Assert.IsTrue(count >= 1);
        }

        [TestMethod]
        public void TestGetNombresConjuntosPreguntas()
        {
            var nombres = ControladorAdministrativo.GetNombresConjuntosPreguntas().ToList();
            // OpentDb es el unico conjunto actualmente en la DB
            CollectionAssert.Contains(nombres, "OpentDb");
        }

        [TestMethod]
        public void TestSetAdminYGetUsuario()
        {
            var id = "leo";
            var pass = "leonardo";

            ControladorAdministrativo.SetAdministrador(id);
            var usr = ControladorAdministrativo.AutenticarUsuario(id, pass);
            Assert.Equals(usr.Administrador, true);

            ControladorAdministrativo.SetNoAdministrador(id);
            usr = ControladorAdministrativo.AutenticarUsuario(id, pass);
            Assert.Equals(usr.Administrador, false);
        }


        [TestMethod]
        public void TestGetRanking()
        {
            var idUser = "leo";
            var idInexsistente = "UsuarioQueNoExiste";
            var count = ControladorAdministrativo.GetRanking(idUser).ToList().Count;
            Assert.IsTrue(count >= 1);

            count = ControladorAdministrativo.GetRanking(idInexsistente).ToList().Count;
            Assert.AreEqual(count, 0);
        }


        [TestMethod]
        public void TestGuardarUsuario()
        {
            try { ControladorAdministrativo.GuardarUsuario("leo", "leonardo"); }
            catch (UsrYaExisteException) { }
        }






    }
}
