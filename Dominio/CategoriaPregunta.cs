using System;

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

        public String ProviderId { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pCategoria"></param>
        public CategoriaPregunta(string pCategoria)
        {
            iCategoria = pCategoria;
        }
        public CategoriaPregunta()
        { }

        public CategoriaPregunta(CategoriaPreguntaDTO categoriaPreguntaDTO)
        {
            this.OpentDbId = categoriaPreguntaDTO.OpentDbId;
            this.Id = categoriaPreguntaDTO.Id;
            this.iCategoria = categoriaPreguntaDTO.iCategoria;
        }
    }
}
