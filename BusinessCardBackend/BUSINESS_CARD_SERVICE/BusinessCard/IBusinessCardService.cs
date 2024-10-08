using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_SERVICE.CommonServices;

namespace BUSINESS_CARD_SERVICE
{
  public interface IBusinessCardService : IBaseService<BusinessCard , BusinessCardSearchParam>
  {
    Task<int> Import(ImportFileParams @params);
    Task<BusinessCard> InsertAsync(BusinessCardInsertParam businessCard);

  }
}
