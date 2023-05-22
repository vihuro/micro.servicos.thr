using Microsoft.AspNetCore.Mvc;
using THR.auth.DTO.Usuario;
using THR.ObraNotas.Interface;

namespace THR.ObraNotas.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioRetornoDto>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
