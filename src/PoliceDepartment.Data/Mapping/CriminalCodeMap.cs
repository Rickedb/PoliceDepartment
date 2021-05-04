using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliceDepartment.Domain.Entities;

namespace PoliceDepartment.Data.Mapping
{
    public class CriminalCodeMap : IEntityTypeConfiguration<CriminalCode>
    {
        public void Configure(EntityTypeBuilder<CriminalCode> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(120);
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(800);

            builder.Property(x => x.Penalty).HasColumnName("penalty");
            builder.Property(x => x.PrisonTime).HasColumnName("prison_time");
            builder.Property(x => x.Status).HasColumnName("status_id");
            builder.Property(x => x.CreateDate).HasColumnName("create_date");
            builder.Property(x => x.UpdateDate).HasColumnName("update_date");
            builder.Property(x => x.CreateUserId).HasColumnName("create_user_id");
            builder.Property(x => x.UpdateUserId).HasColumnName("update_user_id");

            builder.HasOne(x => x.CreateUser)
                .WithMany(x => x.CreatedCriminalCodes)
                .HasForeignKey(x => x.CreateUserId);

            builder.HasOne(x => x.UpdateUser)
                .WithMany(x => x.UpdatedCriminalCodes)
                .HasForeignKey(x => x.UpdateUserId);

            builder.ToTable("criminal_codes");
        }
    }
}
