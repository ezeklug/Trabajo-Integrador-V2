using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen_Virtual;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;


namespace Examen_Virtual
{
    public partial class setExamen : Form
    {
        string nombreCliente;
        ControladorFachada fachada = new ControladorFachada();

        //string[] categorias = { "Aleatoria", "Libros", "Peliculas", "Musica", "Television", "Videojuegos", "Computacion", "Matemática", "Naturaleza" };
        //string[] dificultades = { "Aleatoria", "Facil", "Media", "Dificil" };
        List<CategoriaPregunta> cate;
        List<ConjuntoPreguntas> conj;
        List<Dificultad>dific;

        



        public setExamen(string nombre)
        {
            InitializeComponent();
            nombreCliente = nombre; //Usado para mostrar en el Bienvenido

            saludo.Text += nombreCliente; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
            cargarConjunto();

        }


        private void setExamen_Load(object sender, EventArgs e) 
        {
            saludo.Text += nombreCliente; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
            cargarConjunto();
        }

        private void cargarCategoria()
        {
            cate= fachada.GetCategorias();
            CategoriaPregunta[] categ = cate.ToArray();
            for (int i=0; i<categ.Length; i++)
            {
                categoria.Items.Add(cate[i]); //Le asigno al combobox categoria el array categorias
            }
        }

        private void cargarDificultad() //Le asigno al combobox dificultad el array dificultades
        {
            dific = fachada.GetDificultades();
            Dificultad[] dificult= dific.ToArray();

            for (int i=0; i<dificult.Length; i++)
            {
                dificultad.Items.Add(dific[i]);  
            }
        }

        private void cargarConjunto()   //Le asigno al combobox conjunto el array conjunto
        {   conj = fachada.GetConjuntoPreguntas();
            ConjuntoPreguntas[] conju = conj.ToArray();
            for (int i = 0; i < conju.Length; i++)
            {
               dificultad.Items.Add(conj[i]);
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComenzarExamen_Click(object sender, EventArgs e)
        {
            string categoriaSeleccionada = categoria.SelectedItem.ToString().ToLower(); //Asigno el valor ingresado a clase Categoria

            string dificultadSeleccionada = dificultad.SelectedItem.ToString().ToLower(); //Asigno el valor ingresado a clase Dificultad

            string conjuntoSeleccionado = conjunto.SelectedItem.ToString().ToLower(); //Asigno el valor ingresado a clase Dificultad

            int cantidadSeleccionada = Convert.ToInt32(cantidadPreguntas.Value); //Cantidad de preguntas a responder     

            
            Examen nuevoExamen = fachada.InicializarExamen(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);

            using (Preguntas preguntas = new Preguntas(nuevoExamen)) //Le paso el usuario para que aparezca en la proxima ventana
                preguntas.ShowDialog();


        }
    }


}
