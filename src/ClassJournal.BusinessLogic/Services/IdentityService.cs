using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.BusinessLogic.Services.Contracts.Config;
using ClassJournal.BusinessLogic.Services.Contracts.Models;
using ClassJournal.Dto.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ClassJournal.BusinessLogic.Services
{
    public class IdentityService : IIdentityService
    {
        //Mock
        private static readonly List<Admin> Admins;
        private static readonly Role[] Roles;

        private readonly AuthOptions _authOptions;

        //Mock
        static IdentityService()
        {
            Admins = new List<Admin>();
            Roles = new Role[]
            {
                new Role()
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Student"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Teacher"
                }
            };
        }

        public IdentityService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }
        
        public async Task<AuthResult> Register(RegisterUserDto registerUserDto)
        {
            Role role = Roles.SingleOrDefault(existingRole => existingRole.Id == registerUserDto.RoleId);

            if (role == null)
            {
                return new AuthResult()
                {
                    Success = false,
                    Error = $"Role with id '{registerUserDto.RoleId.ToString()}' doesn't exists",
                };
            }

            if (Admins.Any(admin => admin.UserName == registerUserDto.UserName))
            {
                return new AuthResult()
                {
                    Success = false,
                    Error = $"User with username '{registerUserDto.UserName}' is already exists"
                };
            }

            int newId = Admins.Any() ? Admins.Max(admin => admin.Id) + 1 : 1;
            Admin newUser = new Admin()
            {
                Id = newId,
                Password = registerUserDto.Password,
                Role = role,
                UserName = registerUserDto.UserName
            };
            Admins.Add(newUser);

            return GenerateTokenForUser(newUser);
        }

        public async Task<AuthResult> Login(LoginUserDto loginUserDto)
        {
            Admin existingAdmin = Admins.SingleOrDefault(admin => admin.UserName == loginUserDto.Username &&
                                                                   admin.Password == loginUserDto.Password);
            
            if (existingAdmin == null)
            {
                return new AuthResult()
                {
                    Success = false,
                    Error = "The username or password is incorrect"
                };
            }
            
            return GenerateTokenForUser(existingAdmin);
        }
        
        private AuthResult GenerateTokenForUser(Admin user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_authOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim("id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResult()
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
    
    //Mocks
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}