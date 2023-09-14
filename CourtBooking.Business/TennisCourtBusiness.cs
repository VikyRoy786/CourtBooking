using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Core.Exception;
using CourtBooking.Application.Repository.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public async Task<PaginatedItems<TennisCourtGridView>> CourtList(GetListRequest getListRequest)
        {
            return await _tennisCourtRepository.CourtList(getListRequest);
        }
        public async Task Create(TennisCourtCreatedDTO tennisCourtCreatedDTO)
        {
            TennisCourts tc = new TennisCourts();
            tc.Name = tennisCourtCreatedDTO.Name;
            tc.Details = tennisCourtCreatedDTO.Details;
            tc.Rate = tennisCourtCreatedDTO?.Rate;
            tc.Address = tennisCourtCreatedDTO.Address;
            tc.Availbility = true;
            tc.CreatedDate = DateTime.Now;  

            await _tennisCourtRepository.AddAsync(tc);
        }
        public async Task<TennisCourts>  GetTennisCourtbyId(int Id)
        {
            return await _tennisCourtRepository.GetByIdAsync(Id);
        }
        public async Task <TennisCourts> GetTennisCourtList(string Name )
        {
            return await _tennisCourtRepository.GetTennisCourtList(Name);
           
             
        }

        public async Task Update(TennisCourtUpdateDTO updateDTO, int Id)
        {
            var existingList = await _tennisCourtRepository.GetByIdAsync(Id);
            if (existingList == null)
            {
                throw new NotFoundException(string.Format(ConstantsBusiness.CourtNotFound), Id);
            }
            else
            {

                existingList.Name = updateDTO.Name;
                existingList.Details = updateDTO.Details;
                existingList.Rate = updateDTO?.Rate;
                existingList.Address = updateDTO.Address;
                existingList.Availbility = true;
                existingList.UpdatedDate = DateTime.Now;

                await _tennisCourtRepository.UpdateAsync(existingList);
            }
            
        }
        public async Task Delete(int Id)
        {

            var existingList = await _tennisCourtRepository.GetByIdAsync(Id);
            if (existingList == null)
            {
                throw new NotFoundException(string.Format(ConstantsBusiness.CourtNotFound), Id);
            }
            await _tennisCourtRepository.DeleteAsync(existingList);
        }
    }
}
