using AutoMapper;
using THR.OBRA.NOTAS.DTO.NotaTHRDto;
using THR.OBRA.NOTAS.DTO.Usuario;
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
                .ForMember(x => x.Parcelas, map => map.MapFrom(src => src.Percela.Select(c => new ParcelasModel
                {
                    Vencimento = c.Vencimento,
                    NumeroParcela = c.Parcela,
                    Status = "AGURDANDO PAGAMENTO"
                })))
                .ForMember(x => x.ProdutosServico, map => map.MapFrom(src => src.ProdutoServico.Select(c => new ProdutoServicoModel
                {
                    Complemento = c.Complemento,
                    DescricaoProdutoServico = c.DescricaoProdutoServico
                })));

            CreateMap<NotasModel, RetornoNotaThrDto>()
                .ForMember(x => x.AvulsoFinalidade, map => map.MapFrom(src => src.AvulsoFinalidade))
                .ForMember(x => x.TipoExportacao, map => map.MapFrom(src => src.TipoExportacao))
                .ForMember(x => x.Autorizador, map => map.MapFrom(src => src.Autorizador))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj))
                .ForMember(x => x.Fornecedor, map => map.MapFrom(src => src.Fornecedor))
                .ForMember(x => x.DescricaoProdutoServico, map => map.MapFrom(src => src.DescricaoProdutoServico))
                .ForMember(x => x.NumeroNota, map => map.MapFrom(src => src.NumeroNota))
                .ForMember(x => x.Cadastro, map => map.MapFrom(src => new UsuarioDataHora
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome =  src.UsuarioCadastro.Nome,
                    IdUsuario = src.UsuarioCadastro.Id,
                    DataHora = src.DataHoraCadastro
                }))
                .ForMember(x => x.Cadastro, map => map.MapFrom(src => new UsuarioDataHora
                {
                     Apelido = src.UsuarioAlteracao.Apelido,
                     Nome = src.UsuarioAlteracao.Nome,
                     IdUsuario = src.UsuarioAlteracao.Id,
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
