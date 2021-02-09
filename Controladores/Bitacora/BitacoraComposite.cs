using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Integrador.Controladores.Bitacora
{
    public abstract class BitacoraComposite
    {
        public virtual bool IsComposite() {
            return true;
        }     

    }
}
