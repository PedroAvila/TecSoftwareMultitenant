using AutoMapper;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Servidor, ServidorDto>().ReverseMap();
            CreateMap<BaseDato, BaseDatoDto>().ReverseMap();
            CreateMap<Inquilino, InquilinoDto>().ReverseMap();
        }
    }
}
