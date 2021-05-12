using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Controladores.Bitacora;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioLogs : Repository<Log, TrabajoDbContext>
    {
        public RepositorioLogs(TrabajoDbContext pContext) : base(pContext) { }

        public ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta)
        {
            return this.iDBSet.Where(l => (l.Fecha <= pHasta) && (l.Fecha > pDesde)).ToArray();
        }

        public int ObtenerMaxId()
        {
            try
            {
                return this.iDBSet.Max(l => l.Id);
            }
            catch(Exception)
            {
                return 0;
            }
        }
    }
}
