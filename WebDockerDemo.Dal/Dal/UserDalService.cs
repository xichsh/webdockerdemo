using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDockerDemo.Dal;
using WebDockerDemo.Model.Entities;

namespace WebDockerDemo.Dal
{
    public class UserDalService : IUserDalService
    {
        private readonly DemoDbContext _dbContext;

        public UserDalService(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(string username, string password)
        {
            User user = new User();
            user.ID = Guid.NewGuid();
            user.UserName = username;
            user.Password = password;
            await _dbContext.Users.AddAsync(user);
            _dbContext.SaveChanges();
            return user;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(p => p.UserName == username && p.Password == password);
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}