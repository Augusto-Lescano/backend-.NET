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

        //Solo se envían cuando se crea el torneo
        public DateTime FechaInicioDeInscripciones { get; set; }
        public DateTime FechaFinDeInscripciones { get; set; }

        //Solo se usa en actualización
        public string? Resultado { get; set; }

        public string Region { get; set; }

        //Estado se calcula automáticamente (no se envía)
        public string Estado { get; set; }

        public int TipoDeTorneoId { get; set; }
        public int JuegoId { get; set; }
        public int InscripcionId { get; set; }
        public int OrganizadorId { get; set; }
        public string ?OrganizadorNombre { get; set; }
        public string? JuegoNombre { get; set; }
        public string ?TipoTorneoNombre { get; set; }
    }

    public class FechasInscripcionDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
