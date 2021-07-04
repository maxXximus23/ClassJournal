using System.Linq;
using System.Security.Claims;
using ClassJournal.BusinessLogic.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace ClassJournal.BusinessLogic.Services
{
    public class UserInfoService : IUserInfoService
    {
        public string Username { get; }
        public string Role { get; }
        public int Id { get; }
        public bool IsLoggedIn { get; }

        public UserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null)
            {
                return;
            }

            HttpContext httpContext = httpContextAccessor.HttpContext;
            
            if (!httpContext.User.Claims.Any())
            {
                return;
            }

            Username = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Role = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            Id = int.Parse(httpContext.User.Claims.Single(claim => claim.Type == "id").Value);
            IsLoggedIn = true;
        }
    }
}