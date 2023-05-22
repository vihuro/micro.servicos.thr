namespace THR.ObraNotas.DTO.NotaRadarDto
{
    public class NotaTXTDto
    {
        public string NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public string Cnpj { get; set; }
        public string ValorTotalNota { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public List<DescricaoProdutoServicoDto> ProdutoServico { get; set; }
        public List<ParcelasDto> Parcelas { get; set; }
    }
}
