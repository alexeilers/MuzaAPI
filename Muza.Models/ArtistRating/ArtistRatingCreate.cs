using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.ArtistRating
{
    public class ArtistRatingCreate
    {
        [Required]
        public int ArtistId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between {1} and {2}")]
        public int Rating { get; set; }
    }
}