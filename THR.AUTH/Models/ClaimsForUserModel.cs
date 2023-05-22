namespace THR.AUTH.Models
{
    public class ClaimsForUserModel
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
        public Guid ClaimId { get; set; }
        public ClaimsModel Claim { get; set; }
    }
}
