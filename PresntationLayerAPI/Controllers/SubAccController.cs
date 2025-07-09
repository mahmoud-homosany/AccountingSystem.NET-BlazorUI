using ApplicationLayer.Services;
using DTOS.Shared;
using DTOS.SubACC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntationLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccController : ControllerBase
    {
        private readonly ISubAccService _service;

        public SubAccController(ISubAccService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubACCGetAllVM>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubACCGetAllVM>> GetOne(int id)
        {
            var result = await _service.GetOneAsync(id);

            if (result.IsSucess==false)
                return NotFound(result.MSG);

            return Ok(result.Entity);
        }

        [HttpPost]
        public async Task<ActionResult<ResultView<CreateOrUpdateVM>>> Create([FromBody] CreateOrUpdateVM dto)
        {
            var result = await _service.CreateAsync(dto);

            if (!result.IsSucess.HasValue || result.IsSucess == false)
                return BadRequest(result.MSG);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultView<CreateOrUpdateVM>>> Update(int id, [FromBody] CreateOrUpdateVM dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            var result = await _service.UpdateAsync(dto);

            if (!result.IsSucess.HasValue || result.IsSucess == false)
                return BadRequest(result.MSG);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultView<SubACCGetAllVM>>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.IsSucess.HasValue || result.IsSucess == false)
                return NotFound(result.MSG);

            return Ok(result);
        }
    }
}

