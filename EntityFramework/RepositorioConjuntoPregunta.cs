using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.EntityFramework
{
    public class RepositorioConjuntoPregunta : Repository<ConjuntoPreguntas, TrabajoDbContext>
    {
        public RepositorioConjuntoPregunta(TrabajoDbContext pContext) : base(pContext) { }


        public ConjuntoPreguntas ObtenerConjuntoPorDificultadYCategoria(String pNombreConjunto, String pIdDificultad, String pIdCategoria)
        {
            return this.iDBSet.Include("Dificultad").Include("Categoria").FirstOrDefault(c =>
            (c.Nombre == pNombreConjunto) &&
            (c.Dificultad.Id == pIdDificultad) &&
            (c.Categoria.Id == pIdCategoria));
        }


        public ICollection<CategoriaPregunta> CategoriasDeUnConjunto(String pNombreConjunto)
        {
            var conjunto = this.iDBSet.Where(c => c.Nombre == pNombreConjunto);
            var categorias = new HashSet<CategoriaPregunta>();

            foreach (var c in conjunto)
            {
                categorias.Add(c.Categoria);
            }
            return categorias;
        }


        public ICollection<Dificultad> DificultadesDeUnConjunto(String pNombreConjunto)
        {

            var conjunto = this.iDBSet.Include(c => c.Dificultad).Where(c => c.Nombre == pNombreConjunto);
            var dificultades = new HashSet<Dificultad>();

            foreach (var c in conjunto)
            {
                dificultades.Add(c.Dificultad);
            }

            return dificultades;
        }


        public IEnumerable<String> NombresDeConjuntos()
        {
            var resultado = this.iDBSet.GroupBy(c => c.Nombre);
            var nombres = new HashSet<String>();

            foreach (var r in resultado)
            {
                nombres.Add(r.Key);
            }
            return nombres;
        }

        public void AgregarConjuntos(IEnumerable<ConjuntoPreguntas> pConjuntos)
        {
            foreach (var conjunto in pConjuntos)
            {
                try
                {
                    var categoria = this.iDBSet.First(c => c.Categoria.Id == conjunto.Categoria.Id).Categoria;
                    conjunto.Categoria = categoria;
                }
                catch (InvalidOperationException e)
                {

                }

                try
                {
                    var dificultad = this.iDBSet.First(c => c.Dificultad.Id == conjunto.Dificultad.Id).Dificultad;
                    conjunto.Dificultad = dificultad;
                }
                catch (InvalidOperationException e)
                {

                }
                Console.WriteLine($"Va a guardar : {conjunto.Id}");
                this.iDBSet.Add(conjunto);
            }

        }


        public CategoriaPregunta GetCategoria(ConjuntoPreguntas pConjunto)
        {
            try
            {
                return this.iDBSet.First(c => c.Categoria.Id == pConjunto.Categoria.Id).Categoria;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }
        public Dificultad GetDificultad(ConjuntoPreguntas pConjunto)
        {
            try
            {
                return this.iDBSet.First(c => c.Dificultad.Id == pConjunto.Dificultad.Id).Dificultad;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }


        public void ModificarTiempoConjunto(String pNombreConjunto, float pTiempo)
        {
            var conjuntos = this.iDBSet.Where(c => c.Nombre == pNombreConjunto);
            foreach (var c in conjuntos)
            {
                c.TiempoEsperadoRespuesta = pTiempo;
            }
        }

    }
}
