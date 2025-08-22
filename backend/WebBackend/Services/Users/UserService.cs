
using AutoMapper;
using WebBackend.Dtos.Users;
using WebBackend.Models;
using WebBackend.Repositories.Users;

namespace WebBackend.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);

        }

        public async Task<ICollection<GetUserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<ICollection<GetUserDto>>(users);
        }

        public async Task<GetDetailUserDto?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return _mapper.Map<GetDetailUserDto?>(user);
        }

        public async Task UpdateUser(int userId, UpdateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateUser(userId, user);
        }
    }
}
