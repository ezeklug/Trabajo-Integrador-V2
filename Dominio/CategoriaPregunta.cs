using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase que indica la categoria de cada pregunta
    /// </summary>
    public class CategoriaPregunta
    {
        /// <summary>
        /// properties.
        /// </summary>
        public int OpentDbId
        { get; set; }

        public string Id { get { return iCategoria; }
            set { iCategoria = value; }
        }
        public string iCategoria { get; set; }

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
    }
}
