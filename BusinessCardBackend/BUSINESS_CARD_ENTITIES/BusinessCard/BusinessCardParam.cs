using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_ENTITIES
{
    public class BusinessCardParam
    {
        public int? Id {  get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string? SortColumn { get; set; }
        public string? SortDirection { get; set; } = "asc";

        
    }
}
