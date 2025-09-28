using AutoMapper;
using BackEndVirONet8.Domain.Entities;

namespace BackEndVirONet8.Mappings
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaDto>()
                .ForMember(dest => dest.Deportes, opt => opt.MapFrom(src =>
                    src.PersonaDeportes.Select(pd => new DeporteDto
                    {
                        Id = pd.Deporte.Id,
                        Nombre = pd.Deporte.Nombre
                    }).ToList()));

            CreateMap<PersonaDto, Persona>(); // opcional
        }
    }

}
