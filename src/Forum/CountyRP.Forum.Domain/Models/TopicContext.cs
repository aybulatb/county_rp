using Microsoft.EntityFrameworkCore;

namespace CountyRP.Forum.Domain
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
