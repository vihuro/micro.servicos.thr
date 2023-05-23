using AutoMapper;
using THR.auth.DTO.Usuario;
using THR.OBRA.NOTAS.DTO.Usuario;
using THR.OBRA.NOTAS.Models.Usuario;

namespace THR.OBRA.NOTAS.Service.Mapping.Usuario
{
    public class UsuarioMappging : Profile
    {
        public UsuarioMappging()
        {
            CreateMap<UsuarioModel, UsuarioRetornoDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome));

            CreateMap<UsuarioRetornoDto, UsuarioModel>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome));

        }
    }
}
