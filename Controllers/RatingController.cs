using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatingAPI.Data;
using RatingAPI.Dto;
using RatingAPI.Model;

namespace RatingAPI.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepo _repo;

        public RatingController(IRatingRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult<RatingReadDto> AddVet(RatingCreateDto createDto)
        {
            var mapped = _mapper.Map<Rating>(createDto);
            _repo.AddVetId(mapped);
            var readMapped = _mapper.Map<RatingReadDto>(mapped);
            return Ok(readMapped);
        }

        [HttpGet("{id}")]
        public ActionResult<RatingReadDto> GetRateByVetId(Guid id)
        {
            var ratingFromDb = _repo.GetRateByVetId(id);
            if (ratingFromDb == null)
            {
                return NotFound();
            }
            var calculatedRate = _repo.CalculateRating(ratingFromDb);
            RatingReadDto read = new RatingReadDto();
            read.RatePoint = calculatedRate.RatePoints;
            read.VetId = id;
            return Ok(read);
        }


        [HttpPut]
        public ActionResult RatingUpdate( Rating rating)
        {
            var dataFromServe = _repo.GetRateByVetId(rating.VetId);
            if (dataFromServe == null)
            {
                return NotFound();
            }
            dataFromServe.UserCount++;
            dataFromServe.RatePoints += rating.RatePoints;
            _repo.SaveChanges();
            _repo.UpdateRate(rating);
            return NoContent();
        }
        



    }
}