using System;

namespace PoliceDepartment.Domain.Entities
{
    public class CriminalCode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Penalty { get; set; }
        public int PrisonTime { get; set; }
        public CriminalCodeStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid CreateUserId { get; set; }
        public Guid UpdateUserId { get; set; }

        public User CreateUser { get; set; }
        public User UpdateUser { get; set; }
    }
}
