using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.DTO.Claims;
using THR.auth.Service.ExceptionService;
using THR.AUTH.DBContext;
using THR.AUTH.Interface;
using THR.AUTH.Models;

namespace THR.AUTH.Service.Claims
{
    public class ClaimsService : IClaimsService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public ClaimsService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClaimsRetornoDto> Create(ClaimsCastroDto dto)
        {
            if (string.IsNullOrEmpty(dto.UsuarioId.ToString()) ||
                string.IsNullOrEmpty(dto.ClaimsValue) ||
                string.IsNullOrEmpty(dto.ClaimsType))
            {
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = _mapper.Map<ClaimsCastroDto, ClaimsModel>(dto);
            obj.UsuarioCadastroId = dto.UsuarioId;
            obj.UsuarioAlteracaoId = dto.UsuarioId;
            obj.DataHoraCadastro = DateTime.UtcNow;
            obj.DataHoraAlteracao = DateTime.UtcNow;
            _context.Claims.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }

        public async Task<bool> DeleteAll()
        {
            var obj = await _context.Claims.ToListAsync();
            _context.RemoveRange(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var obj = _mapper.Map<ClaimsRetornoDto, ClaimsModel>(await GetById(id));

            _context.Claims.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClaimsRetornoDto>> GetAll()
        {
            var obj = await _context.Claims
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .ToListAsync();

            return _mapper.Map<List<ClaimsModel>, List<ClaimsRetornoDto>>(obj);
        }

        public async Task<ClaimsRetornoDto> GetById(Guid id)
        {
            var obj = await _context.Claims
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefaultAsync(x => x.Id == id) ??
                throw new CustomException("Usuário não encontrado!") { HResult = 404 };

            return _mapper.Map<ClaimsModel, ClaimsRetornoDto>(obj);
        }
    }
}
