using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.User
{
    public class CreateUserByAdmin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
