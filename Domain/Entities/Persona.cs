using System.ComponentModel.DataAnnotations;
using BackEndVirONet8.Domain.Enums;

namespace BackEndVirONet8.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string PrimerApellido { get; set; }

        [StringLength(100)]
        public string? SegundoApellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "La fecha debe estar entre 1900 y hoy.")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        public ICollection<PersonaDeporte?> PersonaDeportes { get; set; }
    }
    
}
