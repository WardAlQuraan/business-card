using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;

namespace BUSINESS_CARD_SERVICE
{
  public interface IBusinessCardService
  {
    Task<PaginationResult<BusinessCard>> SearchAsync(BusinessCardSearchParam param);
    Task<BusinessCard> InsertAsync(BusinessCardInsertParam newBusinessCard);
    Task<bool> DeleteAsync(int id);
    Task<int> Import(ImportFileParams @params);
  }
}
