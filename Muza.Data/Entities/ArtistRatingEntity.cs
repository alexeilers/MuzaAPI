using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Data.Entities
{
    public class ArtistRatingEntity
    {
        
        [Key]
        public int Id {get; set;}

        [Required]
        [ForeignKey(nameof(Artist))]
        public int ArtistId {get; set;}
        public ArtistEntity Artist {get; set;}

        [Required]
        public int Rating {get; set;}
 
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}