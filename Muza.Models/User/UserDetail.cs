using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muza.Models.User
{
    public class UserDetail
    {
        public int Id {get; set;}
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}