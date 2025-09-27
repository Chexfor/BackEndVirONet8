namespace BackEndVirONet8.Domain.Entities
{
    public class Deporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public ICollection<PersonaDeporte> PersonaDeportes { get; set; } = new List<PersonaDeporte>();
    }

}
