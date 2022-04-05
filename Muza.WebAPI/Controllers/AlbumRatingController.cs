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

        // Post API/AlbumRating/Add AlbumRating
        [HttpPost("AddRating")]
        public async Task<IActionResult> CreateAlbumRating([FromForm] AlbumRatingCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _albumRatingService.CreateAlbumRatingAsync(request))
            {
                return Ok("Album Rating created successfully.");
            }

            return BadRequest("Album Rating could not be created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbumRatings()
        {
            var albumRatings = await _albumRatingService.GetAllAlbumRatingsAsync();
            return Ok(albumRatings);
        }

        // Get API/AlbumRating
        [HttpGet("{albumRatingId:int}")]
        public async Task<IActionResult> GetAlbumRatingByIdAsync([FromRoute] int albumRatingId)
        {   
            var albumRatingDetail = await _albumRatingService.GetAlbumRatingByIdAsync(albumRatingId);
                return albumRatingDetail is not null
                    ? Ok(albumRatingDetail)
                    : NotFound("There are no Album Ratings matching that Id.");
        }

        // Put API/AlbumRating/Update
        [HttpPut]
        public async Task<IActionResult> UpdateAlbumAsync([FromForm] AlbumRatingUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _albumRatingService.UpdateAlbumRatingAsync(request)
                ? Ok("Album Rating was updated successfully.")
                : BadRequest("Album Rating could not be updated.");
        }

        // Delete API/Album Rating
        [HttpDelete("{albumRatingId:int}")]
        public async Task<IActionResult> DeleteAlbumRating([FromRoute] int albumRatingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _albumRatingService.DeleteAlbumRatingAsync(albumRatingId)
                ? Ok($"Album Rating {albumRatingId} was deleted successfully.")
                : BadRequest("Album Rating {albumRatingId} could not be deleted");
        }
    }
}