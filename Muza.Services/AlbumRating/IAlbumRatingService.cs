using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Models.Rating;
using Muza.Data.Entities;
using Muza.Models.ARNote.cs;

namespace Muza.Services.AlbumRating
{
    public interface IAlbumRatingService
    {
        Task<bool> CreateAlbumRatingAsync(AlbumRatingCreate request);
        Task<IEnumerable<AlbumRatingListItems>> GetAllAlbumRatingsAsync();
        Task<AlbumRatingDetail> GetAlbumRatingByIdAsync(int albumRatingId);
        Task<bool> UpdateAlbumRatingAsync(AlbumRatingUpdate request);
        Task<bool> DeleteAlbumRatingAsync(int albumRatingId);
    }
}