using BackEndVirONet8.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BackEndVirONet8.Domain.Entities
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public List<DeporteDto> Deportes { get; set; } = new();
    }

    public class DeporteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}