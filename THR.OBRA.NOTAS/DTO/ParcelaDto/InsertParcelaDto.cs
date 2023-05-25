namespace THR.OBRA.NOTAS.DTO.ParcelaDto
{
    public class InsertParcelaDto
    {
        public Guid NotaId { get; set; }
        public string NumeroParcela { get; set; }
        public DateTime Vencimento { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
