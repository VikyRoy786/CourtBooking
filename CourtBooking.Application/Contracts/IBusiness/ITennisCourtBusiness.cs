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
        public Task<PaginatedItems<TennisCourtGridView>> CourtList(GetListRequest getListRequest);
        public Task<TennisCourts> GetTennisCourtbyId(int Id);
        public  Task<TennisCourts> GetTennisCourtList(string Name);
        public  Task Create(TennisCourtCreatedDTO tennisCourtCreatedDTO);
        public  Task Update(TennisCourtUpdateDTO updateDTO, int Id);
        public Task Delete(int Id);
    }
}
