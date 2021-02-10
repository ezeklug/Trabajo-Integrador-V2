﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.EntityFramework;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioExamen : Repository<Examen,TrabajoDbContext>{
        public RepositorioExamen(TrabajoDbContext pContext) : base(pContext)
            { }
        public List<Examen> SelectAll(string pId)
        {
            return this.iDBSet.Where(c => c.UsuarioId == pId).ToList();
        }
        public override IEnumerable<Examen> GetAll()
        {
            return this.iDBSet.Include("Usuario").ToList();
        }

        public override Examen Get(int pId)
        {
            return this.iDBSet.Include("ExamenPreguntas").FirstOrDefault(e => e.Id == pId);
        }

    }
}

