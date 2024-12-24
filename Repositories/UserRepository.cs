using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        string filePath = "M:\\web api\\MyProject\\WebApplication1\\WebApplication1\\Users.txt";
        OurStoreContext _context;
        public UserRepository(OurStoreContext context)
        {
            _context = context;
        }
        //login
        public async Task<User> Post(string Email, string Password)
        {
           User u = await _context.Users.FirstOrDefaultAsync(user=> user.Email == Email && user.Password == Password);
            await _context.SaveChangesAsync();
            return u;

        }

        // POST api/<UserController> add user

        public async Task<User> Post(User user)
        {
           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();

            return user;

        }

        // PUT 

        public async Task<User> Put(int Id, User userToUpdate)
        {
            userToUpdate.Id = Id;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();

            return userToUpdate;
        }

        //// GET 
        //public User Get(int id)
        //{
        //    using (StreamReader reader = System.IO.File.OpenText(filePath))
        //    {
        //        string? currentUserInFile;
        //        while ((currentUserInFile = reader.ReadLine()) != null)
        //        {
        //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
        //            if (user.Id == id)
        //                return user;
        //        }
        //    }
        //    return null;
        //}

        //get by id
        public async Task<User> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}
