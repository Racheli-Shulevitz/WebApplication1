using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User Get(int id);
        Task<User> Post(string Email, string Password);
        Task<User> Post(User user);
        Task<User> Put(int Id, User userToUpdate);
    }
}