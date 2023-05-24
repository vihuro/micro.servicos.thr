using AutoMapper;
using THR.OBRA.NOTAS.DTO.Usuario;
using THR.OBRA.NOTAS.DTO.Usuario.AUTH;
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;
using THR.OBRA.NOTAS.Models.Usuario;

namespace THR.OBRA.NOTAS.Service.Mapping.Usuario
{
    public class UsuarioMappging : Profile
    {
        public UsuarioMappging()
        {
            CreateMap<UsuarioRetornoDto,UsuarioDto >()
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido));

            CreateMap<UsuarioModel, UsuarioDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido));

            CreateMap<UsuarioDto, UsuarioModel>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido));

        }
    }
}
