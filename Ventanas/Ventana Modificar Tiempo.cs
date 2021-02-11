using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Modificar_Tiempo : Form
    {
        string iNombre;
        public Ventana_Modificar_Tiempo(string pNombre)
        {
            InitializeComponent();
            iNombre = pNombre;
        }

        List<ConjuntoPreguntasDTO> conjuntos;
        ControladorFachada fachada = new ControladorFachada();


        //private void modificar_Click(object sender, EventArgs e)
        //{

        //}

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombre);
            vOpciones.ShowDialog();
            this.Close();
        }

        private void Ventana_Modificar_Tiempo_Load(object sender, EventArgs e)
        {
            CargarConjunto();
        }

        private void CargarConjunto()
        {
            var nombresConjuntos = ControladorFachada.GetNombreConjuntos();
            foreach (var nombre in nombresConjuntos)
            {
                ListaConjuntos.Items.Add(nombre);
            }
        }

        private void modificar_Click_1(object sender, EventArgs e)
        {
            if (ListaConjuntos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un conjunto");
            }
            else
            {
                float control = 0;
                string conjuntoSeleccionado = ListaConjuntos.SelectedItem.ToString();
                if ((float.TryParse(tiempo.SelectedText, out control)) || (tiempo.SelectedText != null))
                {
                    string i = tiempo.SelectedText.ToString();
                    float tiempoIngresado = float.Parse(tiempo.Text);
                    fachada.ModificarTiempo(conjuntoSeleccionado, tiempoIngresado);
                    MessageBox.Show("Tiempo modificado con Exito");
                }
                else
                {
                    MessageBox.Show("Debe ingresar números");
                }
            }

        }


    }
}
