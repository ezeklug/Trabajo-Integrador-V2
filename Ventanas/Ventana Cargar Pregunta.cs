using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Cargar_Pregunta : Form
    {
        IEnumerable<CategoriaPreguntaDTO> iCategorias;
        IEnumerable<String> iNombreConjuntos;
        IEnumerable<DificultadDTO> dificultades;
        string iNombreUsuario;

        public Ventana_Cargar_Pregunta(string pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario;
        }

        private void Ventana_Cargar_Examen_Load(object sender, EventArgs e)
        {
            this.cargarConjunto();
        }


        private void cargarConjunto()   //Le asigno al combobox conjunto la lista conjunto
        {
            iNombreConjuntos = ControladorFachada.GetNombreConjuntos();

            foreach (var nombre in iNombreConjuntos)
            {
                conjunto.Items.Add(nombre);
            }

        }


        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombreUsuario);
            vOpciones.ShowDialog();
            this.Close();

        }

        private void cargarPreguntas_Click(object sender, EventArgs e)
        {


            if ((categoria.SelectedItem == null) || (dificultad.SelectedItem == null) || (conjunto.SelectedItem == null) || (cantidad.Value == null))
            {
                MessageBox.Show("Debe completar todos ");
            }
            else
            {
                string categoriaSeleccionada = categoria.SelectedItem.ToString(); //Asigno el valor ingresado a clase Categoria

                string dificultadSeleccionada = dificultad.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

                string conjuntoSeleccionado = conjunto.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

                string cantidadSeleccionada = cantidad.Value.ToString();

                int cargadas = ControladorFachada.GetPreguntasOnline(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);

                MessageBox.Show($"Se cargaron exitosamente {cargadas} preguntas");
            }
        }

        private void conjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreConjuto = this.conjunto.SelectedItem.ToString();
            var categorias = ControladorFachada.GetCategoriaPreguntasConNPreguntas(nombreConjuto, 0);
            var dificultades = ControladorFachada.GetDificultades(nombreConjuto);

            foreach (var c in categorias)
            {
                categoria.Items.Add(c.Id);
            }

            foreach (var d in dificultades)
            {
                dificultad.Items.Add(d.Id);
            }
        }
    }
}
