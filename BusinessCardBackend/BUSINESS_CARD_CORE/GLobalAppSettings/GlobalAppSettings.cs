using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_CORE
{
  public class GlobalAppSettings
  {
    public static AppSettings? AppSettings { get; set; }
  }

  public class AppSettings
  {
    public string? BusinessCardConnectionString { get; set; }
    public string? ImageDirectoryPath { get; set; }

  }
}
