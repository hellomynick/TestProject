using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.EntityData.Models;

namespace Project.EntityData.Infrastructure.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => new {x.Id});
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x=>x.Age).IsRequired();
            builder.Property(x=>x.DoB);
            builder.Property(x=>x.Sex);
            builder.Property(x=>x.Address);
        }
    }
}