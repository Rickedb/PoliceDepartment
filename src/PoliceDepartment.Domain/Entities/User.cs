using System;
using System.Collections.Generic;

namespace PoliceDepartment.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<CriminalCode> CreatedCriminalCodes { get; set; }
        public ICollection<CriminalCode> UpdatedCriminalCodes { get; set; }
    }
}
