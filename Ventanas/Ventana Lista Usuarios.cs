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
    public partial class Ventana_Lista_Usuarios : Form
    {
        ControladorFachada fachada = new ControladorFachada();

        string iNombre;
        public Ventana_Lista_Usuarios(string pNombre)
        {
            InitializeComponent();
            iNombre = pNombre;
        }

      

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombre);
            vOpciones.ShowDialog();
            this.Close();
        }

        private void Ventana_Lista_Usuarios_Load(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = fachada.GetUsuarios();
            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre", typeof(string));
            


            foreach (Usuario usuario in listaUsuarios)
            {
                dt.Rows.Add(new object[] { usuario.Id});
            }

            dataGridView1.DataSource = dt;
        }

        
    }
}
