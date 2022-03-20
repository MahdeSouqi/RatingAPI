
using System.ComponentModel.DataAnnotations;

namespace RatingAPI.Dto
{
    public class RatingUpdateDto
    {   
        
        [Required]
        public int RatePoints { get; set; }
        
    }
}