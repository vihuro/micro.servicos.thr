using AutoMapper;
using THR.auth.DTO.Claims;
using THR.AUTH.Models;

namespace THR.auth.Service.Mapper
{
    public class ClaimsCadastroMapping : Profile
    {
        public ClaimsCadastroMapping()
        {
            CreateMap<ClaimsCastroDto, ClaimsModel>()
                .ForMember(x => x.ClaimType, map => map.MapFrom(src => src.ClaimsType.ToUpper()))
                .ForMember(x => x.ClaimValue, map => map.MapFrom(src => src.ClaimsValue.ToUpper()));

            CreateMap<ClaimsModel, ClaimsRetornoDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.ClaimType, map => map.MapFrom(src => src.ClaimType.ToUpper()))
                .ForMember(x => x.ClaimValue, map => map.MapFrom(src => src.ClaimValue.ToUpper()))
                .ForPath(x => x.UsuarioCadastro.UsuarioId, map => map.MapFrom(src => src.UsuarioCadastro.Id))
                .ForPath(x => x.UsuarioCadastro.Nome, map => map.MapFrom(src => src.UsuarioCadastro.Nome))
                .ForPath(x => x.UsuarioCadastro.Apelido, map => map.MapFrom(src => src.UsuarioCadastro.Apelido))
                .ForPath(x => x.UsuarioCadastro.DataHora, map => map.MapFrom(src => src.DataHoraCadastro))
                .ForPath(x => x.UsuarioAlteracao.Apelido, map => map.MapFrom(src => src.UsuarioAlteracao.Apelido))
                .ForPath(x => x.UsuarioAlteracao.Nome, map => map.MapFrom(src => src.UsuarioAlteracao.Nome))
                .ForPath(x => x.UsuarioAlteracao.UsuarioId, map => map.MapFrom(src => src.UsuarioAlteracao.Id))
                .ForPath(x => x.UsuarioAlteracao.DataHora, map => map.MapFrom(src => src.DataHoraAlteracao));
        }
    }
}
