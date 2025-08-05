using Domain.Model;

namespace Data
{
    public class TipoTorneoInMemory
    {
        public static List<TipoTorneo> TiposTorneos;

        static TipoTorneoInMemory()
        {
            TiposTorneos = new List<TipoTorneo>
            {
                new TipoTorneo(1, "Battle Royale", "100 jugadores se enfrentan, donde solo uno queda en pie."),
                new TipoTorneo(2, "5v5", "Equipos de 5 jugadores se enfrentan para poder dominar una zona del mapa."),
                new TipoTorneo(3, "Liga", "Los participantes juegan múltiples partidas y se acumulan puntos a lo largo de la temporada."),
            };
        }

    }
}
