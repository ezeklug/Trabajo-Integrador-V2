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
    public partial class Ventana_Set_Administrador : Form
    {
        ControladorFachada fachada = new ControladorFachada();
        public Ventana_Set_Administrador()
        {
            InitializeComponent();
        }

        string nombreUsuario;
       

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(nombreUsuario);
            vOpciones.ShowDialog();
            this.Close();
        }

        private void setAdmin_Click_1(object sender, EventArgs e)
        {
            nombreUsuario = usuario.Text;
            if (fachada.UsuarioValido(nombreUsuario))
            {
                fachada.SetAdministrador(nombreUsuario);
                MessageBox.Show("El usuario "+ nombreUsuario + "fue configurado como administrador con Exito");
                errorProvider1.SetError(usuario, "");
            }
            else errorProvider1.SetError(usuario, "El nombre de usuario ingresado no existe");
        }

        private void SetAdministrador_Load(object sender, EventArgs e)
        {

        }
    }
}
