using BackEndVirONet8.Domain.Enums;

namespace BackEndVirONet8.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string PrimerApellido { get; set; } = default!;
        public string? SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public ICollection<PersonaDeporte> PersonaDeportes { get; set; } = new List<PersonaDeporte>();
    }

}
