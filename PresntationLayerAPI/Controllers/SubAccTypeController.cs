using ApplicationLayer.Services;
using DTOS.SubAccType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntationLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccTypeController : ControllerBase
    {
        private readonly ISubAccTypeService _subAccTypeService;

        public SubAccTypeController(ISubAccTypeService subAccTypeService)
        {
            _subAccTypeService = subAccTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubAccTypeDto>>> GetAll()
        {
            var result = await _subAccTypeService.GetAllAsync();
            return Ok(result);
        }
    }
}

