using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="输入的新密码不能为空！")]
        [StringLength(255, ErrorMessage = "新密码的长度至少为6位", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "重复输入的密码不能为空！")]
        [Compare(nameof(Password),ErrorMessage ="两次输入的密码不一致，请重新输入！")]
        public string ConfirmPassword { get; set; }
    }
}
