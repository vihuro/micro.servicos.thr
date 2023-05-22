using THR.auth.DTO.Usuario;

namespace THR.AUTH.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioRetornoDto> Cadastro(UsuarioCadastroDto dto);
        Task<List<UsuarioRetornoDto>> GetAll();
        Task<UsuarioRetornoDto> GetById(Guid id);
        Task<UsuarioRetornoDto> GetByApelido(string apelido);
        Task<UsuarioRetornoDto> UpdateSenha(UsuarioUpdateSenha dto);
        Task<bool> DeleteById(Guid id);
        Task<bool> DeleteAll();
    }
}
