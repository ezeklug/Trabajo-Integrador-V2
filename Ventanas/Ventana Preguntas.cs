using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Trabajo_Integrador.Controladores;
using Trabajo_Integrador.DTO;

namespace Trabajo_Integrador.Ventanas
{
    public partial class Ventana_Preguntas : Form
    {
        private ExamenDTO iExamen;
        private List<PreguntaDTO> iPreguntas;
        private int iNumeroPregunta;
        private int tiempo;

        private ExamenDTO examenTerminado = null;


        public Ventana_Preguntas(ExamenDTO pExamenDto)
        {
            InitializeComponent();
            iExamen = pExamenDto;
            iNumeroPregunta = 0;
            iPreguntas = ControladorExamen.GetPreguntasDeExamen(iExamen.Id).ToList();
        }


        public void mostrarPregunta(PreguntaDTO unaPregunta) //Muestra una pregunta con sus opciones
        {
            preg.Text += unaPregunta.Id; //Muestro la Pregunta en el Label

            var respuestas = ControladorPreguntas.RespuestasDePregunta(iPreguntas[iNumeroPregunta]);
            List<RespuestaDTO> opciones = new List<RespuestaDTO>(); //Almacena las 4 opciones de respuestas

            foreach (RespuestaDTO respuesta in respuestas)
            {
                opciones.Add(respuesta);
            }

            List<RespuestaDTO> listaDesordenada = new List<RespuestaDTO>();
            Random rnd = new Random();

            while (opciones.Count > 0) //Desordena la Lista
            {
                int i = rnd.Next(opciones.Count);
                listaDesordenada.Add(opciones[i]);
                opciones.RemoveAt(i);
            }


            foreach (RespuestaDTO opcion in listaDesordenada) //Muestra las preguntas en RadioButtons
            {
                RadioButton rb = new RadioButton();
                rb.Text = opcion.Texto;
                rb.Name = opcion.Id.ToString();
                flowLayoutPanel1.Controls.Add(rb);
            }
        }



        public PreguntaDTO obtienePregunta(int numeroPregunta) //Muestra la pregunta iNumeroPregunta en la lista de preguntas del examen 
        {
            mostrarPregunta(iPreguntas[numeroPregunta]);
            this.CantidadPreguntas.Text = "Pregunta: " + (numeroPregunta + 1).ToString() + "/" + iExamen.CantidadPreguntas.ToString();
            return iPreguntas[numeroPregunta];

        }



        public void LimpiaControles() //Limpia todos los campos (textBox y checkBox)
        {
            preg.Text = "*";
            flowLayoutPanel1.Controls.Clear();
        }



        private void timer_Tick(object sender, EventArgs e) //Tiempo agotado
        {
            if (tiempo > 0)
            {
                tiempo--;
                this.time.Text = "Tiempo Restante: " + tiempo.ToString();
            }
            else if(examenTerminado == null)
            {
                this.timer.Enabled = false;
                this.Hide();

                examenTerminado = ControladorExamen.FinalizarExamen(iExamen);

                using (Ventana_Examen_Terminado finalizado = new Ventana_Examen_Terminado(examenTerminado)) //Paso el examen a la proxima ventana 
                    finalizado.ShowDialog();
                this.Close();
            }
        }


        private void siguiente_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked) != null)
            {

                int respuestaId = Int32.Parse(flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name);

                this.iExamen = ControladorExamen.GuardarRespuesta(iExamen, obtienePregunta(iNumeroPregunta), respuestaId);

                LimpiaControles(); // Limpia todos los controles

                iNumeroPregunta++;

                if (iNumeroPregunta >= iExamen.CantidadPreguntas)
                {
                    this.Hide();

                    examenTerminado = ControladorExamen.FinalizarExamen(iExamen);

                    Ventana_Examen_Terminado finalizado = new Ventana_Examen_Terminado(examenTerminado);
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
