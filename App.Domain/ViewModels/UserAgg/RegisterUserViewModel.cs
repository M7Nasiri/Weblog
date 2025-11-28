using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.UserAgg
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public RoleEnum Role { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
