using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muza.Data;
using Muza.Data.Entities;
using Muza.Models.ARNote.cs;
using Muza.Models.Rating;

namespace Muza.Services.AlbumRating
{
    public class AlbumRatingService : IAlbumRatingService
    {
        private readonly ApplicationDbContext _dbContext;
        public AlbumRatingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create New AlbumRating
        public async Task<bool> CreateAlbumRatingAsync(AlbumRatingCreate request)
        {
            var albumRatingEntity = new AlbumRatingEntity
            {
                Rating = request.AlbumRating,
                AlbumId = request.AlbumId,
                CreatedUtc = DateTimeOffset.Now
            };

            _dbContext.AlbumRatings.Add(albumRatingEntity);
            
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        // Get All AlbumRatings
        public async Task<IEnumerable<AlbumRatingListItems>> GetAllAlbumRatingsAsync()
        {
            var albumRating = await _dbContext.AlbumRatings
            .Select(entity => new AlbumRatingListItems
            {
                Id = entity.Id,
                Rating = entity.Rating,
                AlbumId = entity.AlbumId,
            })
            .ToListAsync();

            return albumRating;
        }

        // Get All AlbumRatings by Id
        public async Task<AlbumRatingDetail> GetAlbumRatingByIdAsync(int albumId)
        {
            var albumRatingEntity = await _dbContext.AlbumRatings
                .FirstOrDefaultAsync(e =>
                e.Id == albumId);
            return albumRatingEntity is null ? null : new AlbumRatingDetail
            {
                Id =albumRatingEntity.Id,
                AlbumId = albumRatingEntity.AlbumId,
                Rating = albumRatingEntity.Rating,
                CreatedUtc = albumRatingEntity.CreatedUtc,
                ModifiedUtc = albumRatingEntity.ModifiedUtc
            };
        }

        // Update AlbumRating
        public async Task<bool> UpdateAlbumRatingAsync(AlbumRatingUpdate request)
        {
            var albumRatingEntity = await _dbContext.AlbumRatings.FindAsync(request.Id);
            if (albumRatingEntity is null)
                return false;

            albumRatingEntity.Rating = request.Rating;
            albumRatingEntity.ModifiedUtc = DateTimeOffset.Now;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        // Delete AlbumRating
        public async Task<bool> DeleteAlbumRatingAsync(int albumId)
        {
            // Find AlbumRating by Id
            var albumRatingEntity = await _dbContext.AlbumRatings.FindAsync(albumId);

            // Validate that the AlbumRating exist
            if (albumRatingEntity is null)
                return false;

            // Delete AlbumRating by Id
            _dbContext.AlbumRatings.Remove(albumRatingEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}