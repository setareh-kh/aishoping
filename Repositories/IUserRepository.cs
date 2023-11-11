using Aishopping.DTos.Requests;
using Aishopping.Models;
namespace Aishopping.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(int id);
        Task<List<User>?> GetUsersAsync();
        Task<User> CreateUserAsync(AddUser addUser);
        Task<bool> UpdateUserAsync(int id, UpdateUser updateUser);
        Task<bool> DeleteUserAsync(int id);

    }
}





