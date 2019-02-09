using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeesApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.API.Data
{
    public class EmployeeAppRepository : IEmployeeAppRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeAppRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<Photo> GetPhoto(int id)
        {            
            var photo = await _dataContext.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            // include mean to add photos as well
            var user = await _dataContext.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           // include mean to add photos as well
            var users = await _dataContext.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}