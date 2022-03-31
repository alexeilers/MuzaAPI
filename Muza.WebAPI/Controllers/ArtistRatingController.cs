using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Muza.Models.ArtistRating;
using Muza.Services.ArtistRating;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

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

    //Get api/Note
    [HttpGet]
    public async Task<IActionResult> GetAllArtistRatings()
    {
        var notes = await _artistRatingService.GetAllArtistRatingAsync();
            return Ok(notes);
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

    // DELETE api/Note/5
    [HttpDelete("{artistId:int}")]
    public async Task<IActionResult> DeleteArtistRating([FromRoute] int artistId)
    {
        return await _artistRatingService.DeleteArtistRatingAsync(artistId)
        ? Ok($"Artist rating {artistId} was deleted successfully.")
        : BadRequest($"Artist rating {artistId} could not be deleted.");
    }
    }
}