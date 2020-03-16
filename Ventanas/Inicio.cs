using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.Dominio;


namespace Trabajo_Integrador.Ventanas
{
    public partial class Inicio : Form
    {
        ControladorFachada iFachada = new ControladorFachada();
        public Inicio()
        {
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, EventArgs e) //Boton Salir 
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Boolean esAcepatado = controlBoton();
            if (esAcepatado == true) 
            {
                if (esAdministrador(usuario.Text) == true)
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
            else
            {
                errorProvider1.SetError(usuario, "El usuario y/o contraseña son incorrectos"); //Cartel de Error }
            }
        }

        private void Inicio_Load(object sender, EventArgs e) //Se ejeecuta el codigo cuando el formulario se carga
        {
            
        }

        //Trim saca espacios al texto ingresado


      
    
        private Boolean controlBoton() //Metodo que controla lo que se ingresa por pantalla 
        {

            Boolean aceptado;
            if ((usuario.Text.Trim() != string.Empty) && (esAceptado(usuario.Text.Trim(), contrasenia.Text.Trim()))) //Se verifica que el ususario y pswd sean correctos y el campo usuario no sea vacio
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

        private Boolean esAceptado(string nombreUsuario, string contrasenia)
        {
            return iFachada.UsuarioValido(nombreUsuario, contrasenia);
        }

        private Boolean esAdministrador(string nombreUsuario)
        {
            return iFachada.EsAdministrador( nombreUsuario);
        }

        private void crearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            using (Registro registro = new Registro()) //Le paso el usuario para que aparezca en la proxima ventana
                registro.ShowDialog();
            this.Close();
        }
    }
}
