using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Muza.Models.Rating;
using Muza.Services.AlbumRating;

namespace Muza.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumRatingController : ControllerBase
    {
        private readonly IAlbumRatingService _albumRatingService;
        public AlbumRatingController(IAlbumRatingService albumRatingService)
        {
            _albumRatingService = albumRatingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbumRatings()
        {
            var albumRatings = await _albumRatingService.GetAllAlbumRatingsAsync();
            return Ok(albumRatings);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateAlbumRating([FromForm] AlbumRatingCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _albumRatingService.CreateAlbumRatingAsync(request))
            {
                return Ok("Rating add successfully.");
            }

            return BadRequest("Rating could not be added");
        }
    }
}