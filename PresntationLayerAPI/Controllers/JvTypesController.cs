using ApplicationLayer.Services;
using DTOS.ACC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresntationLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JvTypesController : ControllerBase
    {
        private readonly IJvTypesService _JvServ;

        public JvTypesController(IJvTypesService JvServ)
        {
            _JvServ = JvServ;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountGetAllDTO>>> GetAll()
        {

            var result = await _JvServ.GetAllAsync();
            return Ok(result);
        }
    }
}
