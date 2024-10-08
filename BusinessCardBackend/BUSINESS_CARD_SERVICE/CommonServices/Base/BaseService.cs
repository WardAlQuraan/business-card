using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_SERVICE.CommonServices.Base
{
  public class BaseService<T,C, R, SP> : IBaseService<T , SP>
    where T : BaseEntity
    where R : IBaseRepo<T,C,SP>
    where SP : BusinessCardSearchParam
    where C : DbContext 
  {
    protected readonly R _repo;

    public BaseService(R repo)
    {
      _repo = repo;
    }

    public virtual async Task<PaginationResult<T>> SearchAsync(SP param)
    {
      return await _repo.SearchAsync(param);
    }

    public virtual async Task<T> InsertAsync(T businessCard)
    {
      return await _repo.InsertAsync(businessCard);
    }

    public virtual async Task<int> InsertBulkAsync(List<T> items)
    {
      return await _repo.BulkInsertAsync(items);
    }

    public async Task<bool> DeleteAsync(int id)
    {
      return await _repo.DeleteAsync(id);
    }
  }
}
