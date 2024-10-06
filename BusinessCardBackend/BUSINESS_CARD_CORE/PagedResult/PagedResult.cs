using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_CORE
{
  public class PaginationResult<T>
  {
    public PaginationResult(List<T> data, int count, PaginateParam paginateParam)
    {
      Data = data;
      Count = count;
      PageSize = paginateParam.PageSize;
      PageIndex = paginateParam.PageIndex;
    }

    public List<T> Data { get; set; }
    public int Count { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }

  }
}
