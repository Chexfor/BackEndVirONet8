using System.ComponentModel.DataAnnotations;

namespace FrontEndVirOBlazorAsamblin.Models
{
    public class Deporte
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = default!;
        public ICollection<PersonaDeporte> PersonaDeportes { get; set; } = new List<PersonaDeporte>();
    }
    public class DeporteDto
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = default!;
    }
}
  
