using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trabajo_Integrador.Controladores.Bitacora;

namespace UnitTests
{
    [TestClass]
    class TestBitacoraFile
    {

        //TODO: testear cuando se quiere obtener un log y el archivo no existe 

        [TestMethod]
        public void TestGuardarLog()
        {
            var log = new Log(1, DateTime.Now, "UN error de prueba");
            var bitacora = new BitacoraFile();

            bitacora.GuardarLog(log);

        }
    }
}
