using SecurityLab.Data;
using SecurityLab.Models;
using Microsoft.EntityFrameworkCore;

namespace SecurityLab.Services
{
    public class RoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        // 1️⃣ Креирање нова улога
        public async Task<Role> CreateRoleAsync(string name, bool isOrganizationLevel)
        {
            var exists = await _context.Roles.AnyAsync(r => r.Name == name);
            if (exists) return null;

            var role = new Role
            {
                Name = name,
                IsOrganizationLevel = isOrganizationLevel
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }

        // 2️⃣ Assign улога на корисник со JIT (привремено)
        public async Task<UserRole> AssignRoleAsync(int userId, int roleId, int durationMinutes)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                Expiration = DateTime.UtcNow.AddMinutes(durationMinutes)
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
            return userRole;
        }

        // 3️⃣ Проверка дали корисник има улога и дали не е истечена
        public async Task<bool> HasRoleAsync(int userId, string roleName)
        {
            var now = DateTime.UtcNow;
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .AnyAsync(ur => ur.UserId == userId
                                && ur.Role.Name == roleName
                                && (ur.Expiration == null || ur.Expiration > now));
        }
    }
}
