using THR.auth.DTO.Usuario;

namespace THR.auth.DTO.Claims
{
    public class ClaimsRetornoDto
    {
        public long Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set;}
        public UsuarioDataHoraDto UsuarioCadastro { get; set; }
        public UsuarioDataHoraDto UsuarioAlteracao { get; set; }

    }
}
