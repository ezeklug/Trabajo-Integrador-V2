using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioCategorias : Repository<CategoriaPregunta,TrabajoDbContext>
    {
        public RepositorioCategorias(TrabajoDbContext pContext) : base(pContext) { }
    }
}
