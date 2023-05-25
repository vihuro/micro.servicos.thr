using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.OBRA.NOTAS.ContextBase;
using THR.OBRA.NOTAS.DTO.NotaTHRDto;
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;
using THR.OBRA.NOTAS.Interface;
using THR.OBRA.NOTAS.Models.Notas;
using THR.OBRA.NOTAS.Service.CustomException;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Service.NotasTHR
{
    public class NotasTHRService : INotaTHRService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IUsuarioOBRAService _usuarioService;

        public NotasTHRService(IMapper mapper, 
                                Context context, 
                                IUsuarioOBRAService usuarioService)
        {
            _mapper = mapper;
            _context = context;
            _usuarioService = usuarioService;
        }

        public async Task<RetornoNotaThrDto> Insert(InsertNotaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Fornecedor) ||
                string.IsNullOrWhiteSpace(dto.Autorizador) ||
                string.IsNullOrWhiteSpace(dto.NumeroNota.ToString()) ||
                string.IsNullOrWhiteSpace(dto.TimeId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.UsuarioCadastroId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.ValorTotalNota.ToString())) throw new MyException("Campo(s) obrigatório(s) vazio(s)!");

            _ = await _usuarioService.GetById(dto.UsuarioCadastroId)
                ?? throw new MyException("Usuário não cadastrado!");

            var obj = _mapper.Map<InsertNotaDto, NotasModel>(dto);

            _context.Notas.Add(obj);
            await _context.SaveChangesAsync();
            return await GetNotaId(obj.Id);

        }
        public async Task<string> DeleteAll()
        {
            var list = await _context.Notas
                .AsNoTracking()
                .ToListAsync();
            _context.RemoveRange(list);
            await _context.SaveChangesAsync();
            return "Notas excluidas com sucesso!";
        }

        public async Task<List<RetornoNotaThrDto>> GetAll()
        {
            var list = await _context.Notas
                .Include(p => p.ProdutosServico)
                .Include(c => c.Parcelas)
                .Include(t => t.Time)
                .Include(c => c.ProdutosServico)
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .ToListAsync();

            
            return _mapper.Map<List<NotasModel>,List<RetornoNotaThrDto>>(list);
        }

        public async Task<RetornoNotaThrDto> GetNotaId(Guid id)
        {
            var obj = await _context.Notas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(p => p.Parcelas)
                .Include(t => t.Time)
                .Include(p => p.ProdutosServico)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return _mapper.Map<NotasModel,RetornoNotaThrDto>(obj);
        }

        public async Task<RetornoNotaThrDto> GetNotaNumeroNota(int numeroNota)
        {
            var obj = await _context.Notas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(p => p.Parcelas)
                .Include(t => t.Time)
                .Include(p => p.ProdutosServico)
                .Where(x => x.NumeroNota.Equals(numeroNota))
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return _mapper.Map<NotasModel, RetornoNotaThrDto>(obj);
        }


    }
}
