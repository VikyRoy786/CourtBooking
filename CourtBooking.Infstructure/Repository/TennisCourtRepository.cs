using CourtBooking.Application.Repository.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Extension;
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
        public async Task<PaginatedItems<TennisCourtGridView>> CourtList(GetListRequest getListRequest)
        {
            var rawData = (from tennis in _context.TennisCourts
                         select new TennisCourtGridView
                         {
                             Id = tennis.Id,
                             Name = tennis.Name,
                             Details = tennis.Details,
                             Rate = tennis.Rate,
                             Address = tennis.Address,
                             Availbility = tennis.Availbility == true ? "Availabel" : "Not Available"
                            

                         }).AsQueryable();
            var filteredData = DataExtensions.OrderBy(rawData, getListRequest.SortColumn, getListRequest.Sort == "asc") 
                .Skip(getListRequest.PerPage * (getListRequest.Page - 1)).Take(getListRequest.PerPage);
            var totalItems = await rawData.LongCountAsync();
            int totalPages = (int)Math.Ceiling(totalItems/(double)getListRequest.PerPage);
            var models = new PaginatedItems<TennisCourtGridView>(getListRequest.Page, getListRequest.PerPage, totalPages, filteredData);
            return await Task.FromResult(models);
        }
        public async Task<TennisCourts> GetTennisCourtList(string name)
        {
            var rawdata = (from tennis in _context.TennisCourts
                           where tennis.Name == name    
                           select new TennisCourts
                           { Name = tennis.Name, Details = tennis.Details, Rate = tennis.Rate, Address = tennis.Address, Availbility = tennis.Availbility}).AsQueryable();
            return await rawdata.FirstOrDefaultAsync();
        }
    }
}
