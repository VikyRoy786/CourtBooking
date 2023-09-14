using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Application.Contracts.IBusiness
{
    public interface IUserBusiness
    {
        public Task<bool> IsuniqueUser(string userName);

        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        public Task<LocalUsers> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
