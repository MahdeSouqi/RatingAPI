using System;

namespace RatingAPI.DTOs
{
  public class RatingReadDto
  {
    public Guid VetId { get; set; }

    public double RatePoint { get; set; }
  }
}