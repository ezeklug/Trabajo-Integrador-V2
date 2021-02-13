using System;

using System.Windows.Forms;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Registro : Form
    {

        ControladorFachada fachada = new ControladorFachada();

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
            try
            {
                string usuarioNombre = nuevoUsuario.Text.Trim();
                if (usuarioNombre == string.Empty)
                {
                    errorProvider2.SetError(nuevoUsuario, "Debe ingresar un usuario");
                    nuevoUsuario.Focus();
                }

                else
                {
                    if (fachada.UsuarioExiste(usuarioNombre))
                    {
                        errorProvider2.SetError(nuevoUsuario, "Usuario ya existe");
                        nuevoUsuario.Focus();

                    }

                    else
                    {
                        if ((nuevaContrasenia.Text.Trim() != null) && (nuevaContrasenia2.Text.Trim() != null) && (nuevaContrasenia.Text.Trim() != nuevaContrasenia2.Text.Trim()))
                        {
                            errorProvider1.SetError(nuevaContrasenia, "Las contraseñas ingresadas no coinciden");
                            nuevaContrasenia.Focus();
                        }
                        else
                        {
                            ControladorFachada.GuardarUsuario(usuarioNombre, nuevaContrasenia.Text.Trim());
                            MessageBox.Show("Usuario registrado correctamente");
                            this.Hide();
                            Ventana_Inicio vInicio = new Ventana_Inicio();
                            vInicio.ShowDialog();
                            this.Close();


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexion");
            }




        }

        private void Ventana_Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
