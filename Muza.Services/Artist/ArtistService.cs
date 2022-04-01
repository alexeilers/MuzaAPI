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
        public ArtistService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build ArtistService without User Id claim.");

                _dbContext = dbContext;
        }

        public async Task<bool> CreateArtistAsync(ArtistCreate request)
        {
            var artistEntity = new ArtistEntity
            {
                Name = request.Name,
                Genre = request.Genre,
                Description = request.Description,
                OwnerId = _userId
            };

            _dbContext.Artists.Add(artistEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ArtistListItem>> GetAllArtistsAsync()
        {
            var artists = await _dbContext.Artists
                .Where(entity => entity.OwnerId == _userId)
                .Select(entity => new ArtistListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                })
                .ToListAsync();
            
            return artists;
        }

        public async Task <ArtistDetail> GetArtistByIdAsync(int artistId)
        {
            var artistEntity = await _dbContext.Artists
                .FirstOrDefaultAsync(e =>
                    e.Id == artistId && e.OwnerId == _userId
                );
            return artistEntity is null ? null : new ArtistDetail
            {
                Id = artistEntity.Id,
                Name = artistEntity.Name,
                Genre = artistEntity.Genre,
                Description = artistEntity.Description,
            };
        }

        public async Task<bool> UpdateArtistAsync(ArtistUpdate request)
        {
            var artistEntity = await _dbContext.Artists.FindAsync(request.Id);

            if (artistEntity?.OwnerId != _userId)
                return false;
            
            artistEntity.Name = request.Name;
            artistEntity.Genre = request.Genre;
            artistEntity.Description = request.Description;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteArtistAsync(int artistId)
        {
            var artistEntity = await _dbContext.Artists.FindAsync(artistId);

            if (artistEntity?.OwnerId != _userId)
                return false;

            _dbContext.Artists.Remove(artistEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}