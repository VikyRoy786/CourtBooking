using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.ViewModel
{
    public class BookingDTO
    {
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        [Required]
        public int CourtId { get; set; }
        
    }
}
