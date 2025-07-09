using ApplicationLayer.Services;
using DTOS.ACC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PresntationLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ACCController : ControllerBase
    {
        private readonly IAccService _AccServ;

        public ACCController(IAccService AccServ)
        {
            _AccServ = AccServ;
        }



        [HttpGet]
        public async Task<ActionResult<List<AccountGetAllDTO>>> GetAll()
        {

            var result = await _AccServ.GetAllAsync();
            return Ok(result);
        }

    }
}
