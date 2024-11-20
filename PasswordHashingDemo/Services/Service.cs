using AutoMapper;
using PasswordHashingDemo.DTOs;
using PasswordHashingDemo.Exceptions;
using PasswordHashingDemo.Models;
using PasswordHashingDemo.Repositories;

namespace PasswordHashingDemo.Services
{
    public class Service:IService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public Service(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public string RegisterUser(UserDto userDto)
        {
            if (_repository.GetUserByUsername(userDto.UserName) != null)
            {
                return "Username already exists";
            }
            var user = _mapper.Map<User>(userDto);
            _repository.AddUser(user);
            return "User registered successfully.";
        }

        public UserDto LoginUser(LoginDto loginDto)
        {
            var user = _repository.GetUserByUsername(loginDto.UserName);
            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            throw new UserNotFoundException("User Not Found");
        }
    }
}
