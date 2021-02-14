using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class VentanaRanking : Form
    {
        string iNombreUsuario;
        ControladorFachada fachada = new ControladorFachada();

        public VentanaRanking(string pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario;
        }

        private void VentanaRanking_Load(object sender, EventArgs e)
        {
            List<ExamenDTO> listaExamenes = fachada.GetRanking(iNombreUsuario);
            DataTable dt = new DataTable();
            //dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Puntaje", typeof(float));
            dt.Columns.Add("Tiempo", typeof(float));

            foreach (ExamenDTO examen in listaExamenes)
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
