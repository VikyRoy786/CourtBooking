using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.Repository.IRepository
{
    public interface ITennisCourtRepository : IAsyncRepository<TennisCourts>
    {
        public  Task<IList<TennisCourts>> CourtList();
    }
}
