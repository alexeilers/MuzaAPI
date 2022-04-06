using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Muza.Data;
using Muza.Data.Entities;
using Muza.Models;
using Muza.Models.Artist;

namespace Muza.Services.Artist
{
    public class ArtistService : IArtistService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public ArtistService(ApplicationDbContext dbContext)
        {

                _dbContext = dbContext;
        }

        public async Task<bool> CreateArtistAsync(ArtistCreate request)
        {
            var artistEntity = new ArtistEntity
            {
                Name = request.Name,
                Genre = request.Genre,
                YearCreated = request.YearCreated,
                Description = request.Description,
                OwnerId = 1
            };

            _dbContext.Artists.Add(artistEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ArtistListItem>> GetAllArtistsAsync()
        {
            var artists = await _dbContext.Artists
                .Select(entity => new ArtistListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Genre = entity.Genre,
                    Description = entity.Description,
                })
                .ToListAsync();
            
            return artists;
        }

        public async Task <ArtistDetail> GetArtistByIdAsync(int artistId)
        {
            var artistEntity = await _dbContext.Artists
                .FirstOrDefaultAsync(e =>
                    e.Id == artistId 
                );
            return artistEntity is null ? null : new ArtistDetail
            {
                Id = artistEntity.Id,
                Name = artistEntity.Name,
                Genre = artistEntity.Genre,
                YearCreated = artistEntity.YearCreated,
                Description = artistEntity.Description,
            };
        }

        public async Task<bool> UpdateArtistAsync(ArtistUpdate request)
        {
            var artistEntity = await _dbContext.Artists.FindAsync(request.Id);

            // if (artistEntity?.OwnerId != 1)
            //     return false;
            
            artistEntity.Name = request.Name;
            artistEntity.Genre = request.Genre;
            artistEntity.YearCreated = request.YearCreated;
            artistEntity.Description = request.Description;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteArtistAsync(int artistId)
        {
            var artistEntity = await _dbContext.Artists.FindAsync(artistId);

            // if (artistEntity?.OwnerId != _userId)
            //     return false;

            _dbContext.Artists.Remove(artistEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}