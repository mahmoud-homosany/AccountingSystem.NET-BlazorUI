using ApplicationLayer.Services;
using DTOS.JVDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntationLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JVDetailsController : ControllerBase
    {
        private readonly IJVDetailsService _JVDetail;

        public JVDetailsController(IJVDetailsService JVDetail)
        {
            _JVDetail = JVDetail;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _JVDetail.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _JVDetail.GetOneAsync(id);
            if (result.IsSucess == false)
                return NotFound(result.MSG);

            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JVDetailCreateOrUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _JVDetail.CreateAsync(dto);
            if (result.IsSucess == false)
                return BadRequest(result.MSG);

            return Ok(result.Entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JVDetailCreateOrUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched ID");

            var result = await _JVDetail.UpdateAsync(dto);
            if (result.IsSucess == false)
                return BadRequest(result.MSG);

            return Ok(result.Entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _JVDetail.DeleteAsync(id);
            if (result.IsSucess == false)
                return NotFound(result.MSG);

            return Ok(result.Entity);
        }
    }
}

