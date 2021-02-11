﻿using NUnit.Framework;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.DTO;

namespace UnitTests
{
    public class TestControladorExamen
    {


        //[Test]
        public void Test1()
        {
            ControladorExamen controladorExamen = new ControladorExamen();
            Examen examen = controladorExamen.InicializarExamen("10", "OpentDB", "27", "easy");


            ExamenDTO pExamen = new ExamenDTO(examen);
            controladorExamen.FinalizarExamen(pExamen);
            Assert.Pass();
        }

    }
}
