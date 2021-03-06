using AmdarisProject_3.Domain.Models.Dtos;
using AmdarisProject_3.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AmdarisProject_3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AuthorizationUserController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<UserDto> GetUser()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            return _mapper.Map(user, new UserDto());

        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        [Route("admin")]
        public string GetAdminPage()
        {
            return "Web method for AdminPage";
        }

        [HttpGet]
        [Authorize(Roles = "CUSTOMER")]
        [Route("customer")]
        public string GetCustomerPage()
        {
            return "Web method for CustomerPage";
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Customer")]
        [Route("all")]
        public string GetAdminOrCustomerPage()
        {
            return "Web method for Admin or Customer";
        }
    }
}