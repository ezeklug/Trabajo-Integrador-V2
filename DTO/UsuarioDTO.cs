using System;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.DTO
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string Contrasenia { get; set; }
        public Boolean Administrador { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pContrasenia"></param>
        public UsuarioDTO(string pId, string pContrasenia)
        {
            Id = pId;
            Contrasenia = pContrasenia;
            Administrador = false;
        }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Contrasenia = usuario.Contrasenia;
            this.Administrador = usuario.Administrador;
        }
    }
}
