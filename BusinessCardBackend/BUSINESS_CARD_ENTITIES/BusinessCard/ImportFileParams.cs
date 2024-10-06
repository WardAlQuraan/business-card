using BUSINESS_CARD_CORE.CommonEnums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_ENTITIES
{
  public class ImportFileParams
  {
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
  }
  
}
