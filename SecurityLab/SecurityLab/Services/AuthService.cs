using Microsoft.EntityFrameworkCore;
using SecurityLab.Data;
using SecurityLab.Models;
using System.Security.Cryptography;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace SecurityLab.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        // Конструктор
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        // --- 1️⃣ Хеширање на лозинка ---
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // --- 2️⃣ Генератор на OTP ---
        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // 6-цифрен код
        }

        // --- 3️⃣ Испраќање OTP на мејл ---
        private void SendOtpEmail(string toEmail, string otp)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SecurityLab", "your_email@gmail.com")); // промени со твојот мејл
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "Вашиот OTP код";
            message.Body = new TextPart("plain") { Text = $"Вашиот OTP код е: {otp}" };

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); // Gmail SMTP
            client.Authenticate("your_email@gmail.com", "your_email_password"); // твој credentials или App Password
            client.Send(message);
            client.Disconnect(true);
        }

        // --- 4️⃣ Регистрација со OTP ---
        public async Task<User> RegisterAsync(string username, string email, string password, bool sendEmail = false)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                return null;

            var otp = GenerateOtp();

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                PendingOtp = otp,
                OtpExpiration = DateTime.UtcNow.AddMinutes(5)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (sendEmail)
                SendOtpEmail(email, otp); // Испрати OTP на мејл

            // За тестирање може да го врати OTP
            return user;
        }

        // --- 5️⃣ Потврда на регистрација (OTP) ---
        public async Task<bool> ConfirmRegistrationAsync(string email, string otp)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.PendingOtp != otp || user.OtpExpiration < DateTime.UtcNow)
                return false;

            user.PendingOtp = null;
            user.OtpExpiration = null;

            await _context.SaveChangesAsync();
            return true;
        }

        // --- 6️⃣ Login со OTP ---
        public async Task<bool> LoginAsync(string email, string password, bool sendEmail = false)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.PasswordHash != HashPassword(password))
                return false;

            var otp = GenerateOtp();
            user.PendingOtp = otp;
            user.OtpExpiration = DateTime.UtcNow.AddMinutes(5);
            await _context.SaveChangesAsync();

            if (sendEmail)
                SendOtpEmail(email, otp); // Испрати OTP на мејл

            return true;
        }

        // --- 7️⃣ Потврда на login OTP ---
        public async Task<bool> ConfirmLoginAsync(string email, string otp)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.PendingOtp != otp || user.OtpExpiration < DateTime.UtcNow)
                return false;

            user.PendingOtp = null;
            user.OtpExpiration = null;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
