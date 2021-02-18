using System;
using System.Data;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class VentanaRanking : Form
    {
        string iNombreUsuario;

        public VentanaRanking(string pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario;
        }

        private void VentanaRanking_Load(object sender, EventArgs e)
        {
            var examenes = ControladorFachada.GetRanking(iNombreUsuario);
            DataTable dt = new DataTable();
            //dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Puntaje", typeof(float));
            dt.Columns.Add("Tiempo", typeof(float));

            foreach (ExamenDTO examen in examenes)
            {
                dt.Rows.Add(new object[] { examen.Fecha, examen.Puntaje, examen.TiempoUsado });
            }

            dataGridView1.DataSource = dt;
        }



        private void listo_Click_1(object sender, EventArgs e)
        {
            if (ControladorFachada.GetUsuario(iNombreUsuario).Administrador)
            {
                this.Hide();
                Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iNombreUsuario);
                vAdmin.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Ventana_Principal vPrincipal = new Ventana_Principal(iNombreUsuario);
                vPrincipal.ShowDialog();
                this.Close();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
