using FrontEndVirOBlazorAsamblin.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FrontEndVirOBlazorAsamblin.Models
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

        public ICollection<PersonaDeporte> PersonaDeportes { get; set; }
    }


public class PersonaCreateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [Range(1, 2, ErrorMessage = "Selecciona un sexo válido")]
        public int Sexo { get; set; } = 1;
    }

    public class PersonaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [Range(1, 2, ErrorMessage = "Selecciona un sexo válido")]
        public int Sexo { get; set; } = 1;

        public List<DeporteDto> Deportes { get; set; } = new List<DeporteDto>();
    }

}
