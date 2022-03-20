using AutoMapper;
using RatingAPI.Dto;
using RatingAPI.Model;

namespace RatingAPI.Profile
{
    public class RatingProfile : AutoMapper.Profile
    {

        public RatingProfile()
        {
            CreateMap<Rating, RatingReadDto>();
            CreateMap<Rating, RatingUpdateDto>();
            CreateMap<RatingCreateDto, Rating>();
        }
        
    }
}