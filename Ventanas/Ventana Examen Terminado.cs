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
using Trabajo_Integrador.DTO;
using Trabajo_Integrador.Controladores;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Examen_Terminado : Form
    {
        ExamenDTO iExamen;
        ControladorFachada fachada = new ControladorFachada();
        public Ventana_Examen_Terminado(ExamenDTO unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
        }

        private void ExamenTerminado_Load(object sender, EventArgs e)
        {
            usuarioNombre.Text += iExamen.UsuarioId;

            tiempo.Text += iExamen.TiempoUsado;

            puntaje.Text += iExamen.Puntaje;

            fecha.Text += iExamen.Fecha;


        }

        private void volverInicio_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            if (fachada.EsAdministrador(iExamen.UsuarioId))
            {
                Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iExamen.UsuarioId);
                vAdmin.ShowDialog();
            }
            else
            {
                Ventana_Principal volver = new Ventana_Principal(iExamen.UsuarioId);
                volver.ShowDialog();
            }
            this.Close();
        }

        private void cerrar_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            using (Ventana_Inicio vInicio = new Ventana_Inicio()) //Paso el examen a la proxima ventana 
                vInicio.ShowDialog();
            this.Close();
        }
    }
}

