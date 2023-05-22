using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.DTO.Usuario;
using THR.auth.Service.ExceptionService;
using THR.AUTH.DBContext;
using THR.AUTH.Interface;
using THR.AUTH.Models;

namespace THR.AUTH.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UsuarioService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioRetornoDto> Cadastro(UsuarioCadastroDto dto)
        {
            if (string.IsNullOrEmpty(dto.Apelido) ||
                string.IsNullOrEmpty(dto.Nome) ||
                string.IsNullOrEmpty(dto.Senha)) throw new CustomException("Campos obrigatório(s) vazio(s)!");

            if (await GetByApelido(dto.Apelido) != null) throw new CustomException("Apelido já cadastrado!");

            var model = _mapper.Map<UsuarioCadastroDto, UsuarioModel>(dto);
            _context.Usuario.Add(model);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioModel, UsuarioRetornoDto>(model);
        }

        public async Task<bool> DeleteAll()
        {
            var obj = _mapper.Map<List<UsuarioRetornoDto>, List<UsuarioModel>>(await GetAll());
            _context.Usuario.RemoveRange(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var obj = _mapper.Map<UsuarioRetornoDto, UsuarioModel>(await GetById(id));
            _context.Usuario.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UsuarioRetornoDto>> GetAll()
        {
            var obj = await _context.Usuario
                .Include(c => c.ClaimsForUser)
                    .ThenInclude(c => c.Claim)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<UsuarioModel>, List<UsuarioRetornoDto>>(obj);
        }

        public async Task<UsuarioRetornoDto> GetById(Guid id)
        {
            var obj = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new CustomException("Usuário não encontrado!") { HResult = 404 };
            return _mapper.Map<UsuarioModel, UsuarioRetornoDto>(obj);
        }
        public async Task<UsuarioRetornoDto> GetByApelido(string apelido)
        {
            var obj = await _context.Usuario
                .Include(c => c.ClaimsForUser)
                    .ThenInclude(c => c.Claim)
                .Where(x => x.Apelido == apelido)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return _mapper.Map<UsuarioModel, UsuarioRetornoDto>(obj);
        }

        public async Task<UsuarioRetornoDto> UpdateSenha(UsuarioUpdateSenha dto)
        {
            var obj = _mapper.Map<UsuarioModel>(await GetById(dto.UsuarioId));
            obj.Senha = dto.Senha;
            _context.Usuario.Update(obj);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioRetornoDto>(obj);
        }
    }
}
