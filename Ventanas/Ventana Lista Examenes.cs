using System;
using System.Data;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{

    public partial class Ventana_Lista_Examenes : Form
    {
        string iNombreUsuario;

        public Ventana_Lista_Examenes(string pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombreUsuario);
            vOpciones.ShowDialog();
            this.Close();
        }



        private void Ventana_Lista_Examenes_Load(object sender, EventArgs e)
        {
            var examenes = ControladorFachada.GetExamenes();
            DataTable dt = new DataTable();
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Puntaje", typeof(float));
            dt.Columns.Add("Tiempo", typeof(float));

            foreach (ExamenDTO examen in examenes)
            {
                dt.Rows.Add(new object[] { examen.UsuarioId, examen.Fecha, examen.Puntaje, examen.TiempoUsado });
            }

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
