using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Models;
using Muza.Models.Artist;
using Muza.Services.Artist;
using Microsoft.AspNetCore.Mvc;

namespace Muza.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistservice)
        {
            _artistService = artistservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _artistService.CreateArtistAsync(request))
                return Ok("Artist created successfully");
            
            return BadRequest("Artist could not be created.");
        }

        [HttpGet("{artistId:int}")]
        public async Task<IActionResult> GetArtistById([FromRoute] int artistId)
        {
            var detail = await _artistService.GetArtistByIdAsync(artistId);

            return detail is not null
                ? Ok(detail)
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArtistById([FromBody] ArtistUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _artistService.UpdateArtistAsync(request)
                ? Ok("Artist was updated successfully.")
                : BadRequest("Artist could not be updated.");
        }

        [HttpDelete("{artistId:int}")]
        public async Task<IActionResult> DeleteArtist([FromRoute] int artistId)
        {
            return await _artistService.DeleteArtistAsync(artistId)
                ? Ok($"Artist {artistId} was deleted successfully.")
                : BadRequest($"Artist {artistId} could not be deleted.");
        }
    }
}