using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDockerDemo.Bll;
using WebDockerDemo.Model.Dtos;
using WebDockerDemo.Web.Common;

namespace WebDockerDemo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseController
    {
        private readonly IUserBllService _userBllService;

        public TokenController(IUserBllService userBllService)
        {
            _userBllService = userBllService;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="loginParameter"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost(Name = nameof(Login))]
        public async Task<ActionResult<BaseDto<object>>> Login([FromBody] LoginParameter loginParameter)
        {
            var user = await _userBllService.GetUserAsync(loginParameter.UserName, loginParameter.Password);
            if (user != null)
            {
                var token = AppHelper.Instance.GetToken(user);
                BaseDto<object> dto = new BaseDto<object>(Model.Dtos.StatusCode.Success, "", new { token });
                return Ok(dto);
            }
            return Ok(new BaseDto<object>(Model.Dtos.StatusCode.Error, "", null));
        }
    }
}