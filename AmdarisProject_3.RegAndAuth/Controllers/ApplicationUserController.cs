using AmdarisProject_3.Domain.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.RegAndAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly AuthSettings _appSettings;
        private readonly ILogger<ApplicationUserController> _logger;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                         IOptions<AuthSettings> appSettings, ILogger<ApplicationUserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            model.Role = RoleTypes.CUSTOMER;

            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, Enum.GetName(model.Role));
                    await _signInManager.SignInAsync(applicationUser, true);
                    return Ok(new { result, message = "register successful" });
                }
                else
                    return BadRequest(new { message = "Username have been always exist or data is not valid" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),
                                                                SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                await _signInManager.SignInAsync(user, model.RememberMe);

                return Ok(new { token, message = "Login successful" });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { message = "Logout successful" });            
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
