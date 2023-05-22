using Newtonsoft.Json;
using THR.auth.DTO.Usuario;
using THR.OBRA.NOTAS.ContextBase;
using THR.ObraNotas.Interface;

namespace THR.ObraNotas.Service.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }

        public async Task<List<UsuarioRetornoDto>> GetAll()
        {
            var _httpClient = new HttpClient();

            var response = await _httpClient.GetAsync("http://odin/api/v1/login");
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<List<UsuarioRetornoDto>>(jsonString);
            return jsonObject;
        }
    }
}
