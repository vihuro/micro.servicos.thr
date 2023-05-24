using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using THR.OBRA.NOTAS.ContextBase;
using THR.OBRA.NOTAS.DTO.Usuario.AUTH;
using THR.OBRA.NOTAS.DTO.Usuario.OBRA;
using THR.OBRA.NOTAS.Interface;
using THR.OBRA.NOTAS.Models.Usuario;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Service.Usuario
{
    public class UsuarioOBRAService : IUsuarioOBRAService
    {
        private readonly Context _context;
        private readonly IUsuarioAUTHService _usuarioAUTHService;
        private readonly IMapper _mapper;

        public UsuarioOBRAService(Context context, 
                                    IUsuarioAUTHService usuarioAUTHService, 
                                    IMapper mapper)
        {
            _context = context;
            _usuarioAUTHService = usuarioAUTHService;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            var list = await  _context.Usuario
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<UsuarioModel>, List<UsuarioDto>>(list);
        }

        public async Task<UsuarioDto> GetById(Guid id)
        {
            var obj = _context.Usuario
                .AsNoTracking()
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
            if(obj != null) return _mapper.Map<UsuarioModel, UsuarioDto>(obj);

            var apiExterna = await _usuarioAUTHService.GetById(id);
            var convert = _mapper.Map<UsuarioRetornoDto, UsuarioDto>(apiExterna);

            if (apiExterna != null) return await CadastrarUsuario(convert);
            return null;

        }

        private async Task <UsuarioDto> CadastrarUsuario(UsuarioDto apiExterna)
        {
            
            var obj = _mapper.Map<UsuarioDto, UsuarioModel>(apiExterna);
            _context.Usuario.Add(obj);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioModel, UsuarioDto>(obj);
        }
    }
}
