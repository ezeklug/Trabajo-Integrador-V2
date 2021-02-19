using System;

using System.Windows.Forms;


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
            this.Hide();
            Ventana_Lista_Usuarios listaUsuarios = new Ventana_Lista_Usuarios(iNombreUsuario);
            listaUsuarios.ShowDialog();
            this.Close();
        }

        private void verExamenes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Lista_Examenes listaExamenes = new Ventana_Lista_Examenes(iNombreUsuario);
            listaExamenes.ShowDialog();
            this.Close();
        }

      

        private void setAdministrador_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Set_Administrador setAdministrador = new Ventana_Set_Administrador(iNombreUsuario);
            setAdministrador.ShowDialog();
            this.Close();


        }

        private void verPreguntas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Todas_las_Preguntas vPreguntas = new Ventana_Todas_las_Preguntas(iNombreUsuario);
            vPreguntas.ShowDialog();
            this.Close();
        }

        private void modificarTiempos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Modificar_Tiempo vTiempos = new Ventana_Modificar_Tiempo(iNombreUsuario);
            vTiempos.ShowDialog();
            this.Close();
        }

       //Commit de prueba

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iNombreUsuario);
            vAdmin.ShowDialog();
            this.Close();
        }

        
        private void cargarPreguntas_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Cargar_Pregunta vCargarExamen = new Ventana_Cargar_Pregunta(iNombreUsuario);
            vCargarExamen.ShowDialog();
            this.Close();

        }

        private void monitoreoBitacora_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Logs vLogs = new Ventana_Logs(iNombreUsuario);
            vLogs.ShowDialog();
            this.Close();
        }
    }
}
