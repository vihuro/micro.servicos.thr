using THR.OBRA.NOTAS.DTO.Usuario.OBRA;

namespace THR.OBRA.NOTAS.Interface
{
    public interface IUsuarioOBRAService
    {
        Task<List<UsuarioDto>> GetAll();
        Task<UsuarioDto> GetById(Guid id);
    }
}
