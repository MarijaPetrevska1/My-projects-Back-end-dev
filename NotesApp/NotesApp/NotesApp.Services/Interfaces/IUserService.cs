using NotesApp.Dtos.UserDtos;

namespace NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginUserDto loginUserDto);
    }
}

