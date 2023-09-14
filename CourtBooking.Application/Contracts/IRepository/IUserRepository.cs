using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.Contracts.IRepository
{
    public interface IUserRepository : IAsyncRepository<LocalUsers>
    {
        public Task<bool> IsuniqueUser(string userName);

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        
    }
}
