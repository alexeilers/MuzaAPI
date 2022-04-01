using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.Rating
{
    public class AlbumRatingUpdate
    {
        [Required]
        public int Id {get;set;}
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between {1} and {5}")]
        public int Rating {get;set;}
    }
}