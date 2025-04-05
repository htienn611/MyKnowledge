namespace WebApi.repository
{
    using WebApi.data;
    using WebApi.model;
    using Microsoft.EntityFrameworkCore;

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User?> GetUserByEmail(string email);
    }
    public class UserRepository(WebApiDbContext context) : IUserRepository
    {
        private readonly WebApiDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User> CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}