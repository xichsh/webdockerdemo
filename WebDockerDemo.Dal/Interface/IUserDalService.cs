using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDockerDemo.Model.Entities;

namespace WebDockerDemo.Dal
{
    public interface IUserDalService
    {
        Task<IEnumerable<User>> GetUserAsync();

        Task<User> GetUserAsync(Guid id);

        Task<User> GetUserAsync(string username, string password);

        Task<User> AddUserAsync(string username, string password);
    }
}