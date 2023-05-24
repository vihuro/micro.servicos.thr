using THR.OBRA.NOTAS.DTO.Usuario.AUTH;

namespace THR.ObraNotas.Interface
{
    public interface IUsuarioAUTHService
    {
        Task<List<UsuarioRetornoDto>> GetAll();
        Task<UsuarioRetornoDto> GetById(Guid id);
    }
}
