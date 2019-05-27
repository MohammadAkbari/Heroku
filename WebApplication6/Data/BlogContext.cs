using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder.UseNpgsql("Host=raja.db.elephantsql.com;Database=mnoyzxti;Username=mnoyzxti;Password=zMykjICPmmoO7zIpOIs-YIZbqDCHOvV-");
            => optionsBuilder.UseNpgsql("Host=ec2-54-221-198-156.compute-1.amazonaws.com;" +
                "Database=d71is2fbuaa7jk;" +
                "Username=xaexrwbfailzys;" +
                "Password=673f9070d0e851307dd7121da13f8446c75d1200263f94c49fa28eb5aaf1e7c7");
    }
}
