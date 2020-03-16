using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
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
        public String Id { get; set; }
        public String Contrasenia { get; set; }
        public Boolean Administrador { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="pContrasenia"></param>
        public Usuario(string pId, string pContrasenia)
        {
            Id = pId;
            Contrasenia = PasswordHasher.CreateMD5
                (pContrasenia);
            Administrador = false;
        }

        public Usuario() { }
    }
}
