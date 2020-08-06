using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Trabajo_Integrador.EntityFramework;

namespace Trabajo_Integrador
{
    /// <summary>
    /// Clase bitacora que almacena todos los archivos log para hacer diagnosticos ante errores
    /// </summary>
    public class Bitacora
    {

        
        /// <summary>
        /// Obtiene un log de la base de datos
        /// </summary>
        /// <param name="pId">Id del log</param>
        /// <returns></returns>
        public Log Obtener(int pId)
        {

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    return UoW.RepositorioLogs.Get(pId);
                }
            }
            
        }


        /// <summary>
        /// Agrega un log a la base de datos
        /// </summary>
        /// <param name="pDescripcion"></param>
        public static void GuardarLog(String pDescripcion)
        {
            string nombreDefault = "examenvirtual.log";
            var File = new System.IO.StreamWriter(nombreDefault);
            File.WriteLine(pDescripcion);
        }
            

        public Bitacora()
        {
        }
    }
}
