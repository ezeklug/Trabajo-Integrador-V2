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
        private int iNumeroPregunta = 0;

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

            List<Respuesta> opciones = new List<Respuesta>(); //Almacena las 4 opciones de respuestas

            List<Respuesta> respuestas = fachada.RespuestasDePregunta(unaPregunta);
          
            foreach (Respuesta respuesta in respuestas)
            {
                opciones.Add(respuesta);
            }

            List<Respuesta> listaDesordenada = new List<Respuesta>();
            Random rnd = new Random();

            while (opciones.Count > 0) //Desordena la Lista 
            {
                int i = rnd.Next(opciones.Count);
                listaDesordenada.Add(opciones[i]);
                opciones.RemoveAt(i);
            }

                        
            foreach (Respuesta opcion in listaDesordenada)
            {                
               RadioButton rb = new RadioButton();
                rb.Text += opcion.Texto;
                rb.Name = opcion.Id.ToString();
                flowLayoutPanel1.Controls.Add(rb);
            }
                    
              
        }

       /* public string RecogerOpcion() //Devuelve cual fue la opcion Seleccionada
        {
            RadioButton rbSelected = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
           /* string respuesta = string.Empty;

                if (opcionA.Checked == true) { respuesta = opcionA.Text;
                opcionA.Checked = false;  }
                if (opcionB.Checked == true) { respuesta = opcionB.Text;
                opcionB.Checked = false;  }
                if (opcionC.Checked == true) { respuesta = opcionC.Text;
                opcionC.Checked = false;  }
                if (opcionD.Checked == true) { respuesta= opcionD.Text;
                opcionD.Checked = false;  }
            Console.WriteLine(respuesta);
                                 

            return rbSelected.Text;
            
        }*/
        
         
        public Pregunta obtienePregunta(int numeroPregunta) //Muestra la pregunta iNumeroPregunta en la lista de preguntas del examen 
        {
            List<Pregunta> listaPreguntas = iExamen.getPreguntas();
            mostrarPregunta(listaPreguntas[numeroPregunta]);

            this.CantidadPreguntas.Text ="Pregunta: " + (numeroPregunta+1).ToString() + "/" + iExamen.CantidadPreguntas.ToString();

            return listaPreguntas[numeroPregunta];

        }

        public void LimpiaControles() //Limpia todos los campos (textBox y checkBox)
        {
            preg.Text = "*";
            IEnumerable<RadioButton> controles =flowLayoutPanel1.Controls.OfType<RadioButton>();
            foreach (RadioButton rb in controles)
            {
                flowLayoutPanel1.Controls.Remove(rb);
                rb.Dispose();
            }
            
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

       /* private Boolean ObtenerEstadoBotonSiguiente()
        {            
            // Chquea que alguno de los radio buttons este seleccionado, si se cumple, true
             return (RecogerOpcion()!=null);
         }
       */
        private void siguiente_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)!=null)
            {
                RadioButton opcion = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                               
               fachada.RespuestaCorrecta(iExamen, obtienePregunta(iNumeroPregunta), Int32.Parse(opcion.Name));
               // Console.WriteLine(obtienePregunta(iNumeroPregunta).Id);
               
               LimpiaControles(); // Limpia todos los controles

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
            else
            {
                MessageBox.Show("Debe seleccionar una resupuesta");
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
