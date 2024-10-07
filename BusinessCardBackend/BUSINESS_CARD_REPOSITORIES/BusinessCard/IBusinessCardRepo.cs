using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;

namespace BUSINESS_CARD_REPOSITORIES
{
  public interface IBusinessCardRepo
  {
    Task<PaginationResult<BusinessCard>> SearchAsync(BusinessCardSearchParam param);
    Task<BusinessCard> InsertAsync(BusinessCardInsertParam newBusinessCard);
    Task<bool> DeleteAsync(int id);
    Task<List<BusinessCard>> GetAllAsync(BusinessCardSearchParam param);
    Task<int> BulkInsertAsync(List<BusinessCard> businessCards);
  }
}
