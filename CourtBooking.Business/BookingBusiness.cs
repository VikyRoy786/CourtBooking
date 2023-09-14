using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.Core.Exception;
using CourtBooking.Application.Repository.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Business
{
    public class BookingBusiness : IBookingBusniess
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ITennisCourtRepository _tennisCourtRepository;
        public BookingBusiness(IBookingRepository bookingRepository, ITennisCourtRepository tennisCourtRepository)
        {
            _bookingRepository = bookingRepository;
            _tennisCourtRepository = tennisCourtRepository;
        }
        public async Task MakeBooking(BookingDTO bookingDTO, int userId)
        {
            Bookings bookings = new Bookings();
            bookings.FromDate = bookingDTO.FromDate;
            bookings.ToDate = bookingDTO.ToDate;
            bookings.CourtId = bookingDTO.CourtId;  
            bookings.UserId = userId;
            await _bookingRepository.AddAsync(bookings);
            //After Booking a Court availabilty of Court Chnages

            var court = await _tennisCourtRepository.GetByIdAsync(bookings.CourtId);
                        
            court.Availbility = false;
            await _tennisCourtRepository.UpdateAsync(court);

        }
        public async Task<IList<UserBookingsView>> GetUserBookings(int userId)
        {
            var bookigs = await _bookingRepository.GetUserBookings(userId);
            return bookigs;
        }
        public async Task UpdateBooking (UpdateBookingDTO updateBookingDTO , int id)
        {
            var existing = await _bookingRepository.GetByIdAsync(id);
            if (existing == null)
            {
                throw new NotFoundException(string.Format(ConstantsBusiness.BookingNotFound), id);
            }
            else
            {
                existing.FromDate = updateBookingDTO.FromDate;
                existing.ToDate = updateBookingDTO.ToDate;
                await _bookingRepository.UpdateAsync(existing);
            }
        }
        public async Task <Bookings> GetBookingDetails(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }
    }
}
