using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Infstructure.Repository
{
    public class UserRepository : BaseRepository<LocalUsers>, IUserRepository
    {
        
        public UserRepository(BookingDbContext dbContext, ILogger<LocalUsers> logger) : base(dbContext, logger)
        {
            
        }

       public async Task<bool> IsuniqueUser(string userName)
        {
            var user = _context.LocalUsers.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.LocalUsers.FirstOrDefault(u=>u.UserName.ToLower() == loginRequestDTO.UserName.ToLower () && u.Password == loginRequestDTO.Password);
            if (user == null)
            {
                throw new Exception("User Name Or email Not Found");
            }
            return new LoginResponseDTO { };
        }

        
    }
}
