using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Vecka { get; set; } // finns 52 dagar
        public string dag { get; set; } // finns 7 dagar
        public string bokade { get; set;}
    }
}
