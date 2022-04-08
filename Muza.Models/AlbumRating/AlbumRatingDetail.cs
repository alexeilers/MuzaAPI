using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.ARNote.cs
{
    public class AlbumRatingDetail
    {
        public int Id {get;set;}
        public int AlbumId {get;set;}
        public int Rating {get;set;}
        public DateTimeOffset CreatedUtc {get;set;}
        public DateTimeOffset? ModifiedUtc {get;set;}
    }
}