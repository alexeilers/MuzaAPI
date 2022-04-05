using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Muza.Models.ArtistRating;
using Muza.Services.ArtistRating;


namespace Muza.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistRatingController : ControllerBase
    {
        private readonly IArtistRatingService _artistRatingService;
        public ArtistRatingController(IArtistRatingService artistRatingService)
        {
            _artistRatingService = artistRatingService;
        }

    [HttpPost]
    public async Task<IActionResult> CreateArtistRating([FromBody] ArtistRatingCreate request)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

        if (await _artistRatingService.CreateArtistRatingAsync(request))
        return Ok("Artist rating created successfully.");

        return BadRequest("Artist rating could not be created.");
    }
    //Get api/ArtistRating
    [HttpGet]
    public async Task<IActionResult> GetAllArtistRatings()
    {
        var ratings = await _artistRatingService.GetAllArtistRatingsAsync();
            return Ok(ratings);
    }
    


    [HttpPut]
    public async Task<IActionResult> UpdateArtistRatingById([FromBody] ArtistRatingUpdate request)
    {
        if (!ModelState.IsValid)
        return BadRequest(ModelState);

        return await _artistRatingService.UpdateArtistRatingAsync(request)
        ? Ok("Artist rating updated successfully.")
        : BadRequest("Artist rating could not be updated.");
    }
    
    // DELETE api/ArtistRating/5
    [HttpDelete("{artistId:int}")]
    public async Task<IActionResult> DeleteArtistRating([FromRoute] int artistRatingId)
    {
        return await _artistRatingService.DeleteArtistRatingAsync(artistRatingId)
        ? Ok($"Artist rating {artistRatingId} was deleted successfully.")
        : BadRequest($"Artist rating {artistRatingId} could not be deleted.");
    }
    }
}