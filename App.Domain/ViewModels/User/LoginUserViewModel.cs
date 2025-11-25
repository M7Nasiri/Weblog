using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.User
{
    public class LoginUserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
