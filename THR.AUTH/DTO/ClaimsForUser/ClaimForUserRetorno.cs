using THR.auth.DTO.Usuario;

namespace THR.auth.DTO.ClaimsForUser
{
    public class ClaimForUserRetorno
    {
        public long ClaimForUserId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set;}
        public UsuarioResumidoDto Usuario { get; set; }
    }
}
