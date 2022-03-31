using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muza.Models.Album;

namespace Muza.Services.Album
{
    public interface IAlbumService
    {
        Task<bool> CreateAlbumAsync(AlbumCreate request);
        Task<IEnumerable<AlbumListItem>> GetAllAlbumsAsync();
        Task<IEnumerable<AlbumListItem>> GetAllAlbumsByArtistIdAsync(int artistId);
        Task<AlbumDetail> GetAlbumByIdAsync(int albumId);
        Task<AlbumDetail> GetAlbumByTitleAsync(string albumTitle);
        Task<bool> UpdateAlbumAsync(AlbumUpdate request);
        Task<bool> DeleteAlbumAsync (int albumId);

    }
}