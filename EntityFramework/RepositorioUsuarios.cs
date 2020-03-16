using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo_Integrador.Dominio;
using System.Threading.Tasks;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioUsuarios : Repository<Usuario,TrabajoDbContext>
    {
        public RepositorioUsuarios(TrabajoDbContext pContext) : base(pContext) { }
    }
}
