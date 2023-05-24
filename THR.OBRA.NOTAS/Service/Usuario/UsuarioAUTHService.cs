using Newtonsoft.Json;
using THR.OBRA.NOTAS.ContextBase;
using THR.OBRA.NOTAS.DTO.Usuario.AUTH;
using THR.ObraNotas.Interface;

namespace THR.ObraNotas.Service.Usuario
{
    public class UsuarioAUTHService : IUsuarioAUTHService
    {
        private readonly HttpClient _httpClient;

        public UsuarioAUTHService()
        {
            _httpClient = new HttpClient(); 
        }
        public async Task<List<UsuarioRetornoDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("http://localhost:5071/api/v1/login");
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<List<UsuarioRetornoDto>>(jsonString);
            return jsonObject;
        }
        public async Task<UsuarioRetornoDto> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5071/api/v1/login/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<UsuarioRetornoDto>(jsonString);
            return jsonObject;
        }
    }
}
