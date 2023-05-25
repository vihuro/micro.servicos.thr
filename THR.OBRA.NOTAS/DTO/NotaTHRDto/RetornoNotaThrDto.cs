using THR.OBRA.NOTAS.DTO.ParcelaDto;
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;

namespace THR.OBRA.NOTAS.DTO.NotaTHRDto
{
    public class RetornoNotaThrDto
    {
        public Guid Id { get; set; }
        public int NumeroNota { get;set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public string AvulsoFinalidade { get; set; }
        public string Autorizador { get; set; }
        public List<ProdutoServicoResumidoDto> ProdutosServicos { get; set; }
        public List<ParcelasResumidasDto> Parcelas { get; set; }
        public UsuarioDataHoraDto Cadastro { get; set; }
        public UsuarioDataHoraDto Alteracao { get; set; }
        public string Time { get; set; }
        public string TipoExportacao { get; set; }
    }
}
