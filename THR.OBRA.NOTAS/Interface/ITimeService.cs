using THR.OBRA.NOTAS.DTO.Time;

namespace THR.OBRA.NOTAS.Interface
{
    public interface ITimeService
    {
        Task <RetornoTimeDto> Insert(InsertTimeDto dto);
        Task<RetornoTimeDto> GetByTime(string time);
        Task<List<RetornoTimeDto>> GetAll();
        Task<RetornoTimeDto> GetById(Guid id);
        Task<string> DeleteById(Guid id);
        Task<string> DeleteAll();
    }
}
