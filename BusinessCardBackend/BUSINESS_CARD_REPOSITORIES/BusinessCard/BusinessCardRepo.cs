using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_ENTITIES;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESS_CARD_CORE;

namespace BUSINESS_CARD_REPOSITORIES
{
  public class BusinessCardRepo : IBusinessCardRepo
  {
    private readonly BusinessCardContext _businessCardContext;

    public BusinessCardRepo(BusinessCardContext businessCardContext)
    {
      _businessCardContext = businessCardContext;
    }

    public string? GetPropertyName(string name, Type type)
    {
      var prop = type
          .GetProperties()
          .FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
      return prop?.Name;
    }
    public async Task<PaginationResult<BusinessCard>> SearchAsync(BusinessCardSearchParam param)
    {
      var query = _businessCardContext.BusinessCards.AsQueryable();
      query = IQuerableFilter(param, query);

      int count = await query.CountAsync();
      var businessCards = await query
            .Skip(param.PageIndex * param.PageSize)
            .Take(param.PageSize)
            .ToListAsync();

      var res = new PaginationResult<BusinessCard>(businessCards, count, param);
      return res;
    }

    public async Task<List<BusinessCard>> GetAllAsync(BusinessCardSearchParam param)
    {
      var query = _businessCardContext.BusinessCards.AsQueryable();
      query = IQuerableFilter(param, query);

      return await query.ToListAsync();
    }


    private IQueryable<BusinessCard> IQuerableFilter(BusinessCardSearchParam param, IQueryable<BusinessCard> query)
    {
      if (!string.IsNullOrEmpty(param.SortColumn))
      {
        var prop = GetPropertyName(param.SortColumn, typeof(BusinessCard)); // Corrected method name

        if (prop is not null)
        {
          string orderByString = $"{prop} {(param.SortDirection.Equals("asc", StringComparison.OrdinalIgnoreCase) ? "asc"
              : "desc")}";
          query = query.OrderBy(orderByString);
        }
      }


      query = query.Where(b =>
          (!param.Id.HasValue || b.Id == param.Id) &&
          (string.IsNullOrEmpty(param.Name) || b.Name.Contains(param.Name)) &&
          (string.IsNullOrEmpty(param.Phone) || b.Phone.Contains(param.Phone)) &&
          (string.IsNullOrEmpty(param.Email) || b.Email.Contains(param.Email)) &&
          (string.IsNullOrEmpty(param.Gender) || b.Gender.Equals(param.Gender)) &&
          (!param.DOB.HasValue || b.DOB.Date == param.DOB.Value.Date)
      );
      return query;
    }

    
    public async Task<BusinessCard> InsertAsync(BusinessCardInsertParam newBusinessCard)
    {
      _businessCardContext.BusinessCards.Add(newBusinessCard);

      await _businessCardContext.SaveChangesAsync();

      return newBusinessCard;
    }
    public async Task<int> BulkInsertAsync(List<BusinessCard> businessCards)
    {
      businessCards.ForEach(b => b.Id = 0);
      _businessCardContext.BusinessCards.AddRange(businessCards);

      await _businessCardContext.SaveChangesAsync();

      return businessCards.Count();
    }
    public async Task<bool> DeleteAsync(int id)
    {
      var businessCard = await _businessCardContext.BusinessCards.FindAsync(id);

      if (businessCard == null)
      {
        return false;
      }

      _businessCardContext.BusinessCards.Remove(businessCard);

      await _businessCardContext.SaveChangesAsync();

      return true;
    }

  }
}
