using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;


namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Configurar_Examen : Form
    {
        String iNombreUsuario;
        ControladorFachada fachada = new ControladorFachada();


        IEnumerable<CategoriaPreguntaDTO> categorias;
        IEnumerable<String> iNombreConjuntos;
        IEnumerable<DificultadDTO> dificultades;
        String conjuntoSeleccionado;

        public Ventana_Configurar_Examen(String pNombreUsuario)
        {
            InitializeComponent();
            iNombreUsuario = pNombreUsuario; //Usado para mostrar en el Bienvenido

        }


        private void setExamen_Load(object sender, EventArgs e)
        {
            saludo.Text += iNombreUsuario; //Nombre que aparece junto con el Bienvenido 

            //cargarCategoria();
            //cargarDificultad();
            cargarConjuntos();
        }

        private void cargarCategoria()
        {
            if (conjuntoSeleccionado == null)
            {

            }
            else
            {
                categorias = ControladorFachada.GetCategoriaPreguntasConNPreguntas(conjuntoSeleccionado, 10);

                foreach (CategoriaPreguntaDTO categ in categorias)
                {
                    categoria.Items.Add(categ.Id);

                }

            }

        }



        private void cargarDificultad() //Le asigno al combobox dificultad el array dificultades
        {
            if (conjuntoSeleccionado == null)
            {

            }
            else
            {
                dificultades = ControladorFachada.GetDificultades(conjuntoSeleccionado);

                foreach (DificultadDTO dific in dificultades)
                {
                    dificultad.Items.Add(dific.Id);
                }
            }
        }


        private void cargarConjuntos()   //Le asigno al combobox conjunto el array conjunto
        {
            var nombreConjuntos = ControladorFachada.GetNombreConjuntos();
            foreach (var nombre in nombreConjuntos)
            {
                conjunto.Items.Add(nombre);
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
            else
            {
                Ventana_Principal vPrinicpal = new Ventana_Principal(iNombreUsuario);
                vPrinicpal.ShowDialog();
            }
            this.Close();
        }

        private void btnComenzarExamen_Click(object sender, EventArgs e)
        {

            if ((categoria.SelectedItem == null) || (dificultad.SelectedItem == null) || (conjunto.SelectedItem == null) || (cantidadPreguntas.Value == null))
            {
                MessageBox.Show("Debe completar todos los campos para iniciar el examen");
            }
            else
            {

                string categoriaSeleccionada = categoria.SelectedItem.ToString(); //Asigno el valor ingresado a clase Categoria
                if (categoriaSeleccionada == "Random") categoriaSeleccionada = "0";

                string dificultadSeleccionada = dificultad.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad
                if (dificultadSeleccionada == "Random") dificultadSeleccionada = "0";

                string conjuntoSeleccionado = conjunto.SelectedItem.ToString(); //Asigno el valor ingresado a clase Dificultad

                int cantidadSeleccionada = Convert.ToInt32(cantidadPreguntas.Value); //Cantidad de preguntas a responder  

                List<String> categorias = new List<string>();
                IEnumerable<CategoriaPreguntaDTO> categoriaPreguntas = ControladorFachada.GetCategoriaPreguntasConNPreguntas(conjuntoSeleccionado, cantidadSeleccionada);

                foreach (CategoriaPreguntaDTO cat in categoriaPreguntas)
                {
                    categorias.Add(cat.Id);
                }

                if (!(categorias.Contains(categoriaSeleccionada)) && (categoriaSeleccionada != "0"))
                {
                    int n = fachada.CantidadDePreguntasParaCategoria(categoriaSeleccionada);
                    MessageBoxButtons mensaje = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show($"Solo hay {n} preguntas de { categoriaSeleccionada}. Quiere hacer el examen aunque no haya la cantidad de preguntas seleccionadas?", "Advertencia", mensaje);

                    if (result == DialogResult.Yes)
                    {
                        ExamenDTO nuevoExamen = ControladorFachada.InicializarExamen(n, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);
                        nuevoExamen = ControladorFachada.InicarExamen(iNombreUsuario, nuevoExamen);

                        this.Hide();

                        using (Ventana_Preguntas Vpreguntas = new Ventana_Preguntas(nuevoExamen))
                            Vpreguntas.ShowDialog();
                        this.Close();

                    }
                }
                else
                {
                    ExamenDTO nuevoExamen = ControladorFachada.InicializarExamen(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);
                    nuevoExamen = ControladorFachada.InicarExamen(iNombreUsuario, nuevoExamen);

                    this.Hide();

                    using (Ventana_Preguntas Vpreguntas = new Ventana_Preguntas(nuevoExamen))
                        Vpreguntas.ShowDialog();
                    this.Close();

                }

            }


        }

        private void conjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            conjuntoSeleccionado = this.conjunto.SelectedItem.ToString();
            cargarCategoria();
            cargarDificultad();
        }
    }


}
