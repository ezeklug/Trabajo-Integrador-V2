using Trabajo_Integrador.DTO;
namespace Trabajo_Integrador
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



        public int ProviderId { get; set; }

        public CategoriaPregunta(string pCategoria)
        {
            iCategoria = pCategoria;
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
