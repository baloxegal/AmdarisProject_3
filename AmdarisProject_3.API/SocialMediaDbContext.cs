using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject_3.API
{
    public class SocialMediaDbContext : IdentityDbContext<ApplicationUser>
    {
        public SocialMediaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<AbstractReaction> AbstractReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<SentimentReaction> SentimentReactions { get; set; }
        public DbSet<AbstractPost> AbstractPosts { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
    }
}
