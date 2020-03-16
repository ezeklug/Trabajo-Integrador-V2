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
    public partial class Ventana_Cargar_Pregunta : Form
    {
         ControladorFachada fachada = new ControladorFachada();
        List<CategoriaPregunta> categorias;
        List<ConjuntoPreguntas >conjuntos;
        List< Dificultad >dificultades;
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
            categorias = fachada.GetCategorias();

            List<string> listaCategorias = new List<string>(); ;
            foreach (CategoriaPregunta categoria in categorias)
            {
                listaCategorias.Add(categoria.Id);

            }
            for(int i=0; i<listaCategorias.Count; i++)
            {
                categoria.Items.Add(listaCategorias[i]);
            }

           
        } //Le asigno al combobox categoria la lista categorias


        private void cargarDificultad() //Le asigno al combobox dificultad la lista dificultades
        {
            dificultades = fachada.GetDificultades();

            List<string> listaDificultades = new List<string>(); ;
            foreach (Dificultad dificultad in dificultades)
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
            conjuntos = fachada.GetConjuntoPreguntas();

            List<string> listaConjuntos = new List<string>();

            foreach (ConjuntoPreguntas conjunto in conjuntos)
            {
                listaConjuntos.Add(conjunto.Id);
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
            string categoriaSeleccionada = categoria.SelectedItem.ToString(); //Asigno el valor ingresado a clase Categoria

               string dificultadSeleccionada = dificultad.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

                string conjuntoSeleccionado = conjunto.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

                string cantidadSeleccionada = cantidad.Value.ToString();



                fachada.GetPreguntasOnline(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);

                MessageBox.Show("Las preguntas se cargaron correctamente");
        }
    }
}
