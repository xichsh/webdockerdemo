using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDockerDemo.Dal;
using WebDockerDemo.Model.Entities;

namespace WebDockerDemo.Bll
{
    public class UserBllService : IUserBllService
    {
        private readonly IUserDalService _userDalService;

        public UserBllService(IUserDalService userDalService)
        {
            _userDalService = userDalService;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _userDalService.GetUserAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _userDalService.GetUserAsync(id);
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await _userDalService.GetUserAsync(username, password);
        }

        public async Task<User> AddUserAsync(string username, string password)
        {
            return await _userDalService.AddUserAsync(username, password);
        }
    }
}