using AutoMapper;
using System.Collections.Generic;
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
            //CreateMap<UserLoginDto, Inquilino>()
            //    .ForMember(dest => dest.InquilinoId, opt => opt.Ignore())
            //    .ForMember(dest => dest.Dominio, opt => opt.Ignore())
            //    .ForMember(dest => dest.PlanServicio, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaInicio, opt => opt.Ignore())
            //    .ForMember(dest => dest.FechaFin, opt => opt.Ignore())
            //    .ForMember(dest => dest.Estado, opt => opt.Ignore())
            //    .ForMember(dest => dest.BaseDato, opt => opt.Ignore()).ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<List<DetalleOrdenVenta>, List<DetalleComprobantePago>>().ReverseMap();
            CreateMap<ProductoOrdenInventarioExtend, ProductoOrdenInventarioDto>().ReverseMap();
        }
    }
}
