using System;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;


namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Set_Administrador : Form
    {

        string iNombreUsuario;

        public Ventana_Set_Administrador(string pNombreUsusario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsusario;
        }



        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombreUsuario);
            vOpciones.ShowDialog();
            this.Close();
        }



        private void SetAdministrador_Load(object sender, EventArgs e)
        {
            var usuarios = ControladorAdministrativo.GetUsuarios();

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
            Console.WriteLine(usr.Id);
            if (usr.Administrador)
            {
                var usuarios = ControladorAdministrativo.GetUsuarios();

                foreach (UsuarioDTO user in usuarios)
                {
                    if (listaCheckedBox.CheckedItems.Contains(user.Id))
                    {
                        ControladorAdministrativo.SetAdministrador(user.Id);

                    }
                    else
                    {
                        ControladorAdministrativo.SetNoAdministrador(user.Id);
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
