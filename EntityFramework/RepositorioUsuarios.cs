using System.Linq;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioUsuarios : Repository<Usuario, TrabajoDbContext>
    {
        public RepositorioUsuarios(TrabajoDbContext pContext) : base(pContext) { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <returns>Usuario si existe pUsuario. En otro caso null</returns>
        public Usuario AutenticarUsuario(Usuario pUsuario)
        {
            return this.iDBSet.FirstOrDefault(u => (u.Id == pUsuario.Id) & (u.Contrasenia == pUsuario.Contrasenia));
        }
    }
}
