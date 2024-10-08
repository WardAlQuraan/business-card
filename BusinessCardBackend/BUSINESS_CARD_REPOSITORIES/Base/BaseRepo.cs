using BUSINESS_CARD_CORE;
using BUSINESS_CARD_ENTITIES;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace BUSINESS_CARD_REPOSITORIES
{
  public class BaseRepo<T , C , SP> : IBaseRepo<T , C , SP>
    where T : BaseEntity
    where C : DbContext
    where SP : BaseParam 
  {
    protected readonly C _context;

    public BaseRepo(C context)
    {
      _context = context;
    }

    public virtual async Task<PaginationResult<T>> SearchAsync(SP param)
    {
      var query = _context.Set<T>().AsQueryable();
      query = IQuerableFilter(param, query);

      int count = await query.CountAsync();
      var items = await query
            .Skip(param.PageIndex * param.PageSize)
            .Take(param.PageSize)
            .ToListAsync();

      var res = new PaginationResult<T>(items, count, param);
      return res;
    }

    protected string? GetPropertyName(string name, Type type)
    {
      var prop = type
          .GetProperties()
          .FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
      return prop?.Name;
    }

    protected virtual IQueryable<T> IQuerableFilter(SP param, IQueryable<T> query)
    {
      if (!string.IsNullOrEmpty(param.SortColumn))
      {
        var prop = GetPropertyName(param.SortColumn, typeof(T)); // Corrected method name

        if (prop is not null)
        {
          string orderByString = $"{prop} {(param.SortDirection.Equals("asc", StringComparison.OrdinalIgnoreCase) ? "asc"
              : "desc")}";
          query = query.OrderBy(orderByString);
        }
      }
      return query;
    }

    public async Task<List<T>> GetAllAsync(SP param)
    {
      var query = _context.Set<T>().AsQueryable();
      query = IQuerableFilter(param, query);

      return await query.ToListAsync();
    }

    public async Task<T> InsertAsync(T item)
    {
      _context.Set<T>().Add(item);

      await _context.SaveChangesAsync();

      return item;
    }

    public async Task<int> BulkInsertAsync(List<T> items)
    {
      items.ForEach(b => b.Id = 0);
      _context.Set<T>().AddRange(items);

      await _context.SaveChangesAsync();

      return items.Count();
    }
    public async Task<bool> DeleteAsync(int id)
    {
      var item = await _context.Set<T>().FindAsync(id);

      if (item == null)
      {
        return false;
      }

      _context.Set<T>().Remove(item);

      await _context.SaveChangesAsync();

      return true;
    }


  }
}
