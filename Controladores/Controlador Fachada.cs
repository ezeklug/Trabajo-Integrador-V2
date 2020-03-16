using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var db = new TrabajoDbContext())
            {
                return db.Examenes.Where(e => e.Usuario.Id == pUsuario).OrderBy(ex => ex.Puntaje).ToList<Examen>();
            }
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
            ConjuntoPreguntas conjunto;
            CategoriaPregunta categoria;
            Dificultad dificultad;

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    conjunto = UoW.RepositorioConjuntoPregunta.Get(pConjunto);
                    categoria = UoW.RepositorioCategorias.Get(pCategoria);
                    dificultad = UoW.RepositorioDificultades.Get(pDificultad);
                }
            }

             return controladorExamen.InicializarExamen(pCantidad.ToString(), conjunto.Id, categoria.Id, dificultad.Id);
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
        /// Metodo que devuelve todas los conjuntos de preguntas cargados en base de datos
        /// </summary>
        /// <returns></returns>
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

        public Boolean UsuarioValido(string pNombreUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usrDb = UoW.RepositorioUsuarios.Get(pNombreUsuario);
                    if (usrDb.Id== pNombreUsuario)
                    {
                        return true;
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
        public Boolean RespuestaCorrecta(Examen pExamen, Pregunta pPregunta, String pRespuesta)
        {
            return controladorExamen.RespuestaCorrecta(pExamen, pPregunta, pRespuesta);
        }

        /// <summary>
        /// Metodo que permite cargar preguntas desde una pagina de preguntas hacia la base de datos.
        /// </summary>
        /// <param name="pCantidad"></param>
        /// <param name="pConjunto"></param>
        /// <param name="pCategoria"></param>
        /// <param name="pDificultad"></param>
        public void CargarPreguntas(string pCantidad,string pConjunto,string pCategoria,string pDificultad)
        {
            controladorAdministrativo.CargarPreguntas(pCantidad, pConjunto, pCategoria, pDificultad);
        }



        public List<Examen> GetExamenes()
        {
            return controladorAdministrativo.GetExamenes();
        }

        public void ModificarTiempo(string pConjuntoPreguntas, float pTiempo)
        {
            controladorAdministrativo.ModificarTiempo(pConjuntoPreguntas, pTiempo);

        }

        public void SetAdministrador(string pUsuario)
        {
            controladorAdministrativo.SetAdministrador(pUsuario);
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

        public void GetPreguntasOnline(string pCantidad, string pConjunto, string pCategoria, string pDificultad)
        {
             controladorPreguntas.GetPreguntasOnline(pCantidad, pConjunto, pCategoria, pDificultad);
        }

    }
}
