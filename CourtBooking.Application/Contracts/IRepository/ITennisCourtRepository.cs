using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.ViewModel;
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
        public Task<PaginatedItems<TennisCourtGridView>> CourtList(GetListRequest getListRequest);
        public  Task<TennisCourts> GetTennisCourtList(string name);
    }
}
