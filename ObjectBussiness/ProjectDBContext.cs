using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ObjectBussiness
{
    public class ProjectDBContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configurationRoot = builder.Build();
            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("MyConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}