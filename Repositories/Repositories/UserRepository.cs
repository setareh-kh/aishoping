using Aishopping.DTos.Requests;
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
        public async Task<User?> GetUserAsync(int id)
        {
            User? user = await _appDbContext.Users.FindAsync(id);
            return user ?? null;
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            List<User> users = await _appDbContext.Users.ToListAsync();
            return users.Count > 0 ? users : null;
        }
        public async Task<User> CreateUserAsync(AddUser addUser)
        {
            var newUser=_mapper.Map<User>(addUser);
            await _appDbContext.Users.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();
            return newUser;

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
