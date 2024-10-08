using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QrCodeController : ControllerBase
  {
    private readonly IQrCodeService _service;

    public QrCodeController(IQrCodeService qrCodeService)
    {
      this._service = qrCodeService;
    }

    [HttpPost("GetBusinessCard")]
    public async Task<IActionResult> GetBusinessCards([FromForm] IFormFile file)
    {
      return Ok(await _service.GetBusinessCard(file));
    }
  }
}
