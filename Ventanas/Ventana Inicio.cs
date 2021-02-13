using System;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;


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
                Boolean esAcepatado = controlBoton();
                if (esAcepatado == true)
                {
                    if (ControladorFachada.AutenticarUsuario(usuario.Text, contrasenia.Text.Trim()))
                    {

                        if (ControladorFachada.UsuarioEsAdmin(usuario.Text, contrasenia.Text.Trim()))
                        {
                            this.Hide();
                            Ventana_Principal_Admi ppal_admin = new Ventana_Principal_Admi(usuario.Text);
                            ppal_admin.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                            Ventana_Principal ppal = new Ventana_Principal(usuario.Text); //Le paso el usuario para que aparezca en la proxima ventana

                            ppal.ShowDialog();
                            this.Close();
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(usuario, "El usuario y/o contraseña son incorrectos"); //Cartel de Error }
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

        //Trim saca espacios al texto ingresado




        private Boolean controlBoton() //Metodo que controla lo que se ingresa por pantalla 
        {

            Boolean aceptado;
            Boolean usuarioValido = ControladorFachada.AutenticarUsuario(usuario.Text.Trim(), contrasenia.Text.Trim());
            if ((usuario.Text.Trim() != string.Empty) && usuarioValido) //Se verifica que el ususario y pswd sean correctos y el campo usuario no sea vacio
            {
                btnIngresar.Enabled = true; //Se habilita en boton Ingresar
                errorProvider1.SetError(usuario, ""); //No hubo error
                aceptado = true;
            }
            else //Contraseña y/o usuario incorrectos y/o campos vacios
            {
                usuario.Focus();//Hace foco en el botón Usuario 
                contrasenia.Focus();
                errorProvider1.SetError(usuario, "Usuario y/o Contraseña incorrectos");
                aceptado = false;
            }

            return aceptado;
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
