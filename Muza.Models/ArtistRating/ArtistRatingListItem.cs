using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.ArtistRating
{
    public class ArtistRatingListItem
    {
        public int Id { get; set; }
        public int ArtistRatingId { get; set; }
        public int Rating { get; set; }
        
    }
}