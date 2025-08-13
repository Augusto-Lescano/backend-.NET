namespace Domain.Model
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionDeReglas { get; set; }
        public int CantidadDeJugadores { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set;  }
        public DateTime FechaInicioDeInscripciones { get; set; }
        public DateTime FechaFinDeInscripciones { get; set; }
        public string Resultado { get; set; }   
        public string Region { get; set; }
        public string Estado { get; set; }

        public Torneo(int id, string nombre, string descripcionDeReglas, int cantidadDeJugadores, DateTime fechaInicio, DateTime fechaFin, DateTime fechaInicioDeInscripciones, DateTime fechaFinDeInscripciones, string resultado, string region, string estado) {
            Id = id;
            Nombre = nombre;
            DescripcionDeReglas = descripcionDeReglas;
            CantidadDeJugadores = cantidadDeJugadores;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            FechaInicioDeInscripciones = fechaInicioDeInscripciones;
            FechaFinDeInscripciones = fechaFinDeInscripciones;
            Resultado = resultado;
            Region = region;
            Estado = estado;
        }


    }
}
