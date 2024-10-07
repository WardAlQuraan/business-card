using BUSINESS_CARD_ENTITIES;
using Microsoft.AspNetCore.Http;

namespace BUSINESS_CARD_SERVICE.CommonServices
{
  public interface IFileCommonService
  {
    Task<byte[]> GetBase64(BusinessCardSearchParam param);
    Task<List<BusinessCard>> GetBusinessCards(IFormFile file);


  }
}
