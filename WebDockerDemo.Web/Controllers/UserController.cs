using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDockerDemo.Bll;
using WebDockerDemo.Model;
using WebDockerDemo.Model.Dtos;
using WebDockerDemo.Model.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDockerDemo.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserBllService _userBllService;

        public UserController(IUserBllService userBllService)
        {
            _userBllService = userBllService;
        }

        /// <summary>
        /// 所有用户
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<BaseDto<IEnumerable<User>>>> Get()
        {
            var users = await _userBllService.GetUserAsync();
            BaseDto<IEnumerable<User>> dto = new BaseDto<IEnumerable<User>>(Model.Dtos.StatusCode.Success, "", users);
            return Ok(dto);
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        [Route("me")]
        [HttpGet]
        public async Task<ActionResult<BaseDto<User>>> UserInfo()
        {
            string id = User.FindFirst("id")?.Value;
            var user = await _userBllService.GetUserAsync(Guid.Parse(id));
            BaseDto<User> dto = new BaseDto<User>(Model.Dtos.StatusCode.Success, "", user);
            return Ok(dto);
        }

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<BaseDto<User>>> Get(Guid id)
        {
            var user = await _userBllService.GetUserAsync(id);
            BaseDto<User> dto = new BaseDto<User>(Model.Dtos.StatusCode.Success, "", user);
            return Ok(dto);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="loginParameter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseDto<User>>> Add(LoginParameter loginParameter)
        {
            var user = await _userBllService.AddUserAsync(loginParameter.UserName, loginParameter.Password);
            BaseDto<User> dto = new BaseDto<User>(Model.Dtos.StatusCode.Success, "", user);
            return Ok(dto);
        }
    }
}