using System;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;


namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Set_Administrador : Form
    {
        public Ventana_Set_Administrador()
        {
            InitializeComponent();
        }

        string iNombreUsuario;


        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombreUsuario);
            vOpciones.ShowDialog();
            this.Close();
        }



        private void SetAdministrador_Load(object sender, EventArgs e)
        {
            var usuarios = ControladorFachada.GetUsuarios();

            foreach (UsuarioDTO user in usuarios)
            {
                if (ControladorFachada.GetUsuario(user.Id).Administrador)
                {
                    int index = this.listaCheckedBox.Items.Add(user.Id);
                    listaCheckedBox.Items[index] = user.Id;
                    listaCheckedBox.SetItemChecked(index, true);
                }
                else
                {
                    int index = this.listaCheckedBox.Items.Add(user.Id);
                    listaCheckedBox.Items[index] = user.Id;
                }
            }
        }

        private void setAdmin_Click(object sender, EventArgs e)
        {
            var usr = ControladorFachada.GetUsuario(iNombreUsuario);
            if (usr.Administrador)
            {
                var usuarios = ControladorFachada.GetUsuarios();

                foreach (UsuarioDTO user in usuarios)
                {
                    if (listaCheckedBox.CheckedItems.Contains(user.Id))
                    {
                        ControladorFachada.SetAdministrador(user.Id);

                    }
                    else
                    {
                        ControladorFachada.SetNoAdministrador(user.Id);
                    }
                }
                MessageBox.Show("El/los usuario/s fueron configurados como administrador con Exito");

            }
            else
            {
                MessageBox.Show("Ya no eres administrador");
                this.Hide();
                var vinicio = new Ventana_Inicio();
                vinicio.ShowDialog();
                this.Close();
            }
        }
    }
}
