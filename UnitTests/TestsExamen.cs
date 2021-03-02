using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Controladores.Excepciones;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;
using System.Data.Common;


namespace UnitTests
{
    [TestClass]
    public class TestsExamen
    {
        private TrabajoDbContext _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = new TrabajoDbContext(Effort.DbConnectionFactory.CreateTransient());
        }

       public Examen testExamen = new Examen
        {
            Id = 1,
            UsuarioId = "TestPerson",
            Fecha = DateTime.Now,
        };

      public  Usuario TestUsuario = new Usuario();
        [TestMethod]
        public void AsociarExamenPregunta_UnExamenYListaPreguntas_DevuelveTrue()
        {
          //  Examen = 
        }

        [TestMethod]
        public void InicializarExamen_CantidadConjuntoCategoriaDificultadPreguntas_DevuelveTrue()
        {

        }


        [TestMethod]
        public void addExamen_validExamen_returnTrue()
        {
            //Arrange
            var examenes = new RepositorioExamen(_context);
            var fakeId = 5;

            //Act
            examenes.Add(testExamen);
            _context.SaveChanges();
            //Assert
           
        }
    }
}
