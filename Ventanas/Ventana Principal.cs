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
    public partial class Ventana_Principal : Form
    {
        String iNombreUsuario;

        public Ventana_Principal(String pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario=pNombreUsuario;
            
        }

       


        private void comenzarExamen_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Configurar_Examen examen = new Ventana_Configurar_Examen(iNombreUsuario);
            examen.ShowDialog();
            this.Close();
                

        }

        private void Ventana_Principal_Load(object sender, EventArgs e)
        {
            user.Text += iNombreUsuario;

        }

        

        private void cerrarSesion_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Inicio vInicio = new Ventana_Inicio();
            vInicio.ShowDialog();
            this.Close();
            
        }

        private void verRanking_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaRanking ranking = new VentanaRanking(iNombreUsuario);
            ranking.ShowDialog();
            this.Close();
        }
    }
}
