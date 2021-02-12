using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Cargar_Pregunta : Form
    {
        ControladorFachada fachada = new ControladorFachada();
        IEnumerable<CategoriaPreguntaDTO> iCategorias;
        IEnumerable<String> iNombreConjuntos;
        List<DificultadDTO> dificultades;
        string iNombreUsuario;

        public Ventana_Cargar_Pregunta(string pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario;
        }

        private void Ventana_Cargar_Examen_Load(object sender, EventArgs e)
        {
            cargarCategoria();
            cargarConjunto();
            cargarDificultad();
        }



        private void cargarCategoria()
        {

            ///
            ///
            /// Para cargar las categorias primero se debe seleccionar un conjunto
            /// Las categorias dependen del conjunto
            ///
            ///

            String nombreConjunto = "OpentDB";
            iCategorias = ControladorFachada.GetCategorias(nombreConjunto);

            List<string> listaCategorias = new List<string>(); ;
            foreach (CategoriaPreguntaDTO categoria in iCategorias)
            {
                listaCategorias.Add(categoria.Id);

            }
            for (int i = 0; i < listaCategorias.Count; i++)
            {
                categoria.Items.Add(listaCategorias[i]);
            }


        } //Le asigno al combobox categoria la lista categorias


        private void cargarDificultad() //Le asigno al combobox dificultad la lista dificultades
        {
            dificultades = fachada.GetDificultades();

            List<string> listaDificultades = new List<string>(); ;
            foreach (DificultadDTO dificultad in dificultades)
            {
                listaDificultades.Add(dificultad.Id);
            }

            for (int i = 0; i < listaDificultades.Count; i++)
            {
                dificultad.Items.Add(listaDificultades[i]);
            }
        }


        private void cargarConjunto()   //Le asigno al combobox conjunto la lista conjunto
        {
            iNombreConjuntos = ControladorFachada.GetNombreConjuntos();

            List<string> listaConjuntos = new List<string>();

            foreach (var nombre in iNombreConjuntos)
            {
                listaConjuntos.Add(nombre);
            }

            for (int i = 0; i < listaConjuntos.Count; i++)
            {
                conjunto.Items.Add(listaConjuntos[i]);
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
                MessageBox.Show("Debe completar todos los campos para iniciar el examen");
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
    }
}
