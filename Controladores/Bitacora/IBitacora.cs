using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Controladores.Bitacora
{
    public interface IBitacora
    {
        void GuardarLog(Log pLog);
        ICollection<Log> ObtenerTodos();
        Log Obtener(int pId);
        ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta);

        /// <summary>
        /// Devuelve el siguiente Id que se debe usar para el guardar el proximo log
        /// </summary>
        /// <returns></returns>
        int ObtenerSiguienteId();
    }
}
