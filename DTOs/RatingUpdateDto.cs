using System;
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.DTOs
{
  public class RatingUpdateDto
  {
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid VetId { get; set; }

    [Required]
    public int RatePoints { get; set; }
  }
}