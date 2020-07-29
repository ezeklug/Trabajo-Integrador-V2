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
    public partial class Ventana_Registro : Form
    {
        string usuarioNombre;
        string contrasenia;
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
            if (nuevoUsuario.Text.Trim() == string.Empty)
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
                    if ((nuevaContrasenia != null) && (nuevaContrasenia2 != null) && (nuevaContrasenia != nuevaContrasenia2))
                    {
                        errorProvider1.SetError(nuevaContrasenia, "Las contraseñas ingresadas no coinciden");
                        nuevaContrasenia.Focus();
                    }
                    else
                    {
                        fachada.GuardarUsuario(nuevoUsuario.Text.Trim(), nuevaContrasenia.Text.Trim());
                        MessageBox.Show("Usuaurio registrado correctamente");
                        this.Hide();
                        Ventana_Inicio vInicio = new Ventana_Inicio();
                        vInicio.ShowDialog();
                        this.Close();


                    }
                }
            }

            

        }

    }
}
