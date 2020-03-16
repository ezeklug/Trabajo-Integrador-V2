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


namespace Examen_Virtual
{
    public partial class Inicio : Form
    {
        ControladorFachada fachada = new ControladorFachada();
        public Inicio()
        {
            InitializeComponent();
        }


        private void btnSalir_Click(object sender, EventArgs e) //Boton Salir 
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Boolean esAcepatado = controlBoton();
            if (esAcepatado == true)
            {
                using (setExamen ventantaSetExamen = new setExamen(usuario.Text)) //Le paso el usuario para que aparezca en la proxima ventana
                    ventantaSetExamen.ShowDialog();
            }
            else
            {
                errorProvider1.SetError(usuario, "El usuario y/o contraseña son incorrectos"); //Cartel de Error }
            }
        }

        private void Inicio_Load(object sender, EventArgs e) //Se ejeecuta el codigo cuando el formulario se carga
        {
            btnIngresar.Enabled = false;
        }

        //Trim saca espacios al texto ingresado

        private Boolean controlBoton()
        {

            Boolean aceptado;
            if ((usuario.Text.Trim() != string.Empty)  && (esAceptado(usuario.Text.Trim(), contrasenia.Text.Trim()))) //Se verifica que el ususario y pswd sean correctos y el campo usuario no sea vacio
            {
                btnIngresar.Enabled = true; //Se habilita en boton Ingresar
                errorProvider1.SetError(usuario, ""); //No hubo error
                aceptado = true;
            }
            else //Contraseña y/o usuario incorrectos y/o campos vacios
            {
                btnIngresar.Enabled = false;    //Se deshabilita boton Ingresar
                usuario.Focus();//Hace foco en el botón Usuario 
                contrasenia.Focus();
                aceptado = false;
            }

            return aceptado;
        }

        private Boolean esAceptado(string nombreUsuario, string contrasenia)
        {
            Boolean aceptado = true;
            List<Usuario> listaUsuarios = fachada.GetUsuarios();
            foreach(Usuario user in listaUsuarios)
            {
                if ((user.Id == nombreUsuario) && (user.Contrasenia == contrasenia))
                {
                    aceptado = true;
                }
                else aceptado = false;
            }
            return aceptado;
        }

        private void crearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Registro registro = new Registro()) //Le paso el usuario para que aparezca en la proxima ventana
                registro.ShowDialog();
        }
    }
}
