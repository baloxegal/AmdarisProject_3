using Microsoft.AspNetCore.Identity;
using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Auth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Seeds
{
    public class Seed
    {
        //public static async Task SeedSentimentReactions(SocialMediaDbContext context)
        //{
        //    if (!context.SentimentReactions.Any())
        //    {
        //        var like = new SentimentReaction()
        //        {
                    
        //        };
                
        //        context.SentimentReactions.Add(like);
                
        //        await context.SaveChangesAsync();
        //    }
        //}

        public static async Task SeedRoles(SocialMediaDbContext context)
        {
            if (!context.Roles.Any())
            {
                var adminRole = new IdentityRole(Enum.GetName(RoleTypes.ADMIN));
                adminRole.NormalizedName = Enum.GetName(RoleTypes.ADMIN);

                var customerRole = new IdentityRole(Enum.GetName(RoleTypes.CUSTOMER));
                customerRole.NormalizedName = Enum.GetName(RoleTypes.CUSTOMER);

                context.Roles.Add(adminRole);
                context.Roles.Add(customerRole);

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var applicationUser_1 = new User()
                {
                    UserName = "Baloxegal",
                    Email = "baloxegal@gmail.com",
                    PhoneNumber = "+37376706061",
                    FirstName = "Valeriu",
                    LastName = "Balan"
                };

                var applicationUser_2 = new User()
                {
                    UserName = "Alex",
                    Email = "baloxegal1@gmail.com",
                    PhoneNumber = "+37378201912",
                    FirstName = "Alexei",
                    LastName = "Balan"
                };

                var applicationUser_3 = new User()
                {
                    UserName = "Egex",
                    Email = "balox@gmail.com",
                    PhoneNumber = "+37379092096",
                    FirstName = "Egor",
                    LastName = "Balan"
                };

                try
                {
                    await userManager.CreateAsync(applicationUser_1, "Baloxegal510212");
                    await userManager.AddToRoleAsync(applicationUser_1, Enum.GetName(RoleTypes.ADMIN));

                    await userManager.CreateAsync(applicationUser_2, "Baloxegal754852");
                    await userManager.AddToRoleAsync(applicationUser_2, Enum.GetName(RoleTypes.CUSTOMER));

                    await userManager.CreateAsync(applicationUser_3, "Balox510212");
                    await userManager.AddToRoleAsync(applicationUser_3, Enum.GetName(RoleTypes.CUSTOMER));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
