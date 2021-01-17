using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Infrastructure.Models
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
