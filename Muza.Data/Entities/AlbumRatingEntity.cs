using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Data.Entities
{
    public class AlbumRatingEntity
    {
      [Key]
      public int Id {get;set;}

      [Required]
      [ForeignKey(nameof(Album))]
      public int AlbumId {get;set;}
      public AlbumEntity Album {get;set;}

      [Required]
      [Range(1,5, ErrorMessage = "Rating must be from {1} to {5}")]
      public int Rating {get;set;}  

      [Required]
      public DateTimeOffset CreatedUtc {get;set;}
      public DateTimeOffset? ModifiedUtc {get;set;}
    }
}