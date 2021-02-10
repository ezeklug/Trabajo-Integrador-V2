namespace Trabajo_Integrador.DTO
{
    public class PreguntaDTO
    {
        //Propiedades
        public string Id { get; set; }
        public int ConjuntoId { get; set; }




        public PreguntaDTO(string pPregunta, int pConjuntoId)
        {
            Id = pPregunta;
            ConjuntoId = pConjuntoId;
        }

        public PreguntaDTO(Pregunta pregunta)
        {
            this.ConjuntoId = pregunta.Conjunto.Id;
            this.Id = pregunta.Id;

        }


        public PreguntaDTO() { }


    }
}
