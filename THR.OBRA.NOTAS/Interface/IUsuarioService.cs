using THR.auth.DTO.Usuario;

namespace THR.ObraNotas.Interface
{
    public interface IUsuarioService
    {
        Task<List<UsuarioRetornoDto>> GetAll();
    }
}
