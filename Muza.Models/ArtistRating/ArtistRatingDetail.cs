using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.ArtistRating
{
    public class ArtistRatingDetail
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
    }
}