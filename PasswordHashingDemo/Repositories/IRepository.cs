using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Repositories
{
    public interface IRepository
    {
        public User GetUserByUsername(string username);

        public void AddUser(User user);

        public IQueryable GetAllUsers();
    }
}
