namespace Trabajo_Integrador.DTO
{
    public class CategoriaPreguntaDTO
    {

        public string ProviderId
        { get; set; }

        public string Id
        {
            get { return iCategoria; }
            set { iCategoria = value; }
        }
        public string iCategoria { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pCategoria"></param>
        public CategoriaPreguntaDTO(string pCategoria)
        {
            iCategoria = pCategoria;
        }
        public CategoriaPreguntaDTO()
        { }

        public CategoriaPreguntaDTO(CategoriaPregunta categoriaPregunta)
        {
            this.ProviderId = categoriaPregunta.ProviderId;
            Id = categoriaPregunta.Id;
            iCategoria = categoriaPregunta.iCategoria;
        }
    }
}
