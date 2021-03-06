using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using AmdarisProject_3.Domain.Models;

namespace AmdarisProject_3.Infrastucture.Seeds
{
    public static class SeedsExtension
    {
        public static async Task SeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            
            var context = services.GetRequiredService<SocialMediaDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            context.Database.Migrate();
            
            //await Seed.SeedSentimentReactions(context);
            await Seed.SeedRoles(context);
            await Seed.SeedUsers(userManager);
        }
    }
}
