using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muza.Data;
using Muza.Data.Entities;
using Muza.Models.Album;

namespace Muza.Services.Album
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _dbContext;

        public AlbumService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create New Album
        public async Task<bool> CreateAlbumAsync(AlbumCreate request)
        {
            var album = new AlbumEntity
            {
                Title = request.Title,
                ArtistId = request.ArtistId,
                Description = request.Description,
                SongList = request.SongList
            };

            _dbContext.Albums.Add(album);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Get All Albums
        public async Task<IEnumerable<AlbumListItem>> GetAllAlbumsAsync()
        {
            var albums = await _dbContext.Albums.Select(entity => new AlbumListItem
            {
                Id = entity.Id,
                ArtistId = entity.ArtistId,
                Title = entity.Title,
                Description = entity.Description
            }).ToListAsync();

            return albums;
        }

        //Get All Albums by ArtistId
        public async Task<IEnumerable<AlbumListItem>> GetAllAlbumsByArtistIdAsync(int artistId)
        {
            var albums = await _dbContext.Albums.Where(entity => entity.ArtistId == artistId)
            .Select(entity => new AlbumListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description
            }).ToListAsync();

            return albums;
        }

        //Get Album by Id
        public async Task<AlbumDetail> GetAlbumByIdAsync(int albumId)
        {
            //Find the first album that has the given ID that matches the request
            var album = await _dbContext.Albums.FirstOrDefaultAsync(a => a.Id == albumId);

            //If AlbumEntity is null then return null, else return new AlbumDetail
            return album is null ? null : new AlbumDetail
            {
                Id = album.Id,
                ArtistId = album.ArtistId,
                Title = album.Title,
                Description = album.Description,
                SongList = album.SongList,
                CreatedUtc = album.CreatedUtc
            };

        }

        //Get Album by Title
        public async Task<AlbumDetail> GetAlbumByTitleAsync(string albumTitle)
        {
            //Find first album that has the given Title that matches the request
            var album = await _dbContext.Albums.FirstOrDefaultAsync(a => a.Title == albumTitle);

            //If the AlbumEntity is null then return null, else return new AlbumDetail
            return album is null ? null : new AlbumDetail
            {
                Id = album.Id,
                ArtistId = album.ArtistId,
                Title = album.Title,
                Description = album.Description,
                SongList = album.SongList,
                CreatedUtc = album.CreatedUtc
            };            
        }

        //Update Album
        public async Task<bool> UpdateAlbumAsync (AlbumUpdate request)
        {
            //Find the AlbumEntity
            var album = await _dbContext.Albums.FindAsync(request.Id);

            if(album is null)
            {
                return false;
            }

            //Update entity's properties
            album.Title = request.Title;
            album.Description = request.Description;
            album.SongList = request.SongList;
            album.ModifiedUtc = DateTimeOffset.Now;

            //Save Changes to the DB
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        //Delete Album
        public async Task<bool> DeleteAlbumAsync(int albumId)
        {
            //Find album by Id
            var album = await _dbContext.Albums.FindAsync(albumId);

            //Validate the album exists
            if(album is null)
            {
                return false;
            }

            //Delete the album
            _dbContext.Albums.Remove(album);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}