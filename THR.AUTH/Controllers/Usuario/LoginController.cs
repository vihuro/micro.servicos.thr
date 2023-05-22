using Microsoft.AspNetCore.Mvc;
using THR.auth.DTO.Usuario;
using THR.AUTH.Interface;

namespace THR.AUTH.Controllers.Usuario
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public LoginController(IUsuarioService service)
        {
            _service = service;
        }
        [HttpPost("createded")]
        [ProducesResponseType(typeof(UsuarioRetornoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioRetornoDto>> Create(UsuarioCadastroDto dto)
        {
            try
            {
                return Created("", await _service.Cadastro(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<UsuarioRetornoDto>> UpdateSenha(UsuarioUpdateSenha dto)
        {
            try
            {
                return Ok(await _service.UpdateSenha(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
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
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRetornoDto>> GetById(Guid id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404)
                {
                    return NotFound();
                }
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                return Ok(await _service.DeleteAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(Guid id)
        {
            try
            {
                return Ok(await _service.DeleteById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpOptions]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");
            return Ok();
        }
    }

}
