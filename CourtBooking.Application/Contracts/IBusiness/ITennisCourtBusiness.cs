using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.Contracts.IBusiness
{
    public interface ITennisCourtBusiness
    {
        public  Task<IList<TennisCourts>> CourtList();
        public  Task AddTennisCourt(TennisCourtCreatedDTO tennisCourtCreatedDTO);
    }
}
