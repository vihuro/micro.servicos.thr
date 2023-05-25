namespace THR.OBRA.NOTAS.DTO.NotaTHRDto
{
    public class InsertNotaDto
    {
        public int NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string? DescricaoProdutoServico { get; set; }
        public string? AvulsoFinalidade { get;set; }
        public string Autorizador { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public Guid TimeId { get; set; }
        public string TipoExportacao { get; set; }
        public List<InsertParcelaDto>? Percela { get; set; }
        public List<ProdutoServicoResumidoDto>? ProdutoServico { get; set; }
    }
}
