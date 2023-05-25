
namespace THR.OBRA.CONHECIMENTO.DTO.Usuario.AUTH
{
    public class UsuarioRetornoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }
        public List<ClaimsResumidoDto>? Claims { get; set; }
    }
}
