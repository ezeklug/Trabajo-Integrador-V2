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
    public partial class Ventana_Todas_las_Preguntas : Form
    {
        string iNombre;
        public Ventana_Todas_las_Preguntas(string pNombre)
        {
            InitializeComponent();
            iNombre = pNombre;
        }
        ControladorFachada fachada = new ControladorFachada();
      

        private void Todas_las_Preguntas_Load(object sender, EventArgs e)
        {
            List<Pregunta> listaPreguntas = fachada.GetPreguntas();
            DataTable dt = new DataTable();
            int cont = 0;
            //dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Nº", typeof(int));
            dt.Columns.Add("Pregunta", typeof(string));
            dt.Columns.Add("Respuesta Correcta", typeof(string));
            dt.Columns.Add("Respuesta Incorrecta 1", typeof(string));
            dt.Columns.Add("Respuesta Incorrecta 2", typeof(string));
            dt.Columns.Add("Respuesta Incorrecta 3", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));

            
            foreach (Pregunta pregunta in listaPreguntas)
            {
                List<Respuesta> listaRespuestas = fachada.RespuestasDePregunta(pregunta);
                Respuesta respuestaCorrecta=null;
                List<Respuesta> respuestasIncorrectas=new List<Respuesta>();
               
                foreach (Respuesta respuesta in listaRespuestas)
                {
                    if (respuesta.EsCorrecta)
                    {
                        respuestaCorrecta = respuesta;
                    }
                    else {
                             respuestasIncorrectas.Add(respuesta);    
                    }
                 }

                cont++;
                
                    dt.Rows.Add(new object[] { cont, pregunta.Id, respuestaCorrecta, respuestasIncorrectas[0], respuestasIncorrectas[3], pregunta.Categoria.Id });
                
                
            }

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventana_Opciones vOpciones = new Ventana_Opciones(iNombre);
            vOpciones.ShowDialog();
            this.Close();
        }
    }
}
