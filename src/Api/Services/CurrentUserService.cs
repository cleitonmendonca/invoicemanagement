using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }
        
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
