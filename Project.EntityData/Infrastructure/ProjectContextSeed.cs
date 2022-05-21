using Microsoft.EntityFrameworkCore;
using Project.EntityData.Models;

namespace Project.EntityData.Infrastructure
{
    public static class ProjectContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "Tran Van Minh Vu",
                    Age = 22,
                    DoB = new DateTime(2000,03,09),
                    Sex = "Female",
                    Address = "04 Doan Uan, Khue My, Ngu Hanh Son, Da Nang, Viet Nam"
                }
            );
        }
    }
}