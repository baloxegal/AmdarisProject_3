﻿using AmdarisProject_3.RegAndAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        //private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private readonly ILogger<ApplicationUserController> _logger;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, /*SignInManager<ApplicationUser> signInManager,*/
                                         IOptions<ApplicationSettings> appSettings, ILogger<ApplicationUserController> logger)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            model.Role = "Admin";

            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);
                return Ok(result);
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
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
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
