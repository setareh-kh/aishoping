using Aishopping.DTos.Requests;
using Aishopping.DTos.Responses;
using Aishopping.Models;
namespace Aishopping.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponseDto?> GetUserAsync(int id);
        Task<List<UserResponseDto>?> GetUsersAsync();
        Task<UserResponseDto> CreateUserAsync(AddUser addUser);
        Task<bool> UpdateUserAsync(int id, UpdateUser updateUser);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> LoginAsync(LoginUser loginUser);

    }
}





