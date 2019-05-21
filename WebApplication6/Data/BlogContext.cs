using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder.UseNpgsql("Host=raja.db.elephantsql.com;Database=mnoyzxti;Username=mnoyzxti;Password=zMykjICPmmoO7zIpOIs-YIZbqDCHOvV-");
            => optionsBuilder.UseNpgsql("Host=ec2-54-235-167-210.compute-1.amazonaws.com;Database=d5b4bh7mutujv8;Username=nrerdmgqtzusom;Password=9c98b93835d17c8c7258aeb27c4224a80ce8abec1f7287c77a308624ba4c6c2f");



        //postgres://nrerdmgqtzusom:9c98b93835d17c8c7258aeb27c4224a80ce8abec1f7287c77a308624ba4c6c2f@ec2-54-235-167-210.compute-1.amazonaws.com:5432/d5b4bh7mutujv8


        //postgres://mnoyzxti:zMykjICPmmoO7zIpOIs-YIZbqDCHOvV-@raja.db.elephantsql.com:5432/mnoyzxti
    }
}
