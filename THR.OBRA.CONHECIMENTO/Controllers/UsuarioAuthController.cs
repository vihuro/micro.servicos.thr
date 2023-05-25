using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THR.OBRA.CONHECIMENTO.DTO.Usuario.AUTH;
using THR.OBRA.CONHECIMENTO.Interface;

namespace THR.OBRA.CONHECIMENTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAuthController : ControllerBase
    {
        private readonly IUsuarioAUTHService _service;

        public UsuarioAuthController(IUsuarioAUTHService service)
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

                return BadRequest(ex.Message);
            }
        }
    }
}
