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

namespace Examen_Virtual
{
    public partial class Preguntas : Form
    {
        Examen iExamen;
        ControladorFachada fachada = new ControladorFachada();


        public Preguntas(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;

        }

        float tiempo;

        public string mostrarPregunta(Pregunta unaPregunta) //Muestra una pregunta con sus opciones
        {
            preg.Text += unaPregunta.Id; //Muestro la Pregunta en el Label

            List<string> opciones = new List<string>(); //Almacena las 4 opciones de respuestas

            opciones.Add(unaPregunta.RespuestaCorrecta);
            opciones.Add(unaPregunta.RespuestaIncorrecta1); ;
            opciones.Add(unaPregunta.RespuestaIncorrecta2);
            opciones.Add(unaPregunta.RespuestaIncorrecta3);


            List<string> listaDesordenada = new List<string>();
            Random rnd = new Random();

            while (opciones.Count != 0) //Desordena la Lista 
            {
                int i = rnd.Next(opciones.Count);
                listaDesordenada.Add(opciones[i]);
                opciones.RemoveAt(i);
            }

            opcionA.Text += listaDesordenada[0]; //Muestro la opcion A
            opcionB.Text += listaDesordenada[1]; //Muestro la opcion B
            opcionC.Text += listaDesordenada[2]; //Muestro la opcion C
            opcionD.Text += listaDesordenada[3]; //Muestro la opcion D

            return RecogerOpcion();

            }

        public string RecogerOpcion() //Devuelve cual fue la opcion Seleccionada
        {
            string opcionSeleccionada = "";

            if (opcionA.Checked)
            {
                opcionSeleccionada = opcionA.Text;
            }

            if (opcionB.Checked)
            {
                opcionSeleccionada = opcionB.Text;
            }

            if (opcionC.Checked)
            {
                opcionSeleccionada = opcionC.Text;
            }

            if (opcionD.Checked)
            {
                opcionSeleccionada = opcionD.Text;
            }

            return opcionSeleccionada;
        }

        public void responderPreguntas() //mUESTRA LAS PREGUNTAS DEL EXAMEN
        {
            foreach (Pregunta pregunt in iExamen.getPreguntas())//Por cada pregunta que tiene el examen 
            {
                string opcion= mostrarPregunta(pregunt);
                fachada.RespuestaCorrecta(iExamen, pregunt, opcion);
                siguiente_Click(null, null);                              
            }
            fachada.FinalizarExamen(iExamen);

        }

        
        private void siguiente_Click(object sender, EventArgs e) //Boton Siguiente
        {
            LimpiaControles();
        }
      
        public void LimpiaControles() //Limpia todos los campos (textBox y checkBox)
        {
                preg.Text = String.Empty;
                
                opcionA.Text = String.Empty;
                opcionB.Text = String.Empty;
                opcionC.Text = String.Empty;
                opcionD.Text = String.Empty;

                opcionA.Checked = false;
                opcionB.Checked = false;
                opcionC.Checked = false;
                opcionD.Checked = false;
        }
        
        private void Preguntas_Load(object sender, EventArgs e) //Se carga junto con la pantalla de Preguntas
        {
            responderPreguntas();
            tiempo = iExamen.TiempoLimite;
            this.time.Text = tiempo.ToString();

            this.timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e) //Tiempo agotado
        {
            tiempo--;
            this.time.Text = tiempo.ToString();
            if (tiempo == 0) //Termino el tiempo limite
            {
                this.timer.Enabled = false;
                fachada.FinalizarExamen(iExamen);
                using (ExamenTerminado finalizado = new ExamenTerminado(iExamen)) //Paso el examen a la proxima ventana 
                    finalizado.ShowDialog();
            }


        }

        
    }

       
    
}
