using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    internal class CreadorUrlOpentDB : ICreadorUrl
    {
        public string CrearUrl(int pCantidad, ConjuntoPreguntas pConjunto)
        {
            var url = string.Format("https://opentdb.com/api.php?amount={0}&category={1}&difficulty={2}&type=multiple",
                                pCantidad,
                                pConjunto.Categoria.ProviderId,
                                pConjunto.Dificultad.Id);
            return url;
        }
    }
}
