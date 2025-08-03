namespace DTOs
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionDeReglas { get; set; }
        public int CantidadDeJugadores { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string FechaInicioDeInscripciones { get; set; }
        public string FechaFinDeInscripciones { get; set; }
        public string Resultado { get; set; }
        public string Region { get; set; }
        public string Estado { get; set; }
    }
}
