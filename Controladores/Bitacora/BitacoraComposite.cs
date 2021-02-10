using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Controladores.Bitacora
{
    public abstract class BitacoraComposite : IBitacora
    {

        public virtual bool IsComposite() 
        {
            return true;
        }

        public abstract void GuardarLog(Log pLog);
        public abstract Log Obtener(int pId);

        public abstract ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta);

        public abstract int ObtenerSiguienteId();

        public abstract ICollection<Log> ObtenerTodos();
    }
}
