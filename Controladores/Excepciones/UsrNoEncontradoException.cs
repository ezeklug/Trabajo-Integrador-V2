using System;

namespace Trabajo_Integrador.Controladores.Excepciones
{
    public class UsrNoEncontradoException : Exception
    {
        public UsrNoEncontradoException(string message) : base(message)
        {
        }

        public UsrNoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
