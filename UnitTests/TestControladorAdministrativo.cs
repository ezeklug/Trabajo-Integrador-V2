using NUnit.Framework;
using System.Linq;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Excepciones;


namespace UnitTests
{
    class TestControladorAdministrativo
    {
        [Test]
        public static void TestGetUsuario()
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


        [Test]
        public static void TestGetUsuarios()
        {
            var count = ControladorAdministrativo.GetUsuarios().ToList().Count;
            Assert.GreaterOrEqual(count, 1);
        }


        [Test]
        public static void TestGetPreguntas()
        {
            var count = ControladorAdministrativo.GetPreguntas().ToList().Count;
            Assert.GreaterOrEqual(count, 1);
        }


        [Test]
        public static void TestGetExamenes()
        {
            var count = ControladorAdministrativo.GetExamenes().ToList().Count;
            Assert.GreaterOrEqual(count, 1);
        }

        [Test]
        public static void TestGetNombresConjuntosPreguntas()
        {
            var nombres = ControladorAdministrativo.GetNombresConjuntosPreguntas().ToList();
            // OpentDb es el unico conjunto actualmente en la DB
            Assert.Contains("OpentDb", nombres);
        }

        [Test]
        public static void TestSetAdminYGetUsuario()
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


        [Test]
        public static void TestGetRanking()
        {
            var idUser = "leo";
            var idInexsistente = "UsuarioQueNoExiste";
            var count = ControladorAdministrativo.GetRanking(idUser).ToList().Count;
            Assert.GreaterOrEqual(count, 1);

            count = ControladorAdministrativo.GetRanking(idInexsistente).ToList().Count;
            Assert.AreEqual(count, 0);
        }


        [Test]
        public static void TestGuardarUsuario()
        {
            try { ControladorAdministrativo.GuardarUsuario("leo", "leonardo"); }
            catch (UsrYaExisteException) { }
        }






    }
}
