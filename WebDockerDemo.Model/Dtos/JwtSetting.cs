using System;
using System.Collections.Generic;
using System.Text;

namespace WebDockerDemo.Model.Dtos
{
    public class JwtSetting
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireSeconds { get; set; }
    }
}