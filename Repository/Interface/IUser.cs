using CRUD_Respository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_Respository.Repository.Interface
{
    public interface IUser
    {

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
