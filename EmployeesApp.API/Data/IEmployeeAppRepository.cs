using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeesApp.API.Models;

namespace EmployeesApp.API.Data
{
    public interface IEmployeeAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}