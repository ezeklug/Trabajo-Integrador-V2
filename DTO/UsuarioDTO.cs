using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Utils;

namespace Trabajo_Integrador.DTO
{
    public class UsuarioDTO
    {
        public String Id { get; set; }
        public String Contrasenia { get; set; }
        public Boolean Administrador { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pContrasenia"></param>
        public UsuarioDTO(string pId, string pContrasenia)
        {
            Id = pId;
            Contrasenia = PasswordHasher.CreateMD5
                (pContrasenia);
            Administrador = false;
        }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Contrasenia = PasswordHasher.CreateMD5(usuario.Contrasenia);
            this.Administrador = usuario.Administrador;
        }
    }
}
