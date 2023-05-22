using THR.auth.DTO.ClaimsForUser;

namespace THR.auth.DTO.Usuario
{
    public class UsuarioRetornoDto
    {
        private List<ClaimsForUserRetornoResumido> claims;

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }
        public List<ClaimsForUserRetornoResumido>? Claims { get => claims; set => claims = value; }
    }
}
