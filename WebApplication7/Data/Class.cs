using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=raja.db.elephantsql.com;Database=mnoyzxti;Username=mnoyzxti;Password=zMykjICPmmoO7zIpOIs-YIZbqDCHOvV-");




        //postgres://mnoyzxti:zMykjICPmmoO7zIpOIs-YIZbqDCHOvV-@raja.db.elephantsql.com:5432/mnoyzxti
    }
}
