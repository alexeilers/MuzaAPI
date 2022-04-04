using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Models.ArtistRating;

namespace Muza.Services.ArtistRating
{
    public interface IArtistRatingService
    {
        Task<bool> CreateArtistRatingAsync(ArtistRatingCreate request);
        Task<IEnumerable<ArtistRatingListItem>> GetAllArtistRatingAsync();
        Task<ArtistRatingDetail> GetArtistRatingByIdAsync(int artistId);
        Task<bool> UpdateArtistRatingAsync(ArtistRatingUpdate request);
        Task<bool> DeleteArtistRatingAsync(int artistId);
    }
}