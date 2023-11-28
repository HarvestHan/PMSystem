using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PMSystem.Shared.Models
{
    public class ChangeUsersPwdModel
    {
        [Required(ErrorMessage = "输入的账号不能为空！")]
        public string Code { get; set; }

        [Required(ErrorMessage = "新输入的密码不能为空！")]
        [StringLength(255, ErrorMessage = "新密码的长度至少为6位", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
