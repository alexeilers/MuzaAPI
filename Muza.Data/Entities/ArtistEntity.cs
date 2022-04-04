using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Data.Entities
{
    public class ArtistEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        [Required]
        [Range(1,999, ErrorMessage = "Artist name must contain more than one character.")]
        public string Name { get; set; }
        [Required]
        [Range(1,999, ErrorMessage = "Genre must contain more than one character.")]
        public string Genre { get; set; }
        [Required]
        [Range(1,9999, ErrorMessage = "Description must be from {0} to {1}.")]
        public string Description { get; set; }
        public List<AlbumEntity> ListOfAlbums { get; set; }
        [Required]
        public DateTime DateCreatedUtc { get; set; }
        
    }
}