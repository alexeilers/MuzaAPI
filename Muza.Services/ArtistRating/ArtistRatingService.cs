using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Data;
using Muza.Data.Entities;
using Muza.Models.ArtistRating;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Muza.Services.ArtistRating
{
    public class ArtistRatingService : IArtistRatingService
    {
        private readonly ApplicationDbContext _context;

        public async Task<bool> CreateArtistRatingAsync(ArtistRatingCreate request)
    {
        var artistRatingEntity = new ArtistRatingEntity
        {
            ArtistId = request.ArtistId,
            Rating = request.Rating,
            DateCreated = DateTime.Now
        };

        _context.ArtistRating.Add(artistRatingEntity);

        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }

        public Task<bool> DeleteArtistRatingAsync(int ArtistId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistRatingListItem>> GetAllArtistRatingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArtistRatingDetail> GetArtistRatingByIdAsync(int ArtistId)
        {
            throw new NotImplementedException();
        }
    }
}