using AutoMapper;
using THR.auth.DTO.ClaimsForUser;
using THR.auth.DTO.Usuario;
using THR.AUTH.Models;
using static BCrypt.Net.BCrypt;

namespace THR.auth.Service.Mapper
{
    public class UsuarioCadastroMapping :Profile
    {
        public UsuarioCadastroMapping() 
        {
            CreateMap<UsuarioCadastroDto,UsuarioModel >()
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Senha, map => map.MapFrom(src => HashPassword(src.Senha)))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true));

            CreateMap<UsuarioModel, UsuarioRetornoDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForPath(x => x.Claims, map => map.MapFrom(src => src.ClaimsForUser.Select(c => new ClaimsForUserRetornoResumido()
                {
                    ClaimId = c.Claim.Id,
                    ClaimName = c.Claim.ClaimType,
                    ClaimValue = c.Claim.ClaimValue

                })))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo));
            CreateMap<UsuarioRetornoDto, UsuarioModel>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo));

        }
    }
}
