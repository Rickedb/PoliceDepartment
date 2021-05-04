using Microsoft.EntityFrameworkCore;
using PoliceDepartment.Data.Mapping;
using PoliceDepartment.Domain.Entities;

namespace PoliceDepartment.Data.Contexts
{
    public class PoliceDepartmentContext : DbContext
    {
        public DbSet<CriminalCode> CriminalCodes { get; set; }
        public DbSet<User> Users { get; set; }

        public PoliceDepartmentContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CriminalCodeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
