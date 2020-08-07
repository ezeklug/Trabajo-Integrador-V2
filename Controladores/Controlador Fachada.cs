using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;



namespace Trabajo_Integrador.Controladores
{
    public class ControladorFachada
    {
        ///Atributos
        ControladorExamen controladorExamen;
        ControladorAdministrativo controladorAdministrativo;
        ControladorPreguntas controladorPreguntas;


        public ControladorFachada()
        {
            controladorAdministrativo = new ControladorAdministrativo();
            controladorExamen = new ControladorExamen();
            controladorPreguntas = new ControladorPreguntas();
        }


        /// <summary>
        /// Devuevlve el ranking de los examenes de un usuario.
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        /// <returns></returns>
        public List<Examen> GetRanking(String pUsuario)
        {
            List<Examen> listaExamenes = new List<Examen>();
           try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        listaExamenes = (List<Examen>)UoW.ExamenRepository.GetAll();
                        listaExamenes = listaExamenes.FindAll(ex => ex.Usuario.Id == pUsuario).OrderBy(ex => ex.Puntaje).ToList<Examen>();
                    }
                }
            }
            catch(Exception ex)
            {
                Bitacora.GuardarLog("ControladorFachada.GetRanking"+ ex.Message);
            }
            
            return listaExamenes;
        }


        /// <summary>
        /// Obtiene el tiempo limite que está asociado a un examen
        /// </summary>
        /// <param name="unExamen"></param>
        /// <returns></returns>
        public float GetTiempoLimite(Examen unExamen)
        {
            return controladorExamen.GetTiempoLimite(unExamen);
        }




        /// <summary>
        /// Da comienzo a un examen. Asocia el examen a un usuario
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pExamen"></param>
        public void InicarExamen(String pNombreUsuario, Examen pExamen)
        {
            Usuario usuario;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {

                    usuario = UoW.RepositorioUsuarios.Get(pNombreUsuario);
                }
            }

            controladorExamen.IniciarExamen(usuario, pExamen);
        }


        /// <summary>
        /// Devuelve una lista con todos los logs
        /// </summary>
        /// <returns></returns>
        public List<Log> getLogs()
        {
            return controladorAdministrativo.getLogs();
        }



        /// <summary>
        /// Devuelve la cantidad de preguntas que pertecenientes a una categoria
        /// </summary>
        /// <param name="pIdCategoria">Id de la categoria</param>
        /// <returns>Cantidad</returns>
        public int CantidadDePreguntasParaCategoria(String pIdCategoria)
        {
            return controladorPreguntas.CantidadDePreguntasParaCategoria(pIdCategoria);
        }

        /// <summary>
        /// Metodo que crea un examen sin asociarlo a un usuario
        /// </summary>
        /// <param name="pCantidad">Cantidad de preguntas</param>
        /// <param name="pConjunto">OpentDb</param>
        /// <param name="pCategoria">Id Categoria</param>
        /// <param name="pDificultad">Id Dificultad</param>
        /// <returns></returns>
        /// 
        public Examen InicializarExamen(int pCantidad, String pConjunto, string pCategoria, string pDificultad)
        {
            return controladorExamen.InicializarExamen(pCantidad.ToString(), pConjunto, pCategoria, pDificultad);
        }


        /// <summary>
        /// Metodo que finaliza un examen y lo guarda en la base de datos
        /// </summary>
        /// <param name="pExamen"></param>
        public void FinalizarExamen(Examen pExamen)
        {
            controladorExamen.FinalizarExamen(pExamen);
        }

        /// <summary>
        /// Metodo que devuelve una lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuarios()
        {
            return controladorAdministrativo.GetUsuarios();
        }

        /// <summary>
        /// Metodo que devuelve todas las categorias cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<CategoriaPregunta> GetCategorias()
        {
            return controladorAdministrativo.GetCategorias();
        }



        /// <summary>
        /// Devuelve todas las categorias que tengan mas o igual a N preguntas
        /// </summary>
        /// <param name="n">Cantida de preguntas</param>
        /// <returns>Lista de Categorias</returns>
        public List<CategoriaPregunta> GetCategoriaPreguntasConNPreguntas(int n)
        {
            return controladorPreguntas.GetCategoriasConMasDeNPreguntas(n);
        }



        /// <summary>
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
        /// 

        public List<ConjuntoPreguntas> GetConjuntoPreguntas()
        {
            return controladorAdministrativo.GetConjuntoPreguntas();
        }
        /// <summary>
        /// Metodo que devuelve todas las dificultades cargadas en base de datos
        /// </summary>
        /// <returns></returns>
        public List<Dificultad> GetDificultades()
        {
            return controladorAdministrativo.GetDificultades();
        }
        /// <summary>
        /// Metodo que guarda un usuario en la base de datos de usuarios
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <param name="contrasenia"></param>
        public void GuardarUsuario(string usuarioNombre, string contrasenia)
        {
            controladorAdministrativo.GuardarUsuario(usuarioNombre, contrasenia);
        }



        /// <summary>
        /// Chequea si un usuario ya existe en la base de datos
        /// </summary>
        /// <param name="pUsuarioId"></param>
        /// <param name="pContrasenia"></param>
        /// <returns>Verdadero si usuario y contraseña existen </returns>
        public Boolean UsuarioValido(string pUsuarioId, string pContrasenia)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usr = new Usuario(pUsuarioId, pContrasenia);
                    Usuario usrDb = UoW.RepositorioUsuarios.Get(pUsuarioId);
                    if (usrDb != null)
                    {
                        if (usrDb.Contrasenia == usr.Contrasenia)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;


                }
            }
        }

        /// <summary>
        /// Devuleve true si el nombre de usuario ya existe en BD.
        /// </summary>
        /// <param name="pNombreUsuario"></param>
        /// <returns></returns>
        public Boolean UsuarioExiste(string pNombreUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usrDb = UoW.RepositorioUsuarios.Get(pNombreUsuario);

                    if (usrDb != null)
                    {
                        if (usrDb.Id == pNombreUsuario)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
            }

        }

        public Boolean EsAdministrador(string nombreUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usrDb = UoW.RepositorioUsuarios.Get(nombreUsuario);
                    if (usrDb.Administrador == true)
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }

        /// <summary>
        /// Metodo que determina si una respuesta es correcta o no 
        /// Almacena el resultado de la respuesta
        /// </summary>
        /// <param name="pExamen"></param>
        /// <param name="pPregunta"></param>
        /// <param name="pRespuesta"></param>
        /// <returns></returns>
        public Boolean RespuestaCorrecta(Examen pExamen, Pregunta pPregunta, int idRespuesta)
        {
            return controladorExamen.RespuestaCorrecta(pExamen, pPregunta, idRespuesta);
        }

        /// <summary>
        /// Metodo que permite cargar preguntas desde una pagina de preguntas hacia la base de datos.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public void CargarPreguntas(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            controladorAdministrativo.CargarPreguntas(pCantidad, pConjunto, pCategoria, pDificultad);
        }




        /// <summary>
        /// Devuelve todos los examenes
        /// </summary>
        /// <returns></returns>
        public List<Examen> GetExamenes()
        {
            return controladorAdministrativo.GetExamenes();
        }


        /// <summary>
        /// Modifica el tiempo de un conjunto de preguntas
        /// </summary>
        /// <param name="pConjuntoPreguntas">Conjunto a modificar</param>
        /// <param name="pTiempo">Tiempo por pregunta</param>
        public void ModificarTiempo(string pConjuntoPreguntas, float pTiempo)
        {
            controladorAdministrativo.ModificarTiempo(pConjuntoPreguntas, pTiempo);

        }



        /// <summary>
        /// Setea un usuario como  admin
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public void SetAdministrador(string pUsuario)
        {
            controladorAdministrativo.SetAdministrador(pUsuario);
        }


        /// <summary>
        /// Setea un usuario como no admin
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public void SetNoAdministrador(string pUsuario)
        {
            controladorAdministrativo.SetNoAdministrador(pUsuario);
        }

        /// <summary>
        /// Obtiene todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Pregunta> GetPreguntas()
        {
            return controladorAdministrativo.GetPreguntas();
        }

        public List<Pregunta> GetPreguntasRandom(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
            return controladorPreguntas.GetPreguntasRandom(pCantidad, pConjunto, pCategoria, pDificultad);
        }


        /// <summary>
        /// Carga preguntas desde un servicio  online a la base de datos
        /// Devuelve el numero de preguntas cargadas con exito
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public int GetPreguntasOnline(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
             return controladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
        }
        /// <summary>
        /// Metodo que sirve para obtener todas las respuestas asociadas a una preguna
        /// </summary>
        /// <param name="pPregunta"></param>
        /// <returns>Una lista de respuestas</returns>
        public List<Respuesta> RespuestasDePregunta(Pregunta pPregunta)
        {
            return controladorPreguntas.RespuestasDePregunta(pPregunta);
        }

    }
}
