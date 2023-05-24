using Microsoft.AspNetCore.Mvc;
using THR.OBRA.NOTAS.DTO.Usuario.AUTH;
using THR.ObraNotas.Interface;

namespace THR.ObraNotas.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioExternoController : ControllerBase
    {
        private readonly IUsuarioAUTHService _service;

        public UsuarioExternoController(IUsuarioAUTHService service)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioRetornoDto>>> GetById(Guid Id)
        {
            try
            {
                return Ok(await _service.GetById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
