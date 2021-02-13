using System;

namespace Trabajo_Integrador.Dominio
{
    /// <summary>
    /// Clase que almacena datos pertenecientes a un usuario.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Properties.
        /// </summary>
        public string Id { get; set; }
        public string Contrasenia { get; set; }
        public Boolean Administrador { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pContrasenia"></param>
        public Usuario(string pId, string pContrasenia)
        {
            Id = pId;
            Contrasenia = pContrasenia;
            Administrador = false;
        }

        public Usuario() { }
    }
}
