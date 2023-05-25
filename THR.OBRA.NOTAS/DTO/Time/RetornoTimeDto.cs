
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;

namespace THR.OBRA.NOTAS.DTO.Time
{
    public class RetornoTimeDto
    {
        public Guid TimeId { get;set; }
        public string Time { get; set; }
        public UsuarioDataHoraDto Cadastro { get; set; }
        public UsuarioDataHoraDto Alteracao { get; set; }
    }
}
