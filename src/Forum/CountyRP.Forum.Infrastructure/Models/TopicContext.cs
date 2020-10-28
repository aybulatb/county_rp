using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Infrastructure.Models
{
    public class TopicContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }

        public TopicContext(DbContextOptions<TopicContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
