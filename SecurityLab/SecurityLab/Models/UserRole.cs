using System;

namespace SecurityLab.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        // За JIT пристап
        public DateTime? Expiration { get; set; }
    }
}
