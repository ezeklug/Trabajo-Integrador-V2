﻿using System;
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


        List<CategoriaPreguntaDTO> categorias;
        IEnumerable<String> iNombreConjuntos;
        List<DificultadDTO> dificultades;

        public Ventana_Configurar_Examen(String pNombreUsuario)
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

            categorias = fachada.GetCategoriaPreguntasConNPreguntas(10);

            List<string> listaCategorias = new List<string>(); ;
            foreach (CategoriaPreguntaDTO categoria in categorias)
            {
                listaCategorias.Add(categoria.Id);
            }

            categoria.Items.Add("Random");
            for (int i = 0; i < listaCategorias.Count; i++)
            {
                categoria.Items.Add(listaCategorias[i]);
            }
        }



        private void cargarDificultad() //Le asigno al combobox dificultad el array dificultades
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


        private void cargarConjunto()   //Le asigno al combobox conjunto el array conjunto
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

                foreach (CategoriaPreguntaDTO cat in fachada.GetCategoriaPreguntasConNPreguntas(cantidadSeleccionada))
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
                        ExamenDTO nuevoExamen = fachada.InicializarExamen(n, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);
                        fachada.InicarExamen(iNombreUsuario, nuevoExamen);

                        this.Hide();

                        using (Ventana_Preguntas Vpreguntas = new Ventana_Preguntas(nuevoExamen))
                            Vpreguntas.ShowDialog();
                        this.Close();

                    }
                }
                else
                {
                    ExamenDTO nuevoExamen = fachada.InicializarExamen(cantidadSeleccionada, conjuntoSeleccionado, categoriaSeleccionada, dificultadSeleccionada);
                    fachada.InicarExamen(iNombreUsuario, nuevoExamen);

                    this.Hide();

                    using (Ventana_Preguntas Vpreguntas = new Ventana_Preguntas(nuevoExamen))
                        Vpreguntas.ShowDialog();
                    this.Close();

                }

            }


        }

    }


}
