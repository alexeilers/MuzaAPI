using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.Album
{
    public class AlbumDetail
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public int ArtistId {get; set;}
        public string ArtistName {get; set;}
        public string Description {get; set;}
        public string SongList {get; set;}
        public DateTimeOffset CreatedUtc {get; set;}
    }
}