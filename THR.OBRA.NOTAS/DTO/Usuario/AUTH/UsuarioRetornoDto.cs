namespace THR.OBRA.NOTAS.DTO.Usuario.AUTH
{
    public class UsuarioRetornoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }
        public List<ClaimsForUserRetornoResumido>? Claims { get; set; }
    }
}
