using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Dominio
{
    public class Respuesta
    {

        public int Id { get; set; }
        public string Texto { get; set; }
        public Boolean EsCorrecta { get; set; }


        public Respuesta(string pTexto, Boolean pCorrecta)
        {
            this.Texto = pTexto;
            this.EsCorrecta = pCorrecta;
        }
        public Respuesta() { }

    }
}
