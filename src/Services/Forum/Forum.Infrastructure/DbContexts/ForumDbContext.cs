using CountyRP.Services.Forum.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.Services.Forum.Infrastructure.DbContexts
{
    public class ForumDbContext : DbContext
    {
        public DbSet<UserDao> Users { get; set; }
        public DbSet<ForumDao> Forums { get; set; }
        public DbSet<ModeratorDao> Moderators { get; set; }
        public DbSet<PostDao> Posts { get; set; }
        public DbSet<ReputationDao> Reputations { get; set; }
        public DbSet<TopicDao> Topics { get; set; }
        public DbSet<WarningDao> Warnings { get; set; }

        public ForumDbContext(
            DbContextOptions<ForumDbContext> options
        )
            : base(options)
        {
        }
    }
}
