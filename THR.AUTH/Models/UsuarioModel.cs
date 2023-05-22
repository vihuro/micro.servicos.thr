using System.ComponentModel.DataAnnotations.Schema;

namespace THR.AUTH.Models
{
    [Table("tab_usuario")]
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public virtual List<ClaimsForUserModel> ClaimsForUser { get; set; }
    }
}
