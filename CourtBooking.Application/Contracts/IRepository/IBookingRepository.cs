using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.Contracts.IRepository
{
    public interface IBookingRepository : IAsyncRepository<Bookings>
    {
        public  Task<IList<UserBookingsView>> GetUserBookings(int userId);
    }
}
