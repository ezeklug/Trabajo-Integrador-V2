using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Trabajo_Integrador.Controladores.Bitacora
{

    /// <summary>
    /// Almacena logs en un archivo de texto
    /// </summary>
    public class BitacoraFile : BitacoraComposite
    {
        private const string nombreDefault = "examenvirtual.log";

        public override void GuardarLog(Log pLog)
        {
            String pDescripcion = pLog.Id.ToString() + "," + pLog.Fecha.ToString() + "," + pLog.Descripcion;

            var File = new System.IO.StreamWriter(nombreDefault, true);
            File.WriteLine(pDescripcion);
            File.Flush();
            File.Close();
        }

        public override Log Obtener(int pId)
        {
            return this.ObtenerTodos().FirstOrDefault(l => l.Id == pId);
        }

        public override ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta)
        {
            return this.ObtenerTodos().Where(l => (l.Fecha <= pHasta) && (pDesde < l.Fecha)).ToArray();
        }


        /// <summary>
        /// Devuelve el siguiente id a utilizar 
        /// </summary>
        /// <returns></returns>
        public override int ObtenerSiguienteId()
        {
            try
            {
                return this.ObtenerTodos().Max(l => l.Id) + 1;
            }
            catch (FileNotFoundException e)
            {
                return 0;
            }
        }


        /// <summary>
        /// Obtiene todos los logs
        /// </summary>
        /// <returns>Devuelve los logs o null</returns>
        public override ICollection<Log> ObtenerTodos()
        {

            // Primera implementacion
            // Se podría hacer mas eficiente utilizando un buffer y leyendo de a poco
            List<Log> logs = new List<Log>();
            String f;

            try
            {
                f = File.ReadAllText(nombreDefault);
            }
            catch (FileNotFoundException)
            {
                return new List<Log>();
            }


            var lines = f.Split('\n');
            foreach (var l in lines)
            {
                // Se podria hacer mas eficiente evitando tanto alloc dentro del for
                Log log = new Log();
                var campos = l.Split(',');
                if (campos.First() != "")
                {
                    log.Id = int.Parse(campos[0]);
                    log.Fecha = DateTime.Parse(campos[1]);
                    log.Descripcion = campos[2];

                    logs.Add(log);
                }
            }

            return logs;
        }


    }
}
