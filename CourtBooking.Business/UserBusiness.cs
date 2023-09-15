using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourtBooking.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        
        
        public UserBusiness(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            
            
        }

        public async Task<bool> IsuniqueUser(string userName)
        {
            return await _userRepository.IsuniqueUser(userName);
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var users = await _userRepository.ExistingUser(loginRequestDTO);
            if(users == null) 
            {
                return new LoginResponseDTO
                {
                    Users = users,
                    Token = ""
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.UserData, users.Id.ToString()),
                    new Claim(ClaimTypes.Name, users.UserName.ToString()),
                    new Claim(ClaimTypes.Role, users.Role)
               }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO();
            {
                loginResponseDTO.Users = users;
                loginResponseDTO.Token = tokenHandler.WriteToken(token); 


            }
            return loginResponseDTO;

        }

        public async Task<LocalUsers> AdminRegistration(RegistrationRequestDTO registrationRequestDTO)
        {

            LocalUsers users = new LocalUsers()
            {
                UserName = registrationRequestDTO.UserName,
                Name = registrationRequestDTO.Name,
                Password = registrationRequestDTO.Password,
                Role = "Admin",

            };
           await _userRepository.AddAsync(users);
            users.Password = ""; // Not show password
            return users;
        }
        public async Task<LocalUsers> UserRegistration(RegistrationRequestDTO registrationRequestDTO)
        {

            LocalUsers users = new LocalUsers()
            {
                UserName = registrationRequestDTO.UserName,
                Name = registrationRequestDTO.Name,
                Password = registrationRequestDTO.Password,
                Role = "user",

            };
            await _userRepository.AddAsync(users);
            users.Password = ""; // Not show password
            return users;
        }
    }
}
