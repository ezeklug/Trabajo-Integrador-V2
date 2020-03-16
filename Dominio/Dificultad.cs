using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador
{
    public class Dificultad
    {

        string iDificultad;


        public string Id
        {
            get { return iDificultad; }
            set { iDificultad = value; }
        }


        public int FactorDificultad { get; set; }


        public Dificultad(string pDificultad)

        {
            Id = pDificultad;
            switch (pDificultad)
            {
                case "easy":
                    FactorDificultad = 1;
                    break;
                case "medium":
                    FactorDificultad = 3;
                    break;
                case "hard":
                    FactorDificultad = 5;
                    break;
                default:
                    FactorDificultad = 1;
                    break;
            }
        }
        public Dificultad()
        { }
    }
}
