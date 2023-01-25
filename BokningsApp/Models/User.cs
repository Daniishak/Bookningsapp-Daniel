using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
