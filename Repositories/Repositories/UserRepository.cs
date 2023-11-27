using Aishopping.DTos.Requests;
using Aishopping.DTos.Responses;
using Aishopping.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aishopping.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private IMapper _mapper;
        public UserRepository(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper=mapper;
        }
        public async Task<UserResponseDto?> GetUserAsync(int id)
        {
            User? user = await _appDbContext.Users.FindAsync(id);
            var Response=_mapper.Map<UserResponseDto>(user);
            return Response?? null;
        }

        public async Task<List<UserResponseDto>?> GetUsersAsync()
        {
            List<User> users = await _appDbContext.Users.ToListAsync();
            var Response=users.Select(u=>_mapper.Map<UserResponseDto>(u)).ToList();
            return Response.Count > 0 ? Response : null;
        }
        public async Task<UserResponseDto> CreateUserAsync(AddUser addUser)
        {
            var newUser=_mapper.Map<User>(addUser);
            await _appDbContext.Users.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();
            var Response=_mapper.Map<UserResponseDto>(newUser);
            return Response;

        }
        public async Task<bool> UpdateUserAsync(int id, UpdateUser updateUser)
        {
            var userToBeUpdated = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (userToBeUpdated != null)
            {
                _mapper.Map(updateUser,userToBeUpdated);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            User? user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _appDbContext.Remove(user);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> LoginAsync(LoginUser loginUser)
        {
            User? user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.FirstName ==loginUser.FirstName  && u.Password==loginUser.Password );
            return user!=null;
        }
        
    }
}
