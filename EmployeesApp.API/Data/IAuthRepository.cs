using System.Threading.Tasks;
using EmployeesApp.API.Models;

namespace EmployeesApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(string username,  string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}