using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject_3.API
{
    public class SocialMediaDbContext : IdentityDbContext<User>
    {
        public SocialMediaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> AppUsers { get; set; }
        public DbSet<Reaction> AbstractReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<SentimentReaction> SentimentReactions { get; set; }
        public DbSet<Post> AbstractPosts { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Relationship> RelationShips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.EventsAuthor)
                .UsingEntity(x => x.ToTable("EventsAuthors"));

            modelBuilder.Entity<Event>()
               .HasMany(x => x.Participants)
               .WithMany(x => x.EventsParticipants)
               .UsingEntity(x => x.ToTable("EventsParticipants"));

            modelBuilder.Entity<User>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.Sender)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasAlternateKey(n => n.UserName);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
