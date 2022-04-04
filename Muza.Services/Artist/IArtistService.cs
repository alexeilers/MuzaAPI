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

        // Get Artists
        Task<IEnumerable<ArtistListItem>> GetAllArtistsAsync();

        // Read Artist
        Task<ArtistDetail> GetArtistByIdAsync(int artistId);

        // Update Artists
        Task<bool> UpdateArtistAsync(ArtistUpdate request);

        // Delete Artist
        Task<bool> DeleteArtistAsync(int artistId);
    }
}