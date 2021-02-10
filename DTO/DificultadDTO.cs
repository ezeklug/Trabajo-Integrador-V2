using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.DTO
{
    public class DificultadDTO
    {
        string iDificultad;

        public string Id
        {
            get { return iDificultad; }
            set { iDificultad = value; }
        }


        public int FactorDificultad { get; set; }


        public DificultadDTO(string pDificultad)

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
        public DificultadDTO()
        { }

        public DificultadDTO(Dificultad dificultad)
        {
            this.Id = dificultad.Id;
            this.FactorDificultad = dificultad.FactorDificultad;
        }
    }
}
