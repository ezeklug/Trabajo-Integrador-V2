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
    public partial class Ventana_Preguntas : Form
    {
        Examen iExamen;
        ControladorFachada fachada = new ControladorFachada();
        private int iNumeroPregunta = 1;

        public Ventana_Preguntas(Examen unExamen)
        {
            InitializeComponent();
            iExamen = unExamen;
            //iNumeroPreguntas = unExamen.CantidadPreguntas;

        }

        int tiempo;
          
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
            Console.WriteLine("Entre a recoger la opcion");
                string respuesta = string.Empty;

                if (opcionA.Checked == true) { respuesta = opcionA.Text;
                opcionA.Checked = false;  }
                if (opcionB.Checked == true) { respuesta = opcionB.Text;
                opcionB.Checked = false;  }
                if (opcionC.Checked == true) { respuesta = opcionC.Text;
                opcionC.Checked = false;  }
                if (opcionD.Checked == true) { respuesta= opcionD.Text;
                opcionD.Checked = false;  }
            Console.WriteLine(respuesta);

           // siguiente.Enabled = ObtenerEstadoBotonSiguiente();

          

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
           
            
            if (tiempo>0)
            {
                tiempo--;
                this.time.Text = "Tiempo Restante: "+ tiempo.ToString();
            }
            else
            {
                this.timer.Enabled = false;
                this.Hide();
                fachada.FinalizarExamen(iExamen);
                using (Ventana_Examen_Terminado finalizado = new Ventana_Examen_Terminado(iExamen)) //Paso el examen a la proxima ventana 
                    finalizado.ShowDialog();
                this.Close();
            }
            
            
            
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
            string opcion = RecogerOpcion();
            LimpiaControles();
            fachada.RespuestaCorrecta(iExamen, obtienePregunta(iNumeroPregunta), opcion);
            Console.WriteLine(obtienePregunta(iNumeroPregunta).Id);
            Console.WriteLine(opcion);
            Console.WriteLine(obtienePregunta(iNumeroPregunta).RespuestaCorrecta);

            // Limpia todos los controles

            //siguiente.Enabled = ObtenerEstadoBotonSiguiente();

            // Cambia el estado del boton siguiente
            
            LimpiaControles();

            // incrementa contador numero pregunta

            iNumeroPregunta++;

            if (iNumeroPregunta >= iExamen.CantidadPreguntas) 
            {
                this.Hide();
                fachada.FinalizarExamen(iExamen);
                Ventana_Examen_Terminado finalizado = new Ventana_Examen_Terminado(iExamen);
                finalizado.ShowDialog();
                this.Close();
                
            }
            else
            {
                obtienePregunta(iNumeroPregunta);
            }
            
           
        }
              
        private void VPreguntas_Load(object sender, EventArgs e)
        {
            tiempo = Convert.ToInt32(iExamen.TiempoLimite);
            this.timer.Enabled = true;
            this.time.Text = "Tiempo Restante: " + tiempo.ToString();
            obtienePregunta(iNumeroPregunta);
            
        }

      
    }



}
