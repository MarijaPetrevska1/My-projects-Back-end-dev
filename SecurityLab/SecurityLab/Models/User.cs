using System;
using System.Collections.Generic;

namespace SecurityLab.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        // Лозинка ќе биде ХЕШИРАНА
        public string PasswordHash { get; set; }

        // 2FA код
        public string PendingOtp { get; set; }
        public DateTime? OtpExpiration { get; set; }

        // Улоги
        public List<UserRole> Roles { get; set; } = new();
    }
}

