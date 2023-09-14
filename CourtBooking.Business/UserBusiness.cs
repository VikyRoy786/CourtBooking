using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtBooking.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsuniqueUser(string userName)
        {
            return await _userRepository.IsuniqueUser(userName);
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalUsers> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUsers users = new LocalUsers()
            {
                UserName = registrationRequestDTO.UserName,
                Name = registrationRequestDTO.Name,
                Password = registrationRequestDTO.Password,
                Role = registrationRequestDTO.Role,

            };
           await _userRepository.AddAsync(users);
            users.Password = ""; // Not show password
            return users;
        }
    }
}
