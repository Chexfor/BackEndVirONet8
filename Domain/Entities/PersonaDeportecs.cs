namespace BackEndVirONet8.Domain.Entities
{
    public class PersonaDeporte
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } = default!;
        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; } = default!;
    }

}
