using System;

namespace Trabajo_Integrador.Controladores.Excepciones
{
    public class UsrYaExisteException : Exception
    {
        public UsrYaExisteException(string message) : base(message)
        {
        }

        public UsrYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
