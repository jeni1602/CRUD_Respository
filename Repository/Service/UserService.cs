using CRUD_Respository.Data;
using CRUD_Respository.Models;
using CRUD_Respository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Respository.Repository.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationContext context;

        public UserService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.FromResult(context.Users.ToList());
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.FromResult(context.Users.FirstOrDefault(u => u.UserId == id));
        }

        public async Task AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Gender = user.Gender;
                existingUser.Email = user.Email;
                existingUser.Pincode = user.Pincode;
                existingUser.IsActive = user.IsActive;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
