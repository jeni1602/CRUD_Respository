//using CRUD_Respository.Models;
//using Microsoft.EntityFrameworkCore;

//namespace CRUD_Respository.Data
//{
//    public class ApplicationContext:DbContext
//    {
//        public ApplicationContext(DbContextOptions<ApplicationContext> Options): base(Options)
//        {

//        }
//        public DbSet<User>Users { get; set; }  
//    }
//}


using CRUD_Respository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Respository.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
