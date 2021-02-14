using System;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Controladores.Excepciones;


namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Inicio : Form
    {
        public Ventana_Inicio()
        {
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, EventArgs e) //Boton Salir 
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.camposNoVacios())
                {
                    try
                    {
                        var usr = ControladorFachada.AutenticarUsuario(usuario.Text, contrasenia.Text.Trim());

                        this.Hide();
                        if (usr.Administrador)
                        {
                            Ventana_Principal_Admi ppal_admin = new Ventana_Principal_Admi(usuario.Text);
                            ppal_admin.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            Ventana_Principal ppal = new Ventana_Principal(usuario.Text); //Le paso el usuario para que aparezca en la proxima ventana

                            ppal.ShowDialog();
                            this.Close();
                        }
                    }
                    catch (UsrNoEncontradoException ex)
                    {
                        errorProvider1.SetError(usuario, "El usuario y/o contraseña son incorrectos"); //Cartel de Error }
                    }

                }
            }
            catch (System.Data.Entity.Core.ProviderIncompatibleException ex)
            {
                MessageBox.Show("No hay conexión");
            }
        }

        private void Inicio_Load(object sender, EventArgs e) //Se ejeecuta el codigo cuando el formulario se carga
        {

        }






        /// <summary>
        /// Controla que los campos usuario y contraseña no sean null
        /// </summary>
        /// <returns></returns>
        private Boolean camposNoVacios()
        {
            String textoUsuario = usuario.Text.Trim();
            String textoContrasenia = contrasenia.Text.Trim();


            if ((textoUsuario != string.Empty) && (textoContrasenia != string.Empty))
            {
                btnIngresar.Enabled = true; //Se habilita en boton Ingresar
                return true;
            }

            //Hace foco en el botón Usuario  
            usuario.Focus();
            errorProvider1.SetError(usuario, "Los campos no deben estar vacios");
            return false;
        }

        private void crearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            using (Ventana_Registro registro = new Ventana_Registro()) //Le paso el usuario para que aparezca en la proxima ventana
                registro.ShowDialog();
            this.Close();
        }
    }
}
