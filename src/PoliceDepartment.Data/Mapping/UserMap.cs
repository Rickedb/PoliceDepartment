using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliceDepartment.Domain.Entities;

namespace PoliceDepartment.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");
            builder.Property(x => x.Username)
                .HasColumnName("username")
                .HasMaxLength(80);
            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(100);

            builder.HasMany(x => x.CreatedCriminalCodes)
                .WithOne(x => x.CreateUser)
                .HasForeignKey(x => x.CreateUserId);

            builder.HasMany(x => x.UpdatedCriminalCodes)
                .WithOne(x => x.UpdateUser)
                .HasForeignKey(x => x.UpdateUserId);

            builder.ToTable("users");
        }
    }
}
