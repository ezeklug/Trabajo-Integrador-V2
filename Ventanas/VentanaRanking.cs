using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Controladores;

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
            List<Examen> listaExamenes = fachada.GetRanking(iNombreUsuario);
            DataTable dt = new DataTable();
            //dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Puntaje", typeof(int));
            dt.Columns.Add("Tiempo", typeof(float));

           foreach (Examen examen in listaExamenes)
            {
               dt.Rows.Add(new object[] {  examen.Fecha, examen.Puntaje, examen.TiempoUsado });
            }

            dataGridView1.DataSource = dt;
        }

        

        private void listo_Click_1(object sender, EventArgs e)
        {
            if(fachada.EsAdministrador(iNombreUsuario))
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

     
    }
}
