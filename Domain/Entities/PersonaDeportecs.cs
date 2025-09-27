namespace BackEndVirONet8.Domain.Entities
{
    public class PersonaDeporte
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }
    }

}
