﻿using System;
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
                   listaPreguntas= (List<Pregunta>)UoW.RepositorioPreguntas.GetAll();
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
                    listaExamenes = (List<Examen>)UoW.ExamenRepository.GetAll();
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
                    conjunto.TiempoEsperadoRespuesta = pTiempo;
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
        /// Devuelve todos los logs
        /// </summary>
        /// <returns></returns>
        public List<Log> getLogs()
        {
            return Bitacora.Obtener();
        }

        /// <summary>
        /// Setea un usuario como no administrador
        /// </summary>
        /// <param name="pUsuario">Id del usuario</param>
        public void SetNoAdministrador(string pUsuario)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario dBUsuario = UoW.RepositorioUsuarios.Get(pUsuario);
                    dBUsuario.Administrador = false;
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
        /// Chequea que el usuario y contrasenia de un usuario existan
        /// </summary>
        /// <param name="pUsuarioId"></param>
        /// <param name="pContrasenia"></param>
        /// <returns></returns>
        public Boolean UsuarioValido(string pUsuarioId, string pContrasenia)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usr = new Usuario(pUsuarioId, pContrasenia);    //Necesario por el hash de contrasenia
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
        /// Chequea si un usuario existe en la base de datos
        /// </summary>
        /// <param name="pUsuarioId"></param>
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


        /// <summary>
        /// Devuelve verdadero si un usuario es administrador
        /// </summary>
        /// <param name="pNombreUsuario"></param>
        /// <returns></returns>
        public Boolean EsAdministrador(string pNombreUsuario) 
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Usuario usrDb = UoW.RepositorioUsuarios.Get(pNombreUsuario);
                    if (usrDb.Administrador == true)
                    {
                        return true;
                    }
                    else return false;
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

