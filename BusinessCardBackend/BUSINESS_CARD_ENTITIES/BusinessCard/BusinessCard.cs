using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUSINESS_CARD_ENTITIES
{
  [Table("BUSINESS_CARD")]
  public class BusinessCard
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public DateTime DOB { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }

    [Column("IMAGE")]
    public string? Base64 { get; set; }

  }

}
