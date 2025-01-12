using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> Get(int id);
        Task<User> Post(string Email, string Password);
        Task<User> Post(User user);
        Task<User> Put(int Id, User userToUpdate);
        int Post(string pasword);
    }//
}