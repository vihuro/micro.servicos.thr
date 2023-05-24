using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.OBRA.NOTAS.ContextBase;
using THR.OBRA.NOTAS.DTO.NotaTHRDto;
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

            var usuario = await _usuarioService.GetById(dto.UsuarioCadastroId);

            if (usuario == null) throw new MyException("Usuário não cadastrado!");

            var obj = _mapper.Map<InsertNotaDto, NotasModel>(dto);

            _context.Add(obj);
            await _context.SaveChangesAsync();
            return await GetNotaId(obj.Id);

        }
        public async Task<string> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RetornoNotaThrDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<RetornoNotaThrDto> GetNotaId(Guid id)
        {
            var obj = await _context.Notas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(p => p.Parcelas)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return _mapper.Map<NotasModel,RetornoNotaThrDto>(obj);
        }

        public async Task<List<RetornoNotaThrDto>> GetNotaNumeroNota(int numeroNota)
        {
            throw new NotImplementedException();
        }


    }
}
