using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Models.ArtistRating;

namespace Muza.Services.ArtistRating
{
    public interface IArtistRatingService
    {
        //Create artist ratings
        Task<bool> CreateArtistRatingAsync(ArtistRatingCreate request);
        //Get all Artist ratings
        Task<IEnumerable<ArtistRatingListItem>> GetAllArtistRatingsAsync();
        //Update artist rating
        Task<bool> UpdateArtistRatingAsync(ArtistRatingUpdate request);
        //Delete artist rating
        Task<bool> DeleteArtistRatingAsync(int ArtistRatingId);
    }
}