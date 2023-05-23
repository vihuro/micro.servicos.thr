using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THR.ObraNotas.DTO.NotaRadarDto;
using THR.ObraNotas.Interface;

namespace THR.OBRA.NOTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasRadarController : ControllerBase
    {
        private readonly INotaRADARService _service;

        public NotasRadarController(INotaRADARService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<NotaTXTDto>>> GetAll()
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
