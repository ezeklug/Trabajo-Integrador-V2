using System;

namespace Trabajo_Integrador.Controladores.Bitacora
{
    /// <summary>
    /// Clase log para guardar cambios y logeos
    /// </summary>
    public class Log
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public String Descripcion { get; set; }

        public Log(int pId, DateTime pFecha, String pDescripcion)
        {
            this.Id = pId;
            this.Fecha = pFecha;
            this.Descripcion = pDescripcion;
        }
        public Log() { }
    }
}
