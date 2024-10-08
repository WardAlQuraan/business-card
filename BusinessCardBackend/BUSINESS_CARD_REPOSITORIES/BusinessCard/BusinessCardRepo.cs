using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_ENTITIES;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using BUSINESS_CARD_CORE;

namespace BUSINESS_CARD_REPOSITORIES
{
  public class BusinessCardRepo : BaseRepo<BusinessCard , BusinessCardContext, BusinessCardSearchParam> , IBusinessCardRepo
  {

    public BusinessCardRepo(BusinessCardContext businessCardContext) : base(businessCardContext)
    {
    }

    public override bool Equals(object? obj)
    {
      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override async Task<PaginationResult<BusinessCard>> SearchAsync(BusinessCardSearchParam param)
    {
      var query = _context.BusinessCards.AsQueryable();
      query = IQuerableFilter(param, query);

      int count = await query.CountAsync();
      var businessCards = await query
            .Skip(param.PageIndex * param.PageSize)
            .Take(param.PageSize)
            .ToListAsync();

      var res = new PaginationResult<BusinessCard>(businessCards, count, param);
      return res;
    }

    public override string? ToString()
    {
      return base.ToString();
    }

    protected override IQueryable<BusinessCard> IQuerableFilter(BusinessCardSearchParam param, IQueryable<BusinessCard> query)
    {
      query = base.IQuerableFilter(param, query);

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


  }
}
