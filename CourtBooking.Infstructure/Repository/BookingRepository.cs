using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CourtBooking.Infstructure.Repository
{
    public class BookingRepository : BaseRepository<Bookings>, IBookingRepository
    {
        public BookingRepository(BookingDbContext dbContext, ILogger<Bookings> logger): base(dbContext, logger) { }

        public async Task<IList<UserBookingsView>> GetUserBookings(int userId)
        {
            var bookingDetails = await (from booking in _context.Bookings
                                        join court in _context.TennisCourts on booking.CourtId equals court.Id
                                        where booking.UserId == userId
                                        select new UserBookingsView 
                                        {
                                            BookingId = booking.BookingId,
                                            FromDate = booking.FromDate,
                                            ToDate = booking.ToDate,
                                            CourtName = court.Name

                                        }).ToListAsync(); 
            return await Task.FromResult(bookingDetails);
        }
    }
}
