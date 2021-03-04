using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trabajo_Integrador.Controladores.Bitacora;

namespace UnitTests
{
    [TestClass]
    public class TestBitacoraFile
    {

        /// Como todos los metodos de bitacora file estan basados en ObtenerTodos() y la libreria Linq
        /// solo testeamos este metodo y GuardarLog

        [TestMethod]
        public void TestObtenerTodos()
        {
            var bitacora = new BitacoraFile();
            Assert.IsNotNull(bitacora.ObtenerTodos());
        }

        [TestMethod]
        public void TestGuardarLog()
        {
            var bitacora = new BitacoraFile();
            var siguienteId = bitacora.ObtenerSiguienteId();
            var log = new Log(siguienteId, DateTime.Now, String.Format("Un error de prueba con id {0}", siguienteId));

            bitacora.GuardarLog(log);

            Assert.AreEqual(siguienteId + 1, bitacora.ObtenerSiguienteId());
        }
    }
}
