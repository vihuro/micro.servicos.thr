using Microsoft.AspNetCore.Mvc;
using THR.OBRA.NOTAS.DTO.Time;
using THR.OBRA.NOTAS.Interface;

namespace THR.OBRA.NOTAS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _service;

        public TimeController(ITimeService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<RetornoTimeDto>> GetAll()
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
        public async Task<ActionResult<RetornoTimeDto>> Insert(InsertTimeDto dto)
        {
            try
            {
                return Ok(await _service.Insert(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{time}")]
        public async Task<ActionResult<RetornoTimeDto>> GetByTime(string time)
        {
            try
            {
                return Ok(await _service.GetByTime(time));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RetornoTimeDto>> GetById(Guid id)
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
    }
}
