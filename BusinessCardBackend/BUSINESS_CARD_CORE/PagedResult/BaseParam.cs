using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_CORE
{
  public class BaseParam
  {
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
    public string? SortColumn { get; set; }
    public string? SortDirection { get; set; } = "asc";
  }
}
