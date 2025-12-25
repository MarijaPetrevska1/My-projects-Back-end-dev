using Microsoft.AspNetCore.Mvc;
using SecurityLab.Services;

namespace SecurityLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        // -----------------------------
        // 1️⃣ Креирање улога
        // -----------------------------
        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var role = await _roleService.CreateRoleAsync(request.Name, request.IsOrganizationLevel);
            if (role == null) return BadRequest("Улога веќе постои.");
            return Ok(role);
        }

        // -----------------------------
        // 2️⃣ Assign улога на корисник
        // -----------------------------
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest request)
        {
            var userRole = await _roleService.AssignRoleAsync(request.UserId, request.RoleId, request.DurationMinutes);
            return Ok(userRole);
        }

        // -----------------------------
        // Request DTOs
        // -----------------------------
        public class CreateRoleRequest
        {
            public string Name { get; set; }
            public bool IsOrganizationLevel { get; set; }
        }

        public class AssignRoleRequest
        {
            public int UserId { get; set; }
            public int RoleId { get; set; }
            public int DurationMinutes { get; set; } // JIT привремено
        }
    }
}
