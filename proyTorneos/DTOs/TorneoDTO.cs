namespace DTOs
{
    public class TorneoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionDeReglas { get; set; }
        public int CantidadDeJugadores { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaInicioDeInscripciones { get; set; }
        public DateTime FechaFinDeInscripciones { get; set; }
        public string Resultado { get; set; }
        public string Region { get; set; }
        public string Estado { get; set; }


    }
}
