using THR.OBRA.CONHECIMENTO.DTO.Usuario.AUTH;

namespace THR.OBRA.CONHECIMENTO.Interface
{
    public interface IUsuarioAUTHService
    {
        Task<List<UsuarioRetornoDto>> GetAll();
        Task<UsuarioRetornoDto> GetById(Guid id);
    }
}
