using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id {get; set;}

        [Required( ErrorMessage = "Please enter an e-mail address,")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

    }
}