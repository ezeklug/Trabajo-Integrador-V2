using System;

using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Bitacora;
using Trabajo_Integrador.Controladores.Excepciones;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Registro : Form
    {


        public Ventana_Registro()
        {
            InitializeComponent();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Inicio vInicio = new Ventana_Inicio();
            vInicio.ShowDialog();
            this.Close();
        }



        private void Registrar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = nuevoUsuario.Text.Trim();
            string contrasenia1 = nuevaContrasenia.Text.Trim();
            string contrasenia2 = nuevaContrasenia2.Text.Trim();

            if (nombreUsuario == string.Empty)
            {
                errorProvider2.SetError(nuevoUsuario, "Debe ingresar un usuario");
                nuevoUsuario.Focus();
            }
            else if ((contrasenia1 == string.Empty) || (contrasenia1 != contrasenia2))
            {
                errorProvider1.SetError(nuevaContrasenia, "Las contraseñas ingresadas no coinciden");
                nuevaContrasenia.Focus();
            }
            else
            {
                try
                {
                    var usr = ControladorAdministrativo.GetUsuario(nombreUsuario);
                    errorProvider2.SetError(nuevoUsuario, "Usuario ya existe");
                    var bitacora = new Bitacora();
                    bitacora.GuardarLog("RegistrarUsuario ya existe" );
                    nuevoUsuario.Focus();
                }
                catch (UsrNoEncontradoException ex)
                {
                    ControladorAdministrativo.GuardarUsuario(nombreUsuario, contrasenia1);
                    MessageBox.Show("Usuario registrado correctamente");
                    this.Hide();
                    Ventana_Inicio vInicio = new Ventana_Inicio();
                    vInicio.ShowDialog();
                    this.Close();
                }
            }
        }

        private void Ventana_Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
