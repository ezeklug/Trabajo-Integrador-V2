using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores
{
    /// <summary>
    /// Clase utilizada por el administrador.
    /// </summary>
    public class ControladorAdministrativo
    {
        ControladorPreguntas iControladorPreguntas = new ControladorPreguntas();
        public void CargarPreguntas(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            iControladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
        }
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    listaUsuarios = (List<Usuario>)UoW.RepositorioUsuarios.GetAll();
                }
            }

            return listaUsuarios;
        }


        /// <summary>
        /// Obtiene todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Pregunta> GetPreguntas()
        {
            List<Pregunta> listaPreguntas = new List<Pregunta>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    listaPreguntas = (List<Pregunta>)UoW.RepositorioPreguntas.GetAll();
                }
            }

            return listaPreguntas;
        }
        public List<Examen> GetExamenes()
        {
            List<Examen> listaExamenes = new List<Examen>();
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    listaExamenes = db.Examenes.Include("Usuario").ToList<Examen>();
                    //listaExamenes = (List<Examen>)UoW.ExamenRepository.GetAll();
                }
            }

            return listaExamenes;

        }
        /// <summary>
        /// Metodo que devuelve todas las categorias cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPregunta> GetCategorias()
        {
            return iControladorPreguntas.GetCategorias();
        }

        /// <summary>
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
        public List<ConjuntoPreguntas> GetConjuntoPreguntas()
        {
            return iControladorPreguntas.GetConjuntoPreguntas();
        }
        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<Dificultad> GetDificultades()
        {
            return iControladorPreguntas.GetDificultades();
        }
        /// <summary>
        /// Metodo que modifica el tiempo esperado por respuesta de un conjunto pasado como parametro.
        /// </summary>
        /// <param name="pConjuntoPreguntas"></param>
        /// <param name="pTiempo"></param>
        public void ModificarTiempo(string pConjuntoPreguntas, float pTiempo)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    ConjuntoPreguntas conjunto = UoW.RepositorioConjuntoPregunta.Get(pConjuntoPreguntas);
                    conjunto.Id = pConjuntoPreguntas;
                    UoW.Complete();
                }
            }



        }
        /// <summary>
        /// Metodo que establece como admin a un usuario pasado como parametro
        /// </summary>
        /// <param name="pUsuario"></param>
        public void SetAdministrador(string pUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario dBUsuario = UoW.RepositorioUsuarios.Get(pUsuario);
                    dBUsuario.Administrador = true;
                    UoW.Complete();
                }
            }

        }

        /// <summary>
        /// Metodo que Agrega un usuario en la BD si este no existe.
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pContrasenia"></param>
        public void GuardarUsuario(string pUsuario, string pContrasenia)
        {
            Usuario usuario = new Usuario(pUsuario, pContrasenia);
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    if (UoW.RepositorioUsuarios.Get(usuario.Id) == null)
                    {
                        UoW.RepositorioUsuarios.Add(usuario);
                    }
                    UoW.Complete();
                }
            }
        }
        /// <summary>
        /// Metodo que devuelve los examenes correspondientes a un usuario, ordenados por puntaje descendentemente
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public List<Examen> GetRanking(string pUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    List<Examen> examenes = UoW.ExamenRepository.SelectAll(pUsuario);
                    examenes.Sort((a, b) => b.Puntaje.CompareTo(a.Puntaje));
                    return examenes;
                }
            }
        }
    }
}

