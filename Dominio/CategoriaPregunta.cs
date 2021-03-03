using Trabajo_Integrador.DTO;
namespace Trabajo_Integrador.Dominio
{
    /// <summary>
    /// Clase que indica la categoria de un conjunto
    /// </summary>
    public class CategoriaPregunta
    {

        public string iCategoria { get; set; }

        public string Id
        {
            get { return iCategoria; }
            set { iCategoria = value; }
        }



        public string ProviderId { get; set; }

        public CategoriaPregunta(string pCategoria, string pProviderId)
        {
            iCategoria = pCategoria;
            ProviderId = pProviderId;
        }
        public CategoriaPregunta()
        { }

        public CategoriaPregunta(CategoriaPreguntaDTO pCategoria)
        {
            this.ProviderId = pCategoria.ProviderId;
            this.Id = pCategoria.Id;
            this.iCategoria = pCategoria.iCategoria;
        }
    }
}
