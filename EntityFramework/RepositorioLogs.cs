using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioLogs : Repository<Log, TrabajoDbContext>
    {
        public RepositorioLogs(TrabajoDbContext pContext) : base(pContext) { }
    }
}
