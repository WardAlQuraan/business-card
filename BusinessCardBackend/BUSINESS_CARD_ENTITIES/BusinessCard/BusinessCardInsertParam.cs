using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUSINESS_CARD_ENTITIES
{
  public class BusinessCardInsertParam : BusinessCard
  {
    [NotMapped]
    public IFormFile? Image { get; set; }
  }
}
