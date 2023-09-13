using CourtBooking.Application.Contracts.IBusiness;
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
    public class TennisCourtBusiness : ITennisCourtBusiness
    {
        private readonly ITennisCourtRepository _tennisCourtRepository;
        public TennisCourtBusiness(ITennisCourtRepository tennisCourtRepository)
        {
                _tennisCourtRepository = tennisCourtRepository;
        }
        public async Task<IList<TennisCourts>> CourtList()
        {
            return await _tennisCourtRepository.CourtList();
        }
        public async Task AddTennisCourt(TennisCourtCreatedDTO tennisCourtCreatedDTO)
        {
            TennisCourts tc = new TennisCourts();
            tc.Name = tennisCourtCreatedDTO.Name;
            tc.Details = tennisCourtCreatedDTO.Details;
            tc.Rate = tennisCourtCreatedDTO?.Rate;
            tc.CreatedDate = DateTime.Now;  
            await _tennisCourtRepository.AddAsync(tc);
        }
    }
}
