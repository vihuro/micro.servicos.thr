using THR.OBRA.NOTAS.DTO.NotaTHRDto;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Service.NotasTHR
{
    public class NotasTHRService : INotaTHRService
    {
        public async Task<RetornoNotaThrDto> Insert(InsertNotaDto dto)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RetornoNotaThrDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<RetornoNotaThrDto> GetNotaId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RetornoNotaThrDto>> GetNotaNumeroNota(int numeroNota)
        {
            throw new NotImplementedException();
        }


    }
}
