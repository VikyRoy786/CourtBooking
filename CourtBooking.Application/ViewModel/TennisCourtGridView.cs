using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.ViewModel
{
    public class TennisCourtGridView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public double? Rate { get; set; }
        public string? Address { get; set; }
        public string? Availbility { get; set; }
    }
}
