using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models
{
    public class ArtistListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string YearCreated { get; set; }
        public string Description { get; set; }
    }
}