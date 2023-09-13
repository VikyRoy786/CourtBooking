using CourtBooking.Application.Repository.IRepository;
using CourtBooking.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Infstructure.Repository
{
    public class TennisCourtRepository : BaseRepository<TennisCourts>, ITennisCourtRepository
    {
        public TennisCourtRepository(BookingDbContext dbContext, ILogger<TennisCourts> logger): base(dbContext, logger) 
        {
                
        }
        public async Task<IList<TennisCourts>> CourtList()
        {
            var lists = await _context.TennisCourts.ToListAsync();
                return await Task.FromResult(lists);
        }
    }
}
