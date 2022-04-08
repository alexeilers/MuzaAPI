using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Models;
using Muza.Models.Artist;

namespace Muza.Services.Artist
{
    public interface IArtistService
    {
        // Create Artist
        Task<bool> CreateArtistAsync(ArtistCreate request);

        // Get All Artists
        Task<IEnumerable<ArtistListItem>> GetAllArtistsAsync();

        // Get Artists by Id
        Task<ArtistDetail> GetArtistByIdAsync(int artistId);

        // Get Artists by Name
        Task<ArtistDetail> GetByArtistNameAsync(string artistName);

        // Update Artists
        Task<bool> UpdateArtistAsync(ArtistUpdate request);

        // Delete Artist
        Task<bool> DeleteArtistAsync(int artistId);
    }
}