using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase abstracta que brinda metodo abstracto para cualquier implementacion de seleccion de preguntas.
    /// </summary>
    public abstract class EstrategiaObtenerPreguntas:IEstrategiaObtenerPreguntas
    {
        //atributos
        string iConjunto;

        public EstrategiaObtenerPreguntas(string pNombre)
        {
            iConjunto=pNombre;
        }
        public string Conjunto
        {
            get { return this.iConjunto; }
            set { this.iConjunto = value; }
        }
       
        public abstract ICollection<Pregunta> getPreguntas(int pCantidad, ConjuntoPreguntas pConjunto);
    }
}
