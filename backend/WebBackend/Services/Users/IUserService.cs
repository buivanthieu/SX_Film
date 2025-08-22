using WebBackend.Dtos.Users;
using WebBackend.Models;

namespace WebBackend.Services.Users
{
    public interface IUserService
    {
        Task<GetDetailUserDto?> GetUserById(int id);
        Task<ICollection<GetUserDto>> GetAllUsers();
        Task UpdateUser(int userId, UpdateUserDto user);
        Task DeleteUser(int userId);
    }
}