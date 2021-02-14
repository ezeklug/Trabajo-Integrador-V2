using System;
using Trabajo_Integrador.Controladores.Excepciones;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores.Utils
{

    /// <summary>
    /// Encargada de crear y autenticar usuarios
    /// </summary>
    static class Autenticador
    {
        public static Usuario ConstruirUsuario(String pUsuario, String pContrasenia)
        {
            return new Usuario(pUsuario, PasswordHasher.HashMD5(pContrasenia));
        }


        /// <summary>
        /// Actualiza y autentica un usuario con los valores de la base de datos
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <exception cref="UsrNoEncontradoException">pUsuario no esta en la bd</exception>
        /// <returns>Un usuario de la base de datos</returns>
        public static Usuario AutenticarUsuario(Usuario pUsuario)
        {
            Usuario usr = null;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    usr = UoW.RepositorioUsuarios.AutenticarUsuario(pUsuario);
                }
            }
            if (usr == null)
            {
                throw new UsrNoEncontradoException("Credenciales incorrectas");
            }
            return usr;
        }



        /// <summary>
        /// Obtiene un usuario de la bd
        /// </summary>
        /// <exception cref="UsrNoEncontradoException"> Si el usuario no existe</exception>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public static Usuario GetUsuario(String pUsuario)
        {
            Usuario usr = null;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    usr = UoW.RepositorioUsuarios.Get(pUsuario);
                }
            }
            if (usr == null)
            {
                throw new UsrNoEncontradoException(String.Format("{0} No registrado", pUsuario));
            }
            return usr;
        }




    }
}
