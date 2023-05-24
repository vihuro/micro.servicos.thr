using System.ComponentModel.DataAnnotations.Schema;
using THR.OBRA.NOTAS.Models.Usuario;

namespace THR.OBRA.NOTAS.Models.Notas
{
    [Table("tab_time")]
    public class TimesModel
    {
        public Guid Id { get; set; }
        public string Time { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
