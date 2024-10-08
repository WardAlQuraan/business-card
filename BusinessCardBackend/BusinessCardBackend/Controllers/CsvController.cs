using BUSINESS_CARD_SERVICE.CommonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CsvController : ControllerBase
  {
    private readonly ICsvService _csvBase64Service;
    private readonly IXmlService _xmlBase64Service;
  }
}
