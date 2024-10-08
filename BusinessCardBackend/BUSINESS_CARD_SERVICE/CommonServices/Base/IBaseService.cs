using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_SERVICE.CommonServices
{
  public interface IBaseService<T , SP> where T : BaseEntity where SP : BaseParam
  {
    Task<PaginationResult<T>> SearchAsync(SP param);
    Task<T> InsertAsync(T item) ;
    Task<bool> DeleteAsync(int id);
  }
}
