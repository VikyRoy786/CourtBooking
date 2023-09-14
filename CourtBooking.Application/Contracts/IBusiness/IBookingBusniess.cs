using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.Contracts.IBusiness
{
    public interface IBookingBusniess
    {
        public Task MakeBooking(BookingDTO bookingDTO, int userId);
        public  Task<IList<UserBookingsView>> GetUserBookings(int userId);
        public Task UpdateBooking(UpdateBookingDTO updateBookingDTO, int id);
        public  Task<Bookings> GetBookingDetails(int id);
    }
}
