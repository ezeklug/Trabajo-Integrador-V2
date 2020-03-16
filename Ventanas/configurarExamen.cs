using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Integrador.Dominio;
using Trabajo_Integrador;
using Trabajo_Integrador.Controladores;


namespace Trabajo_Integrador.Ventanas
{
    public partial class configurarExamen : Form
    {
        String iNombreUsuario;
        ControladorFachada fachada = new ControladorFachada();

        
        List<CategoriaPregunta> categorias;
        List<ConjuntoPreguntas> conjuntos;
        List<Dificultad> dificultades;

        public configurarExamen(String pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario; //Usado para mostrar en el Bienvenido

        }


        private void setExamen_Load(object sender, EventArgs e)
        {
            saludo.Text += iNombreUsuario; //Nombre que aparece junto con el Bienvenido 

            cargarCategoria();
            cargarDificultad();
            cargarConjunto();
        }

        private void cargarCategoria()
        {
            categorias = fachada.GetCategorias();

            List<string> listaCategorias = new List<string>(); ;
            foreach (CategoriaPregunta categoria in categorias)
            {
                listaCategorias.Add(categoria.Id);
            }

            for (int i = 0; i < listaCategorias.Count; i++)
            {
                categoria.Items.Add(listaCategorias[i]);
            }
        }



        private void cargarDificultad() //Le asigno al combobox dificultad el array dificultades
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
    

        private void cargarConjunto()   //Le asigno al combobox conjunto el array conjunto
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
            if (fachada.EsAdministrador(iNombreUsuario))
            {
                Ventana_Principal_Admi vAdmin = new Ventana_Principal_Admi(iNombreUsuario);
                vAdmin.ShowDialog();
            }
            else { Ventana_Principal vPrinicpal = new Ventana_Principal(iNombreUsuario);
                vPrinicpal.ShowDialog();
            }
            this.Close();
        }

        private void btnComenzarExamen_Click(object sender, EventArgs e)
        {


            string categoriaSeleccionada = categoria.SelectedItem.ToString(); //Asigno el valor ingresado a clase Categoria

            string dificultadSeleccionada = dificultad.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

            string conjuntoSeleccionado = conjunto.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

            int cantidadSeleccionada = Convert.ToInt32(cantidadPreguntas.Value); //Cantidad de preguntas a responder     

            

            Examen nuevoExamen = fachada.InicializarExamen(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);
            fachada.InicarExamen(iNombreUsuario, nuevoExamen);

            this.Hide();

            using (VPreguntas Vpreguntas = new VPreguntas(nuevoExamen)) 
                Vpreguntas.ShowDialog();
            this.Close();

        }

        
    }


}
