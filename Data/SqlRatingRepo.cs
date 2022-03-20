using System;
using System.Linq;
using RatingAPI.Model;

namespace RatingAPI.Data
{
    public class SqlRatingRepo : IRatingRepo
    {
        private readonly RatingContext _context;

        public SqlRatingRepo( RatingContext context )
        {
            _context = context;
        }
        
        
        public void Rate(Rating rating)
        {
            if (rating == null)
            {
                throw new ArgumentNullException(nameof(rating));
            }

            _context.Rate.Add(rating);
        }

        public Rating GetRateByVetId(Guid id)
        {
            return _context.Rate.FirstOrDefault(p => p.VetId == id);
        }
        
        public Rating CalculateRating(Rating rating)
        {
            Rating rate = new Rating();
            rate.RatePoints = rating.RatePoints / rating.UserCount;
            return rate;
        }

        public void AddVetId(Rating rating)
        {
            if (rating == null)
            {
                throw new ArgumentNullException();
            }

            _context.Rate.Add(rating);
        }

        public void UpdateRate(Rating rating)
        {
           
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}