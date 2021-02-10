using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.DTO
{
    public class CategoriaPreguntaDTO
    {
       
            public int OpentDbId
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
                OpentDbId = categoriaPregunta.OpentDbId;
                Id = categoriaPregunta.Id;
                iCategoria = categoriaPregunta.iCategoria;
            }
    }
}

