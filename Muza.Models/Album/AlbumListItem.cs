using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.Album
{
    public class AlbumListItem
    {
        public int Id {get; set;}
        public int ArtistId {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
    }
}