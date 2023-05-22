using THR.auth.DTO.Claims;

namespace THR.AUTH.Interface
{
    public interface IClaimsService
    {
        Task<ClaimsRetornoDto> Create(ClaimsCastroDto dto);
        Task<List<ClaimsRetornoDto>> GetAll();
        Task<ClaimsRetornoDto> GetById(Guid id);
        Task<bool> DeleteById(Guid id);
        Task<bool> DeleteAll();
    }
}
