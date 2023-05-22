using System.ComponentModel.DataAnnotations.Schema;
using THR.OBRA.NOTAS.Models.Usuario;

namespace THR.OBRA.NOTAS.Models.Notas
{
    [Table("tab_nota")]
    public class NotasModel
    {
        public Guid Id { get; set; }
        public int NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string? DescricaoProdutoServico { get; set; }
        public string? AvulsoFinalidade { get; set; }
        public string Autorizador { get; set; }
        public string TipoExportacao { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public Guid TimeId { get; set; }
        public virtual TimesModel Time { get; set; }
        public virtual List<ParcelasModel> Parcelas { get; set; }
        public virtual List<ProdutoServicoModel> ProdutosServico { get; set; }
    }
}
