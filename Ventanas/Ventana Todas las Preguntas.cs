using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Todas_las_Preguntas : Form
    {
        string iNombreUsuario;
        public Ventana_Todas_las_Preguntas(string pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario;
        }


        private void Todas_las_Preguntas_Load(object sender, EventArgs e)
        {
            IEnumerable<PreguntaDTO> preguntas = ControladorAdministrativo.GetPreguntas();
            DataTable dt = new DataTable();
            int cont = 1;

            dt.Columns.Add("Nº", typeof(int));
            dt.Columns.Add("Pregunta", typeof(string));

            foreach (PreguntaDTO pregunta in preguntas)
            {
                IEnumerable<object> row = new object[] { cont, pregunta.Id };
                cont++;
                dt.Rows.Add(row.ToArray<object>());
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombreUsuario);
            vOpciones.ShowDialog();
            this.Close();
        }
    }
}
