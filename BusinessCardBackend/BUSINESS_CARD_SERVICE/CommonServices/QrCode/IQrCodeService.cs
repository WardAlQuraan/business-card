using BUSINESS_CARD_ENTITIES;
using Microsoft.AspNetCore.Http;

namespace BUSINESS_CARD_SERVICE.CommonServices.QrCode
{
  public interface IQrCodeService
  {
    Task<byte[]> GetBase64(BusinessCard businessCard);
    Task<BusinessCard?> GetBusinessCard(IFormFile file);
  }
}
