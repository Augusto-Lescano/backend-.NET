namespace DTOs
{
    public class InscripcionDTO
    {
        public int Id { get; set; }
        public string ?Estado { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public int? TorneoId { get; set; }
        public string ?TorneoNombre { get; set; }

    }
}
