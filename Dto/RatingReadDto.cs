using System;

namespace RatingAPI.Dto
{
    public class RatingReadDto
    {
        public Guid VetId { get; set; }
        public double RatePoint { get; set; }
    }
}