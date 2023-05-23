using THR.OBRA.NOTAS.DTO.NotaTHRDto;

namespace THR.ObraNotas.Interface
{
    public interface INotaTHRService
    {
        Task <RetornoNotaThrDto> Insert(InsertNotaDto dto);
        Task<List<RetornoNotaThrDto>> GetNotaNumeroNota(int numeroNota);
        Task<RetornoNotaThrDto> GetNotaId(Guid id);
        Task<List<RetornoNotaThrDto>> GetAll();
        Task<string> DeleteAll();
    }
}
