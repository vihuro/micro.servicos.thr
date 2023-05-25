using AutoMapper;
using THR.OBRA.NOTAS.DTO.Time;
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;
using THR.OBRA.NOTAS.Models.Notas;

namespace THR.OBRA.NOTAS.Service.Mapping
{
    public class TimeMapping : Profile
    {
        public TimeMapping()
        {
            CreateMap<InsertTimeDto, TimesModel>()
 
                .ForMember(x => x.Time,map => map.MapFrom(src => src.Times))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(x => x.UsuarioCadastroId))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(x => x.UsuarioCadastroId))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(x => DateTime.UtcNow))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(x => DateTime.UtcNow));

            CreateMap<TimesModel, RetornoTimeDto>()
                .ForMember(x => x.TimeId, map => map.MapFrom(x => x.Id))
                .ForMember(x => x.Time, map => map.MapFrom(x => x.Time))
                .ForMember(x => x.Cadastro, map => map.MapFrom(c => new UsuarioDataHoraDto
                {
                    Apelido = c.UsuarioCadastro.Apelido,
                    Nome = c.UsuarioCadastro.Nome,
                    UsuarioId = c.UsuarioCadastroId,
                    DataHora = c.DataHoraCadastro
                }))
                .ForMember(x => x.Alteracao, map => map.MapFrom(c => new UsuarioDataHoraDto
                {
                    Apelido = c.UsuarioAlteracao.Apelido,
                    Nome = c.UsuarioAlteracao.Nome,
                    UsuarioId = c.UsuarioAlteracaoId,
                    DataHora = c.DataHoraAlteracao
                }));
        }
    }
}
