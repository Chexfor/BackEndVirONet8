using AutoMapper;
using BackEndVirONet8.Domain.Entities;

namespace BackEndVirONet8.Mappings
{
    public class DeporteProfile : Profile
    {
        public DeporteProfile()
        {
            CreateMap<Deporte, DeporteDto>();
            CreateMap<DeporteDto, Deporte>();
        }
    }

}
