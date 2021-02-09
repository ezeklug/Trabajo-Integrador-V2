using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trabajo_Integrador.Controladores.Bitacora
{

    /// <summary>
    /// Almacena logs en un archivo de texto
    /// </summary>
    class BitacoraFile : BitacoraComposite, IBitacora
    {
        private static string nombreDefault = "examenvirtual.log";

        public void GuardarLog(Log pLog)
        {
            String pDescripcion = pLog.Id.ToString() + "," + pLog.Fecha.ToString() + "," + pLog.Descripcion;

            var File = new System.IO.StreamWriter(nombreDefault, true);
            File.WriteLine(pDescripcion);
            File.Flush();
            File.Close();
        }

        public Log Obtener(int pId)
        {
            return this.ObtenerTodos().FirstOrDefault(l => l.Id == pId);
        }

        public ICollection<Log> Obtener(DateTime pDesde, DateTime pHasta)
        {
            return this.ObtenerTodos().Where(l => (l.Fecha <= pHasta) && (pDesde < l.Fecha)).ToArray();
        }

        public int ObtenerSiguienteId()
        {
            return this.ObtenerTodos().Max(l => l.Id);
        }

        public ICollection<Log> ObtenerTodos()
        {

            // Primera implementacion
            // Se podría hacer mas eficiente utilizando un buffer y leyendo de a poco
            List<Log> logs = new List<Log>();

            var f = File.ReadAllText(nombreDefault);
            var lines = f.Split('\n');
            foreach (var l in lines)
            {
                // Se podria hacer mas eficiente evitando tanto alloc dentro del for
                Log log = new Log();
                var campos = l.Split(',');
                log.Id = int.Parse(campos[0]);
                log.Fecha = DateTime.Parse(campos[1]);
                log.Descripcion = campos[2];

                logs.Add(log);
            }

            return logs;
        }


    }
}
