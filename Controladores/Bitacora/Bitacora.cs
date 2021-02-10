using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Controladores.Bitacora
{

    /// <summary>
    /// Guarda logs en cualquier clase que implemente IBitacora
    /// Por default las guarda en un archivo y db
    /// </summary>
    public class Bitacora : IBitacora
    {
        private List<BitacoraComposite> bitacoras;

        public void GuardarLog(String pDescripcion)
        {
            Log log = new Log();
            log.Id = this.ObtenerSiguienteId();
            log.Fecha = DateTime.Now;
            log.Descripcion = pDescripcion;
            this.GuardarLog(log);
        }

        public void GuardarLog(Log pLog)
        {
            foreach (var b in bitacoras)
            {
                b.GuardarLog(pLog);
            }
        }

        public Log Obtener(int pId)
        {
            Log log = null;
            int i = 0;
            while ((i < bitacoras.Count) && (log == null))
            {
                log = bitacoras[i].Obtener(pId);
                i++;
            }

            return log;
        }

        public ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta)
        {
            ICollection<Log> logs = null;
            int i = 0;
            while (logs == null)
            {
                logs = bitacoras[i].Obtener(pDesde, pHasta);
                i++;
            }

            return logs;
        }

        public ICollection<Log> ObtenerTodos()
        {
            ICollection<Log> logs = null;
            int i = 0;
            while (logs == null)
            {
                logs = bitacoras[i].ObtenerTodos();
                i++;
            }

            return logs;
        }


        public void AgregarBitacora(BitacoraComposite pBitacora)
        {
            bitacoras.Add(pBitacora);
        }

        public int ObtenerSiguienteId()
        {
            int[] ids = new int[bitacoras.Count];
            int i = 0;
            foreach(var b in bitacoras)
            {
                ids[i] = b.ObtenerSiguienteId();
            }
            return ids.Max() + 1;
        }

        public Bitacora()
        {
            bitacoras.Add(new BitacoraDb());
            bitacoras.Add(new BitacoraFile());
        }
    }
}
