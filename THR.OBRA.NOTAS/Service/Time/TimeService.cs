using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.OBRA.NOTAS.ContextBase;
using THR.OBRA.NOTAS.DTO.Time;
using THR.OBRA.NOTAS.Interface;
using THR.OBRA.NOTAS.Models.Notas;
using THR.OBRA.NOTAS.Service.CustomException;

namespace THR.OBRA.NOTAS.Service.Time
{
    public class TimeService : ITimeService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IUsuarioOBRAService _usuarioService;

        public TimeService(IMapper mapper, 
                            Context context, 
                            IUsuarioOBRAService usuarioOBRAService)
        {
            _mapper = mapper;
            _context = context;
            _usuarioService = usuarioOBRAService;
        }

        public async Task<RetornoTimeDto> Insert(InsertTimeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Times) ||
                string.IsNullOrWhiteSpace(dto.UsuarioCadastroId.ToString())) throw new MyException("Campo(s) obrigatório(s) vazios(s)!");
            _ = await _usuarioService.GetById(dto.UsuarioCadastroId) ??
                throw new MyException("Usuário não cadastrado!");
            var obj = _mapper.Map<InsertTimeDto, TimesModel>(dto);
            _context.Times.Add(obj);
            await _context.SaveChangesAsync();
            return await GetById(obj.Id);
        }


        public async Task<List<RetornoTimeDto>> GetAll()
        {
            var list = await _context.Times
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<TimesModel>,List<RetornoTimeDto>>(list);
        }

        public async Task<RetornoTimeDto> GetByTime(string time)
        {
            var obj = await _context.Times
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .Where(x => x.Time.Equals(time))
                .FirstOrDefaultAsync();

            return _mapper.Map<TimesModel, RetornoTimeDto>(obj);
        }

        public async Task<RetornoTimeDto> GetById(Guid id)
        {
            var obj = await _context.Times
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            return _mapper.Map<TimesModel, RetornoTimeDto>(obj);
        }

        public async Task<string> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<string> DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
