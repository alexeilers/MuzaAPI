using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Data;
using Muza.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Muza.Models.ArtistRating;

namespace Muza.Services.ArtistRating
{
    public class ArtistRatingService : IArtistRatingService
    {
        private readonly ApplicationDbContext _dbContext;
        public ArtistRatingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateArtistRatingAsync(ArtistRatingCreate request)
    {
        var artistRatingEntity = new ArtistRatingEntity
        {
            ArtistId = request.ArtistId,
            Rating = request.Rating,
            CreatedUtc = DateTimeOffset.Now
        };

        _dbContext.ArtistRatings.Add(artistRatingEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }


        public async Task<IEnumerable<ArtistRatingListItem>> GetAllArtistRatingsAsync()
        {
            var artistRating = await _dbContext.ArtistRatings.Select(entity => new ArtistRatingListItem
            {
                Id = entity.Id,
                ArtistId = entity.ArtistId,
                Rating = entity.Rating
            }).ToListAsync();

            return artistRating;
        }
// REMOVED GET ALBUM RATINGS BY ID METHOD

        public async Task<bool> UpdateArtistRatingAsync(ArtistRatingUpdate request)
        {
            var ArtistRatingEntity = await _dbContext.ArtistRatings.FindAsync(request.Id);

            if (ArtistRatingEntity?.Id != 1)
                return false;
            
            ArtistRatingEntity.Rating = request.Rating;
            

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        public async Task<bool> DeleteArtistRatingAsync(int ArtistRatingId)
        {
            var artistRatings = await _dbContext.ArtistRatings.FindAsync(ArtistRatingId);

            if(artistRatings is null)
            {
                return false;
            }

            _dbContext.ArtistRatings.Remove(artistRatings);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}