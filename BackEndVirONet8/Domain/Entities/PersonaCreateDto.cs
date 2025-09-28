using BackEndVirONet8.Domain.Enums;

public class PersonaCreateDto
{
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string? SegundoApellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public Sexo Sexo { get; set; }
}       