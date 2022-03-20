using System;
using RatingAPI.Dto;
using RatingAPI.Model;

namespace RatingAPI.Data
{
    public interface IRatingRepo
    {

        public void Rate(Rating rating);

        public Rating GetRateByVetId(Guid id);

        public Rating CalculateRating(Rating rating);

        public void AddVetId(Rating rating);
        public void UpdateRate(Rating rating);

        public bool SaveChanges();

    }
}