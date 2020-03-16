using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioDificultades : Repository<Dificultad,TrabajoDbContext>
    {
       
            public RepositorioDificultades(TrabajoDbContext pContext) : base(pContext) { }
        
    }
}
