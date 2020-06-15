using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebDockerDemo.Model.Dtos;

namespace WebDockerDemo.Web.Common
{
    public static class AppSettings
    {
        public static JwtSetting JwtSetting { get; set; }

        /// <summary>
        /// 初始化jwt配置
        /// </summary>
        /// <param name="configuration"></param>
        public static void Init(IConfiguration configuration)
        {
            JwtSetting = new JwtSetting();
            configuration.Bind("JwtSetting", JwtSetting);
        }
    }
}