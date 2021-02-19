using System;
using System.Collections.Generic;

namespace Trabajo_Integrador.Controladores.Bitacora
{

    /// <summary>
    /// Implementacion del patron composite.
    /// Cualquier clase que actue como bitacora debe heredar de esta
    /// </summary>
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
