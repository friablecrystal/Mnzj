using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mnzj.Entity
{
    public enum EnumRole { User = 0, Admin = 100 };

    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual EnumRole Role { get; set; }
    }
}