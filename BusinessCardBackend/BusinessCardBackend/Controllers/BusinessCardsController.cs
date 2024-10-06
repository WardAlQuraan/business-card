using BUSINESS_CARD_CORE.CommonEnums;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE;
using BUSINESS_CARD_SERVICE.CommonServices;
using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BusinessCardBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BusinessCardsController : ControllerBase
  {
    private readonly IBusinessCardService _businessCardService;
    private readonly IXmlBase64Service _xmlBase64Service;
    private readonly ICsvBase64Service _csvBase64Service;
    private readonly IQrCodeService _qrCodeService;

    public BusinessCardsController(IBusinessCardService businessCardService, ICsvBase64Service csvBase64Service, IXmlBase64Service xmlBase64Service , IQrCodeService qrCodeService)
    {
      _businessCardService = businessCardService;
      _csvBase64Service = csvBase64Service;
      _xmlBase64Service = xmlBase64Service;
      _qrCodeService = qrCodeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BusinessCardSearchParam param)
    {
      var entities = await _businessCardService.SearchAsync(param);
      return Ok(entities);
    }

    [HttpPost]
    public async Task<IActionResult> Post(BusinessCardInsertParam businessCard)
    {
      var entities = await _businessCardService.InsertAsync(businessCard);
      return Ok(entities);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
      var entities = await _businessCardService.DeleteAsync(id);
      return Ok(entities);
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export([FromQuery] FileType fileType)
    {
      byte[] bytes;
      string contentType;
      string extension;
      switch (fileType)
      {
        case FileType.CSV:
          bytes = await _csvBase64Service.GetBase64();
          contentType = "text/csv";
          extension = "csv";
          break;
        default:
          bytes = await _xmlBase64Service.GetBase64();
          contentType = "application/xml";
          extension = "xml";
          break;

      }

      return File(bytes, contentType, "businessCards." + extension);
    }


    [HttpPost("import")]
    public async Task<IActionResult> Import([FromForm] ImportFileParams @params)
    {
      return Ok(await _businessCardService.Import(@params));
    }

    [HttpPost("GenerateQrCode")]
    public async Task<IActionResult> GenerateQrCode(BusinessCard businessCard)
    {
      var qrCodeBytes = await _qrCodeService.GetBase64(businessCard);
      return File(qrCodeBytes, "image/png", "qr_code.png");
    }


  }
}
