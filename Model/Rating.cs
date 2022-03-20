using System;
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Model
{
  public class Rating
  {
    [Key]
    public Guid VetId { get; set; }

    [Required]
    public int UserCount { get; set; }

    [Required]
    public double RatePoints { get; set; }
  }
}