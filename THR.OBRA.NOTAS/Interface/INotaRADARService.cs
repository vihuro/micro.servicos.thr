using THR.ObraNotas.DTO.NotaRadarDto;

namespace THR.ObraNotas.Interface
{
    public interface INotaRADARService
    {
        Task<List<NotaTXTDto>> GetAll();
        Task<List<NotaTXTDto>> GetNotSaved();
    }
}
