using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //metodos abstractos
        public abstract List<Pregunta> getPreguntas(string pCantidad,string pConjunto, string pDificultad, CategoriaPregunta pCategoria);
    }
}
