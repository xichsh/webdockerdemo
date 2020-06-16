using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebDockerDemo.Model.Entities
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Column(TypeName = "VARCHAR(16)")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Column(TypeName = "VARCHAR(16)")]
        public string Password { get; set; }
    }
}