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
    public partial class VPreguntas : Form
    {
        Examen iExamen;
        ControladorFachada fachada = new ControladorFachada();
        private int iNumeroPregunta = 0;



        public VPreguntas(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
            //iNumeroPreguntas = unExamen.CantidadPreguntas;

        }

        float tiempo;
        

        public void mostrarPregunta(Pregunta unaPregunta) //Muestra una pregunta con sus opciones
        {
            preg.Text += unaPregunta.Id; //Muestro la Pregunta en el Label

            List<string> opciones = new List<string>(); //Almacena las 4 opciones de respuestas

            opciones.Add(unaPregunta.RespuestaCorrecta);
            opciones.Add(unaPregunta.RespuestaIncorrecta1);
            opciones.Add(unaPregunta.RespuestaIncorrecta2);
            opciones.Add(unaPregunta.RespuestaIncorrecta3);


            List<string> listaDesordenada = new List<string>();
            Random rnd = new Random();

            while (opciones.Count > 0) //Desordena la Lista 
            {
                int i = rnd.Next(opciones.Count);
                listaDesordenada.Add(opciones[i]);
                opciones.RemoveAt(i);
            }

            opcionA.Text += listaDesordenada[0]; //Muestro la opcion A
            opcionB.Text += listaDesordenada[1]; //Muestro la opcion B
            opcionC.Text += listaDesordenada[2]; //Muestro la opcion C
            opcionD.Text += listaDesordenada[3]; //Muestro la opcion D

            

        }

        public string RecogerOpcion() //Devuelve cual fue la opcion Seleccionada
        {
         
                string respuesta = string.Empty;

                if (opcionA.Checked == true) { respuesta = "A"; }
                if (opcionB.Checked == true) { respuesta = "B"; }
                if (opcionC.Checked == true) { respuesta = "C"; }
                if (opcionD.Checked == true) { respuesta= "D"; }



            return respuesta;
        }

                       

        public Pregunta obtienePregunta(int numeroPregunta) //Muestra la pregunta iNumeroPregunta en la lista de preguntas del examen 
        {
            List<Pregunta> listaPreguntas = iExamen.getPreguntas();
            mostrarPregunta(listaPreguntas[numeroPregunta]);

            return listaPreguntas[numeroPregunta];

        }


        public void LimpiaControles() //Limpia todos los campos (textBox y checkBox)
        {
            
            preg.Text = "*";

            opcionA.Text = String.Empty;
            opcionB.Text = String.Empty;
            opcionC.Text = String.Empty;
            opcionD.Text = String.Empty;

            opcionA.Checked = false;
            opcionB.Checked = false;
            opcionC.Checked = false;
            opcionD.Checked = false;

        }


        private void timer_Tick(object sender, EventArgs e) //Tiempo agotado
        {
            tiempo--;
            this.time.Text = tiempo.ToString();
            
        }

        private Boolean ObtenerEstadoBotonSiguiente()
        {
            // default  false
            Boolean resultado = false;

            // Chquea que alguno de los radio buttons este seleccionado, si se cumple, true
           
            resultado = ((opcionA.Checked == true) || (opcionB.Checked == true) || (opcionC.Checked == true) || (opcionD.Checked == true));

            return resultado;
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            fachada.RespuestaCorrecta(iExamen, obtienePregunta(iNumeroPregunta), RecogerOpcion());
            // Limpia todos los controles
            
            // Cambia el estado del boton siguiente
            siguiente.Enabled = ObtenerEstadoBotonSiguiente();

            LimpiaControles();
            // incrementa contador numero pregunta
            iNumeroPregunta++;
            // obtiene nueva pregunta
            if ((iNumeroPregunta < iExamen.CantidadPreguntas) && (tiempo != 0)) //Termino el tiempo limite
            {
                obtienePregunta(iNumeroPregunta);
            } //Si hay más preguntas y no termminó el timepo
            else //Se acabaron las preguntas y/o se terminó el tiempo
            {
                this.timer.Enabled = false;
                using (ExamenTerminado finalizado = new ExamenTerminado(iExamen)) //Paso el examen a la proxima ventana 
                    finalizado.ShowDialog();
                this.Close();
            }
        }

        
        

        private void VPreguntas_Load(object sender, EventArgs e)
        {
            tiempo = iExamen.TiempoLimite;
            this.time.Text = tiempo.ToString();
            this.timer.Enabled = true;

            tiempo = iExamen.TiempoLimite;
            this.time.Text = tiempo.ToString();
            ///siguiente.Enabled = ObtenerEstadoBotonSiguiente();
            obtienePregunta(iNumeroPregunta);
            
        }

      
    }



}
