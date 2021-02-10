using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador.Controladores.Bitacora
{
    /// <summary>
    /// Almacena los logs en la base de datos
    /// </summary>
    public class BitacoraDb : BitacoraComposite
    {
        public override void GuardarLog(Log pLog)
        {
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    UoW.RepositorioLogs.Add(pLog);
                }
            }
        }

        public override ICollection<Log> ObtenerTodos()
        {
            ICollection<Log> logs;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    logs = UoW.RepositorioLogs.GetAll().ToArray();
                }

            }
            return logs;

        }

        public override Log Obtener(int pId)
        {
            Log log;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    log = UoW.RepositorioLogs.Get(pId);
                }
            }

            return log;
        }

        public override ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta)
        {
            ICollection<Log> logs;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    logs = UoW.RepositorioLogs.Obtener(pDesde, pHasta);
                }
            }
            return logs;
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override int ObtenerSiguienteId()
        {
            int i = 0;
            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    i = UoW.RepositorioLogs.ObtenerMaxId();
                }
            }

            return i;
        }

        public BitacoraDb()
        {
        }
    }
}
