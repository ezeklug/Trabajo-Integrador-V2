namespace Trabajo_Integrador.DTO
{
    public class PreguntaDTO
    {
        //Propiedades
        public string Id { get; set; }
        public string ConjuntoId { get; set; }
        public string ConjuntoNombre { get; set; }




        public PreguntaDTO(string pPregunta, string pConjuntoId)
        {
            Id = pPregunta;
            ConjuntoId = pConjuntoId;
        }

        public PreguntaDTO(Pregunta pregunta)
        {
            this.ConjuntoId = pregunta.Conjunto.Id;
            this.ConjuntoNombre = pregunta.Conjunto.Nombre;
            this.Id = pregunta.Id;

        }


        public PreguntaDTO() { }


    }
}
