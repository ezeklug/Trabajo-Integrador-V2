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
        public static List<Log> Obtener()
        {
            List<Log> logs = new List<Log>();
            try
            {
                using (var db = new TrabajoDbContext())
                {
                    using (var UoW = new UnitOfWork(db))
                    {
                        logs= (List<Log>)UoW.RepositorioLogs.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.GuardarLog("Bitacora.Obtener " + ex.Message);
            }
            return logs;
        }


        /// <summary>
        /// Agrega un log a la base de datos
        /// </summary>
        /// <param name="pDescripcion"></param>
        public static void GuardarLog(String pDescripcion)
        {

            using (var db = new TrabajoDbContext())
            {
                using (var UoW = new UnitOfWork(db))
                {
                    Log log = new Log();
                    log.Descripcion = pDescripcion;
                    log.Fecha = DateTime.Now;
                    UoW.RepositorioLogs.Add(log);
                }
            }
            string nombreDefault = "examenvirtual.log";
            var File = new System.IO.StreamWriter(nombreDefault,true);
            File.WriteLine(pDescripcion);
            File.Flush();
            File.Close();
        }


        public Bitacora()
        {
        }
    }
}
