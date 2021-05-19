using AmdarisProject_3.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain
{
    class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options) : base(options) 
        {          
            
        }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<SentimentReaction> SentimentReactions { get; set; }        
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
    }
}
