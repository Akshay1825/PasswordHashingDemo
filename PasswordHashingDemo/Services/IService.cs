using PasswordHashingDemo.DTOs;

namespace PasswordHashingDemo.Services
{
    public interface IService
    {
        public string RegisterUser(UserDto userDto);
        public UserDto LoginUser(LoginDto loginDto);
    }
}
