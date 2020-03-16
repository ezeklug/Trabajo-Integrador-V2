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

namespace Trabajo_Integrador.Ventanas
{
    public partial class Registro : Form
    {
        string usuarioNombre;
        string contrasenia;
        ControladorFachada fachada = new ControladorFachada();

        public Registro()
        {
            InitializeComponent();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio vInicio = new Inicio();
            vInicio.ShowDialog();
            this.Close();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            if (nuevoUsuario.Text.Trim() != string.Empty)
            {
                usuarioNombre = nuevoUsuario.Text;
                errorProvider2.SetError(nuevoUsuario, "");
            }
            else
            {
                errorProvider2.SetError(nuevoUsuario, "Debe ingresar un usuario");
                nuevoUsuario.Focus();
            }

            if (nuevaContrasenia == nuevaContrasenia2)
            {
                contrasenia = nuevaContrasenia.Text;
                errorProvider1.SetError(nuevaContrasenia, "");
            }
            else
            {
                errorProvider1.SetError(nuevaContrasenia, "Las contraseñas ingresadas no coinciden");
                nuevaContrasenia.Focus();
            }


            fachada.GuardarUsuario(nuevoUsuario.Text.Trim(), nuevaContrasenia.Text.Trim());
            MessageBox.Show("Usuaurio registrado correctamente");
            this.Hide();
            Inicio vInicio = new Inicio();
            vInicio.ShowDialog();
            this.Close();



        }


    }
}
