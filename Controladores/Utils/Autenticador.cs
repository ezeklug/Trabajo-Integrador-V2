using System;
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
        /// Devuelve verdadero si un usuario es valido
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns></returns>
        public static bool AutenticarUsuario(Usuario pUsuario)
        {
            Usuario usr = null;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    usr = UoW.RepositorioUsuarios.Get(pUsuario.Id);
                }
            }
            return usr != null;
        }




        public static bool UsuarioEsAdmin(Usuario pUsuario)
        {
            bool res = false;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    res = UoW.RepositorioUsuarios.Get(pUsuario.Id).Administrador;
                }
            }
            return res;
        }



    }
}
