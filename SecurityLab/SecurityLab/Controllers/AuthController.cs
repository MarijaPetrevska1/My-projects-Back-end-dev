using Microsoft.AspNetCore.Mvc;
using SecurityLab.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request.Username, request.Email, request.Password, sendEmail: true);
        if (result == null) return BadRequest("Корисник со овој email веќе постои.");
        return Ok(new { message = "Регистрацијата е започната.", otp = ((dynamic)result).otp });
    }

    [HttpPost("confirm-registration")]
    public async Task<IActionResult> Confirm([FromBody] ConfirmRegistrationRequest request)
    {
        var success = await _authService.ConfirmRegistrationAsync(request.Email, request.Otp);
        if (!success) return BadRequest("Грешен OTP или е истечен.");
        return Ok("Регистрацијата е потврдена успешно!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request.Email, request.Password, sendEmail: true);
        if (result == null) return BadRequest("Грешен email или лозинка.");
        return Ok(result);
    }

    [HttpPost("confirm-login")]
    public async Task<IActionResult> ConfirmLogin([FromBody] ConfirmLoginRequest request)
    {
        var success = await _authService.ConfirmLoginAsync(request.Email, request.Otp);
        if (!success) return BadRequest("Грешен OTP или е истечен.");
        return Ok("Login успешен!");
    }
}

// DTOs
public class RegisterRequest { public string Username { get; set; } public string Email { get; set; } public string Password { get; set; } }
public class ConfirmRegistrationRequest { public string Email { get; set; } public string Otp { get; set; } }
public class LoginRequest { public string Email { get; set; } public string Password { get; set; } }
public class ConfirmLoginRequest { public string Email { get; set; } public string Otp { get; set; } }
