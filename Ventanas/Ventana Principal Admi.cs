using System;

using System.Windows.Forms;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Principal_Admi : Form
    {
        string iUsuario;
        public Ventana_Principal_Admi(string pUsuario)
        {
            InitializeComponent();
            iUsuario = pUsuario;
        }



        private void Ventana_Principal_Load(object sender, EventArgs e)
        {
            user.Text += iUsuario;
        }



        private void comenzarExamen_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Configurar_Examen ex = new Ventana_Configurar_Examen(iUsuario);
            ex.ShowDialog();
            this.Close();

        }

        private void Opciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            var usr = ControladorFachada.GetUsuario(iUsuario);
            if (usr.Administrador)
            {
                Ventana_Opciones vopciones = new Ventana_Opciones(iUsuario);
                vopciones.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya no eres administrador");
                this.Hide();
                var vinicio = new Ventana_Inicio();
                vinicio.ShowDialog();
                this.Close();
            }

        }

        private void verRanking_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            VentanaRanking ranking = new VentanaRanking(iUsuario);
            ranking.ShowDialog();
            this.Close();

        }

        private void cerrarSesion_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Inicio vInicio = new Ventana_Inicio();
            vInicio.ShowDialog();
            this.Close();

        }
    }
}
