using Microsoft.EntityFrameworkCore;
using RatingAPI.Model;

namespace RatingAPI.Data
{
    public class RatingContext : DbContext
    {
        public DbSet<Rating> Rate { get; set; }
        public RatingContext(DbContextOptions<RatingContext> opt) : base(opt)
        {
        }
        
    }
}