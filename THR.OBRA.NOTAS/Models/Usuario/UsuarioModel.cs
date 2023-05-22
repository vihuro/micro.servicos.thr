using System.ComponentModel.DataAnnotations.Schema;

namespace THR.OBRA.NOTAS.Models.Usuario
{
    [Table("tab_usuario")]

    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
    }
}
