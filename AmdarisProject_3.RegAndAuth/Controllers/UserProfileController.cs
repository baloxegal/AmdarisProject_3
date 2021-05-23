using AmdarisProject_3.Domain.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.RegAndAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.UserName,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.Avatar
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public string GetAdminPage()
        {
            return "Web method for AdminPage";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("Customer")]
        public string GetCustomerPage()
        {
            return "Web method for CustomerPage";
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Customer")]
        [Route("AdminOrCustomer")]
        public string GetAdminOrCustomerPage()
        {
            return "Web method for Admin or Customer";
        }
    }
}

//{
//  "userName": "Baloxegal",
//  "email": "baloxegal@gmail.com",
//  "password": "Baloxegal510212",
//  "phoneNumber": "+37376706061",
//  "firstName": "Valeriu",
//  "lastName": "Balan"
//}