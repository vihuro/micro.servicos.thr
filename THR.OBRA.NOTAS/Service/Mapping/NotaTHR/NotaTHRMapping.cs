using AutoMapper;
using THR.OBRA.NOTAS.DTO.NotaTHRDto;
using THR.OBRA.NOTAS.DTO.ParcelaDto;
using THR.OBRA.NOTAS.DTO.Usuario;
using THR.OBRA.NOTAS.DTO.Usuario.AUTH;
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;
using THR.OBRA.NOTAS.Models.Notas;

namespace THR.OBRA.NOTAS.Service.Mapping.NotaTHR
{
    public class NotaTHRMapping : Profile
    {
        public NotaTHRMapping()
        {
            CreateMap<InsertNotaDto, NotasModel>()
                .ForMember(x => x.AvulsoFinalidade, map => map.MapFrom(src => src.AvulsoFinalidade))
                .ForMember(x => x.TipoExportacao, map => map.MapFrom(src => src.TipoExportacao))
                .ForMember(x => x.Autorizador, map => map.MapFrom(src => src.Autorizador))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj))
                .ForMember(x => x.Fornecedor, map => map.MapFrom(src => src.Fornecedor))
                .ForMember(x => x.DescricaoProdutoServico, map => map.MapFrom(src => src.DescricaoProdutoServico))
                .ForMember(x => x.NumeroNota, map => map.MapFrom(src => src.NumeroNota))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UsuarioCadastroId))
                .ForMember(x => x.Parcelas, map => map.MapFrom(src => src.Percela.Select(c => new ParcelasModel
                {
                    NumeroParcela = c.Parcela,
                    Vencimento = c.Vencimento,
                    UsuarioCadastroId = src.UsuarioCadastroId,
                    UsuarioAlteracaoId = src.UsuarioCadastroId,
                    DataHoraAlteracao = DateTime.UtcNow,
                    DataHoraCadastro = DateTime.UtcNow,
                    Status = "AGUARDANDO PAGAMENTO",
                    
                }))) 
                .ForMember(x => x.ProdutosServico, map => map.MapFrom(src => src.ProdutoServico.Select(c => new ProdutoServicoModel
                {
                    Complemento = c.Complemento,
                    DescricaoProdutoServico = c.DescricaoProdutoServico
                })))
                ;

            CreateMap<NotasModel, RetornoNotaThrDto>()
                .ForMember(x => x.AvulsoFinalidade, map => map.MapFrom(src => src.AvulsoFinalidade))
                .ForMember(x => x.TipoExportacao, map => map.MapFrom(src => src.TipoExportacao))
                .ForMember(x => x.Autorizador, map => map.MapFrom(src => src.Autorizador))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj))
                .ForMember(x => x.Fornecedor, map => map.MapFrom(src => src.Fornecedor))
                .ForMember(x => x.DescricaoProdutoServico, map => map.MapFrom(src => src.DescricaoProdutoServico))
                .ForMember(x => x.NumeroNota, map => map.MapFrom(src => src.NumeroNota))
                .ForMember(x => x.Time, map => map.MapFrom(src => src.Time.Time))
                .ForMember(x => x.Cadastro, map => map.MapFrom(src => new UsuarioDataHoraDto
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome =  src.UsuarioCadastro.Nome,
                    UsuarioId = src.UsuarioCadastro.Id,
                    DataHora = src.DataHoraCadastro
                }))
                .ForMember(x => x.Alteracao, map => map.MapFrom(src => new UsuarioDataHoraDto
                {
                     Apelido = src.UsuarioAlteracao.Apelido,
                     Nome = src.UsuarioAlteracao.Nome,
                     UsuarioId = src.UsuarioAlteracao.Id,
                     DataHora = src.DataHoraAlteracao
                }))

                .ForMember(x => x.Parcelas, map => map.MapFrom(src => src.Parcelas.Select(c => new ParcelasResumidasDto
                {
                    Parcela = c.NumeroParcela,
                    Vencimento = c.Vencimento,
                    StatusParcela = c.Status
                })))
                .ForMember(x => x.ProdutosServicos, map => map.MapFrom(src => src.ProdutosServico.Select(c => new ProdutoServicoResumidoDto
                {
                    Complemento = c.Complemento,
                    DescricaoProdutoServico = c.DescricaoProdutoServico
                })));
        }
    }
}
