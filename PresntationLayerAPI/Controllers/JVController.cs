using ApplicationLayer.Services;
using DTOS.JV;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntationLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JVController : ControllerBase
    {
        private readonly IJvService _JvService;

        public JVController(IJvService JvService)
        {
            _JvService = JvService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _JvService.GetAllAsync();
            return Ok(result);
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _JvService.GetOneAsync(id);
            if (result.IsSucess == false)
                return NotFound(result.MSG);

            return Ok(result.Entity);
        }

        [HttpGet("GetByNo/{jvNo}")]
        public async Task<IActionResult> GetByNo(int jvNo)
        {
            var result = await _JvService.GetByJvNoAsync(jvNo);
            if (result == null)
                return NotFound("JV not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JVCreateOrUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _JvService.CreateAsync(dto);
            if (result.IsSucess == false)
                return BadRequest(result.MSG);

            return Ok(result.Entity);
        }

 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JVCreateOrUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched ID");

            var result = await _JvService.UpdateAsync(dto);
            if (result.IsSucess == false)
                return BadRequest(result.MSG);

            return Ok(result.Entity);
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _JvService.DeleteAsync(id);
            if (result.IsSucess == false)
                return NotFound(result.MSG);

            return Ok(result.Entity);
        }
    }
}

