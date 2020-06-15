using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDockerDemo.Model.Entities;

namespace WebDockerDemo.Bll
{
    public interface IUserBllService
    {
        Task<IEnumerable<User>> GetUserAsync();

        Task<User> GetUserAsync(Guid id);

        Task<User> GetUserAsync(string username, string password);

        Task<User> AddUserAsync(string username, string password);
    }
}