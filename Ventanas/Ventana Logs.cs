using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Logs : Form
    {
        string iNombre;
        public Ventana_Logs(String pNombre)
        {
            InitializeComponent();
            iNombre = pNombre;
        }

        ControladorFachada fachada = new ControladorFachada();

        private void Ventana_Logs_Load(object sender, EventArgs e)
        {
            ICollection<Log> listaLogs = fachada.getLogs();
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));

            foreach (Log log in listaLogs)
            {
              dt.Rows.Add(new object[] { log.Id, log.Fecha, log.Descripcion});
            }
            dataGridView1.DataSource = dt;
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombre);
            vOpciones.ShowDialog();
            this.Close();
        }
    }
}
