using System.ComponentModel.DataAnnotations.Schema;

namespace THR.OBRA.NOTAS.Models.Notas
{
    [Table("tab_produtoServico")]
    public class ProdutoServicoModel
    {
        public Guid Id { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public string Complemento { get; set; }
        public Guid NotaId { get; set; }
        public virtual NotasModel Nota { get; set; }
    }
}
