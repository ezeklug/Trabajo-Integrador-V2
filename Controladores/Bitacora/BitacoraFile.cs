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
            var logs = this.ObtenerTodos();
            if (logs.Any())
            {
                return logs.FirstOrDefault(l => l.Id == pId);
            }
            return null;
        }

        public override ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta)
        {
            var logs = this.ObtenerTodos();
            if (logs.Any())
            {
                return logs.Where(l => (l.Fecha <= pHasta) && (pDesde < l.Fecha)).ToArray();
            }
            return new List<Log>();
        }


        /// <summary>
        /// Devuelve el siguiente id a utilizar 
        /// </summary>
        /// <returns></returns>
        public override int ObtenerSiguienteId()
        {

            var logs = this.ObtenerTodos();
            if (logs.Any())
            {
                return logs.Max(l => l.Id) + 1;
            }
            return 1;
        }

        /// <summary>
        /// Obtiene todos los logs
        /// </summary>
        /// <returns>Devuelve los logs o Icollection vacio</returns>
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
