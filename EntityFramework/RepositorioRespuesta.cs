using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioRespuesta : Repository<Respuesta, TrabajoDbContext>
    {
        public RepositorioRespuesta(TrabajoDbContext pContext) : base(pContext) { }
    }
}
