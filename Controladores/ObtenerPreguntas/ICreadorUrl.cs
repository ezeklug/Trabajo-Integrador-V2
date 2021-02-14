using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Controladores.ObtenerPreguntas
{
    public interface ICreadorUrl
    {
        string CrearUrl(int pCantidad, ConjuntoPreguntas pConjunto);

    }
}
