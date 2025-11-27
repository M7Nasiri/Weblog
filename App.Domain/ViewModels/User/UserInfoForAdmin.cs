using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.User
{
    public class UserInfoForAdmin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public RoleEnum Role { get; set; }
        public int WriterPostCount { get; set; }
        public int VerifierPostCount { get; set; }
    }
}
