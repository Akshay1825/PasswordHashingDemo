using PasswordHashingDemo.Data;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Repositories
{
    public class Repository : IRepository
    {
        private readonly UserContext _context;

        public Repository(UserContext context)
        {
            _context = context;
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public IQueryable GetAllUsers()
        {
            return _context.Users;
        }
    }
}
