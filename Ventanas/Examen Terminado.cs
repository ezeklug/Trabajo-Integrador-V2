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
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class ExamenTerminado : Form
    {
        Examen iExamen;
        ControladorFachada fachada = new ControladorFachada();
        public ExamenTerminado(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
        }

        private void ExamenTerminado_Load(object sender, EventArgs e)
        {
            usuarioNombre.Text += iExamen.Usuario.Id;

            tiempo.Text += iExamen.TiempoUsado;

            puntaje.Text += iExamen.Puntaje;

            fecha.Text += iExamen.Fecha;


        }

       

      

        private void volverInicio_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            if (fachada.EsAdministrador(iExamen.Usuario.Id))
            {
                Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iExamen.Usuario.Id);
                vAdmin.ShowDialog();
            }
            else
            {
                Ventana_Principal volver = new Ventana_Principal(iExamen.Usuario.Id);
                volver.ShowDialog();
            }
            this.Close();
        }

        private void cerrar_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            using (Inicio vInicio = new Inicio()) //Paso el examen a la proxima ventana 
                vInicio.ShowDialog();
            this.Close();
        }
    }
}

