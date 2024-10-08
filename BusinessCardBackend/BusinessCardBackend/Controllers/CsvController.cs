using BUSINESS_CARD_SERVICE.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CsvController : ControllerBase
  {
    private readonly ICsvService _service;

    public CsvController(ICsvService service)
    {
      _service = service;
    }

    [HttpPost("GetBusinessCards")]
    public async Task<IActionResult> GetBusinessCards([FromForm]IFormFile file)
    {
      return Ok(await _service.GetBusinessCards(file));
    }
  }
}
