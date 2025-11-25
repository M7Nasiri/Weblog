using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.User
{
    public class UpdatePasswordUserViewModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
