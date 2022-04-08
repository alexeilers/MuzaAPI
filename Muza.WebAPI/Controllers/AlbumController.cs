using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Muza.Models.Album;
using Muza.Services.Album;

namespace Muza.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        //Post api/Album/AddAlbum
        [HttpPost("AddAlbum")]
        public async Task<IActionResult> CreateAlbum([FromForm] AlbumCreate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _albumService.CreateAlbumAsync(request))
            {
                return Ok($"{request.Title} was created successfully.");
            }

            return BadRequest("Album could not be created.");
        }

        //Get api/Album
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AlbumListItem>), 200)]
        public async Task<IActionResult> GetAllAlbums()
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            return Ok(albums);
        }

        //Get api/Album/ByArtist/1
        [HttpGet("ByArtist/{artistId:int}")]
        [ProducesResponseType(typeof(IEnumerable<AlbumListItem>), 200)]
        public async Task<IActionResult> GetAllAlbumsByArtistId([FromRoute] int artistId)
        {
            var albumDetail = await _albumService.GetAllAlbumsByArtistIdAsync(artistId);

            return albumDetail is not null ? Ok(albumDetail) : NotFound($"There are no albums with an Id of {artistId}.");
        }

        //Get api/Album/1
        [HttpGet("{albumId:int}")]
        [ProducesResponseType(typeof(AlbumDetail), 200)]
        public async Task<IActionResult> GetAlbumById([FromRoute] int albumId)
        {
            var albumDetail = await _albumService.GetAlbumByIdAsync(albumId);

            return albumDetail is not null? Ok(albumDetail) : NotFound("There is no album matching that Id.");
        }

        //Get api/Album/ByTitle
        [HttpGet("ByTitle")]
        [ProducesResponseType(typeof(AlbumDetail), 200)]
        public async Task<IActionResult> GetAlbumByTitle([FromForm] string albumTitle)
        {
            var albumDetail = await _albumService.GetAlbumByTitleAsync(albumTitle);

            return albumDetail is not null? Ok(albumDetail) : NotFound("There is no album matching that title.");
        }

        //Get api/Album/ByArtistName
        [HttpGet("ByArtistName")]
        [ProducesResponseType(typeof(IEnumerable<AlbumListItem>), 200)]
        public async Task<IActionResult> GetAllAlbumsByArtistName([FromForm] string artistName)
        {
            var albums = await _albumService.GetAllAlbumsByArtistNameAsync(artistName);

            return albums is not null ? Ok(albums) : NotFound($"There are currently no albums by {artistName}");
        }

        //Put api/Album
        [HttpPut]
        public async Task<IActionResult> UpdateAlbumById([FromForm] AlbumUpdate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _albumService.UpdateAlbumAsync(request)
            ? Ok("Album was updated successfully.")
            : BadRequest("Album could not be updated.");
        }

        //Delete api/Album/1
        [HttpDelete("{albumId:int}")]
        public async Task<IActionResult> DeleteAlbumById([FromRoute] int albumId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _albumService.DeleteAlbumAsync(albumId)
            ? Ok($"Album {albumId} was deleted successfully.")
            : BadRequest($"Album {albumId} could not be deleted.");
        }
    }
}