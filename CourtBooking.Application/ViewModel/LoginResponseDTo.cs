using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.ViewModel
{
    public class LoginResponseDTO
    {
        public LocalUsers Users { get; set; }
        public string Token { get; set; }
    }
}
