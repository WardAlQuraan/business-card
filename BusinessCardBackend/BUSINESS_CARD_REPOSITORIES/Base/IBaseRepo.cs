using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using Microsoft.EntityFrameworkCore;

namespace BUSINESS_CARD_REPOSITORIES
{
  public interface IBaseRepo<T, C, SP>
    where T : BaseEntity
    where C : DbContext
    where SP : BaseParam
  {
    Task<PaginationResult<T>> SearchAsync(SP param);
    Task<List<T>> GetAllAsync(SP param);
    Task<T> InsertAsync(T item);
    Task<int> BulkInsertAsync(List<T> items);
    Task<bool> DeleteAsync(int id);
  }
}
