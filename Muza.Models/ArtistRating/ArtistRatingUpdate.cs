using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Muza.Models.ArtistRating
{
    public class ArtistRatingUpdate
    {
        [Required]
        public int Id {get; set;}
        
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between {1} and {2}")]
        public int Rating {get; set;}
    }
}