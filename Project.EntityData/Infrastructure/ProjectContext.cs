using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project.EntityData.Infrastructure;
using Project.EntityData.Infrastructure.EntityConfigurations;
using Project.EntityData.Models;

namespace Project.EntityData.EF
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityTypeConfiguration());
            builder.Seed();
        }
        public DbSet<User> Users { get; set; }
    }


    public class ProjectContextDesignFactory : IDesignTimeDbContextFactory<ProjectContext>
    {
        public ProjectContext CreateDbContext(string[] args)
        {
            var optionBuider = new DbContextOptionsBuilder<ProjectContext>()
            .UseSqlServer("server=127.0.0.1;user id=SA;password=Khung123;database = TestProjectDB");
            return new ProjectContext(optionBuider.Options);
        }
    }
}