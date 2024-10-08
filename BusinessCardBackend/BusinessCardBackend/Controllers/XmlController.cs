using BUSINESS_CARD_SERVICE.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class XmlController : ControllerBase
  {
    private readonly IXmlService _service;

    public XmlController(IXmlService service)
    {
      _service = service;
    }

    [HttpPost("GetBusinessCards")]
    public async Task<IActionResult> GetBusinessCards([FromForm] IFormFile file)
    {
      return Ok(await _service.GetBusinessCards(file));
    }
  }
}
