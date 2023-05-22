using THR.auth.DTO.Usuario;

namespace THR.auth.DTO.ClaimsForUser
{
    public class ClaimsTypeForUser
    {
        public Guid Id { get; set; }
        public string ClaimValue { get; set; }
        public string ClaimType { get; set; }
        public List<UsuarioResumidoDto> Usuarios { get; set; }
    }
}
