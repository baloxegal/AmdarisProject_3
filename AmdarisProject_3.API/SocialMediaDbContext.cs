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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            //modelBuilder.Entity<Event>().ToTable("Events");

            modelBuilder.Entity<Event>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Events)
                .UsingEntity(x => x.ToTable("EventsAuthors"));

            modelBuilder.Entity<Event>()
               .HasMany(x => x.Participant)
               .WithMany(x => x.Events)
               .UsingEntity(x => x.ToTable("EventsParticipants"));

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.Sender)
                .OnDelete(DeleteBehavior.Restrict);      
        }
    }
}
