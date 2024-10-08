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
  public class BusinessCardsController : CommonController<
    BusinessCard ,
    IBusinessCardService ,
    BusinessCardSearchParam
    >
  {
    private readonly IXmlService _xmlBase64Service;
    private readonly ICsvService _csvBase64Service;
    private readonly IQrCodeService _qrCodeService;

    public BusinessCardsController(
      IBusinessCardService businessCardService,
      ICsvService csvBase64Service,
      IXmlService xmlBase64Service ,
      IQrCodeService qrCodeService) : base(businessCardService)
    {
      _csvBase64Service = csvBase64Service;
      _xmlBase64Service = xmlBase64Service;
      _qrCodeService = qrCodeService;
    }



    [HttpPost]
    public async Task<IActionResult> Post(BusinessCardInsertParam businessCard)
    {
      var entities = await _service.InsertAsync(businessCard);
      return Ok(entities);
    }

    [NonAction]
    public override Task<IActionResult> Post(BusinessCard item)
    {
      return base.Post(item);
    }

    

    [HttpGet("export")]
    public async Task<IActionResult> Export([FromQuery] BusinessCardSearchParam param)
    {
      byte[] bytes;
      string contentType;
      string extension;
      switch (param.FileType)
      {
        case FileType.CSV:
          bytes = await _csvBase64Service.GetBase64(param);
          contentType = "text/csv";
          extension = "csv";
          break;
        default:
          bytes = await _xmlBase64Service.GetBase64(param);
          contentType = "application/xml";
          extension = "xml";
          break;

      }

      return File(bytes, contentType, "businessCards." + extension);
    }


    [HttpPost("InsertBulk")]
    public async Task<IActionResult> InsertBulk(List<BusinessCard> businessCards)
    {
      return Ok(await _service.InsertBulkAsync(businessCards));
    }

    [HttpPost("GenerateQrCode")]
    public async Task<IActionResult> GenerateQrCode(BusinessCard businessCard)
    {
      var qrCodeBytes = await _qrCodeService.GetBase64(businessCard);
      return File(qrCodeBytes, "image/png", "qr_code.png");
    }


  }
}
