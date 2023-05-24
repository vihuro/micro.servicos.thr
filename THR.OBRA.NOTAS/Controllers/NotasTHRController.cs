using Microsoft.AspNetCore.Mvc;
using THR.OBRA.NOTAS.DTO.NotaTHRDto;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotasTHRController : ControllerBase
    {
        private readonly INotaTHRService _service;

        public NotasTHRController(INotaTHRService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<RetornoNotaThrDto>>> GetAll()
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
        [HttpPost]
        public async Task<ActionResult<RetornoNotaThrDto>> Insert(InsertNotaDto dto)
        {
            try
            {
                return Created("", await _service.Insert(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RetornoNotaThrDto>> GetById(Guid id)
        {
            try
            {
                return Ok(await _service.GetNotaId(id));
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
    }
}
