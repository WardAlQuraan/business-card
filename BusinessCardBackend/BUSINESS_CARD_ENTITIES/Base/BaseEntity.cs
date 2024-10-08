using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_ENTITIES
{
  public class BaseEntity
  {
    [Key]
    public int Id { get; set; }
  }
}
