using Microsoft.AspNetCore.Mvc;
using THR.auth.DTO.Claims;
using THR.AUTH.Interface;

namespace THR.auth.Controllers.Claims
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _service;

        public ClaimsController(IClaimsService service)
        {
            _service = service;
        }

        [HttpPost("createded")]
        public async Task<ActionResult<ClaimsRetornoDto>> Createde(ClaimsCastroDto dto)
        {
            try
            {
                return Created("", await _service.Create(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<ClaimsRetornoDto>> GetAll()
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
        public async Task<ActionResult<ClaimsRetornoDto>> GetById(Guid id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {

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

    }
}
