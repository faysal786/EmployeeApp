using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EmployeesApp.API.Models;
using Newtonsoft.Json;

namespace EmployeesApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public void SeedUsers() {

            var seedData =  File.ReadAllText("E:/SampleProjects/EmployeesApp/EmployeesApp.API/Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(seedData);
            foreach (var user in users)
            {
               byte [] passwordHash , passwordSalt;
               CreateHashPasswordAndSalt("password",out passwordHash, out passwordSalt);
               user.PasswordHash = passwordHash;
               user.PasswordSalt = passwordSalt;
               user.Username = user.Username.ToLower();
               _dataContext.Users.Add(user);

            }
            _dataContext.SaveChanges();

        }

        private void CreateHashPasswordAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}