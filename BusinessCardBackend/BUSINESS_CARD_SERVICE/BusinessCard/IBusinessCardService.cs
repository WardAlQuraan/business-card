using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_SERVICE.CommonServices;

namespace BUSINESS_CARD_SERVICE
{
  public interface IBusinessCardService : IBaseService<BusinessCard , BusinessCardSearchParam>
  {
    Task<BusinessCard> InsertAsync(BusinessCardInsertParam businessCard);

  }
}
