//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Trabajo_Integrador.Dominio;

//namespace Trabajo_Integrador.EntityFramework
//{
//    public class RepositorioRespuesta : Repository<Respuesta, TrabajoDbContext>
//    {
//        public RepositorioRespuesta(TrabajoDbContext pContext) : base(pContext) { }

//        public override IEnumerable<Respuesta> GetAll()
//        {
//            return this.iDBSet.Include("Pregunta").ToList();
//        }
//     /*   public override Respuesta Get(int pId)
//        {
//            Respuesta res=iDBSet.Find(pId);
//            return this.iDBSet.Include("Pregunta").Where(r=>r.Id==res.Id).First();
//        }*/

//    }
//}
