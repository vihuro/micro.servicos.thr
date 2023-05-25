using System.ComponentModel.DataAnnotations.Schema;

namespace THR.AUTH.Models
{
    [Table("tab_time")]
    public class TimeModel
    {
        public Guid Id { get; set; }
        public string Time { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get;set; }
        public DateTime DataHoraCadatro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
