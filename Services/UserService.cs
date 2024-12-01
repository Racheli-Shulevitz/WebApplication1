using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Services
{
    public class UserService : IUserService
    {
        string filePath = "M:\\web api\\MyProject\\WebApplication1\\WebApplication1\\Users.txt";

        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //password
        public int Post(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }

        //login
        public Task<User> Post(string Email, string Password)
        {
            return _userRepository.Post(Email, Password);
        }

        // POST api/<UserController> add user
   
        public Task<User> Post(User user)
        {
            if (Post(user.Password) > 2)
                return _userRepository.Post(user);
            else
                return null;

        }

        // PUT api/<UserController>/5

        public Task<User> Put(int Id, User userToUpdate)
        {
            ///or change to user return
            if (Post(userToUpdate.Password) > 2)
                return _userRepository.Post(userToUpdate);
            else
                return null;
            //int code = Post(userToUpdate.Password);
            //if (code < 3)
            //    throw new Exception("Password is week, Please enter a different password");
            //_userRepository.Put(Id, userToUpdate);
        }

        // GET 
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }
    }
}
