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
using Trabajo_Integrador.Dominio; 


namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Set_Administrador : Form
    {
        ControladorFachada fachada = new ControladorFachada();
        public Ventana_Set_Administrador()
        {
            InitializeComponent();
        }

        string nombreUsuario;
       

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(nombreUsuario);
            vOpciones.ShowDialog();
            this.Close();
        }

        
        private void SetAdministrador_Load(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = fachada.GetUsuarios();

            foreach (Usuario user in listaUsuarios)
            {
                if (fachada.EsAdministrador(user.Id))
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
            foreach (String nombreUsuario in listaCheckedBox.CheckedItems)
            {
                fachada.SetAdministrador(nombreUsuario);
            }
            MessageBox.Show("El/los usuario/s fueron configurados como administrador con Exito");
        }
    }
}
