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
        Task<bool> CreateArtistAsync(ArtistCreate request);
        Task<IEnumerable<ArtistListItem>> GetAllArtistsAsync();
        Task<ArtistDetail> GetArtistByIdAsync(int artistId);
        Task<bool> UpdateArtistAsync(ArtistUpdate request);
        Task<bool> DeleteArtistAsync(int artistId);
    }
}