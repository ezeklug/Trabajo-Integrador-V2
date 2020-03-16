using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Dominio;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Opciones : Form
    {
        string iNombreUsuario;
        public Ventana_Opciones(string pNombreUsusario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsusario;
        }

        private void listaUsuarios_Click(object sender, EventArgs e)
        {
            Ventana_Lista_Usuarios listaUsuarios = new Ventana_Lista_Usuarios(iNombreUsuario);
            listaUsuarios.ShowDialog();
        }

        private void verExamenes_Click(object sender, EventArgs e)
        {
            Ventana_Lista_Examenes listaExamenes = new Ventana_Lista_Examenes(iNombreUsuario);
            listaExamenes.ShowDialog();
        }

      

        private void setAdministrador_Click(object sender, EventArgs e)
        {
            Ventana_Set_Administrador setAdministrador = new Ventana_Set_Administrador();
            setAdministrador.ShowDialog();



        }

        private void verPreguntas_Click(object sender, EventArgs e)
        {
            Ventana_Todas_las_Preguntas vPreguntas = new Ventana_Todas_las_Preguntas(iNombreUsuario);
            vPreguntas.ShowDialog();
        }

        private void modificarTiempos_Click(object sender, EventArgs e)
        {
            Ventana_Modificar_Tiempo vTiempos = new Ventana_Modificar_Tiempo(iNombreUsuario);
            vTiempos.ShowDialog();
        }

       

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iNombreUsuario);
            vAdmin.ShowDialog();
            this.Close();
        }

        
        private void cargarPreguntas_Click_1(object sender, EventArgs e)
        {
            Ventana_Cargar_Pregunta vCargarExamen = new Ventana_Cargar_Pregunta(iNombreUsuario);
            vCargarExamen.ShowDialog();

        }
    }
}
