using Domain.Model;

namespace Data
{
    public class TorneoInMemory
    {
        public static List<Torneo> Torneos;

        static TorneoInMemory() {
            Torneos = new List<Torneo>() {
                new Torneo(1, "Copa América 2025", "Eliminación directa, partidos de ida y vuelta", 16, "2025-07-01", "2025-07-20", "2025-05-01", "2025-06-15", "Pendiente", "Sudamérica", "Inscripciones abiertas"),

                new Torneo(2, "Torneo Global de eSports", "Formato round robin seguido de playoffs", 32, "2025-09-10", "2025-10-05", "2025-07-15", "2025-08-30", "Pendiente", "Global", "Próximo"),

                new Torneo(3, "Liga Regional Norte", "Liga regular con puntos, final entre los dos primeros", 10, "2025-03-15", "2025-06-15", "2025-01-10", "2025-03-10", "Equipo A ganó la final", "Norte", "Finalizado")
            };
        }
    }
}
