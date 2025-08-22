using WebBackend.Models;

namespace WebBackend.Repositories.Users
{
    public interface IUserRepository
    {
        Task CreatUser(User user);
        Task<User?> GetUserById(int id);
        Task<ICollection<User>> GetAllUsers();
        Task UpdateUser(int userId, User user);
        Task DeleteUser(int userId);
    }
}