﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trabajo_Integrador.Controladores.Bitacora;

namespace UnitTests
{
    [TestClass]
    public class TestBitacoraFile
    {
        [TestMethod]
        public void TestObtenerTodos_DevuelveTodosLosLogs()
        {
            var bitacora = new BitacoraFile();
            Assert.IsNotNull(bitacora.ObtenerTodos());
        }

        [TestMethod]
        public void TestGuardarLog_LogValido_GuardaUnLog()
        {
            var bitacora = new BitacoraFile();
            var siguienteId = bitacora.ObtenerSiguienteId();
            var log = new Log(siguienteId, DateTime.Now, String.Format("Un error de prueba con id {0}", siguienteId));
            bitacora.GuardarLog(log);
            Assert.AreEqual(siguienteId + 1, bitacora.ObtenerSiguienteId());
        }
    }
}
