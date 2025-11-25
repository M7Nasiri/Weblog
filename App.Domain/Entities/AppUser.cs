using App.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public bool RememberMe { get; set; }
        public bool IsDelete { get; set; }
        public IList<Post>? WrittenPosts { get; set; }
        public IList<Post>? VerifiednPosts { get; set; }
        public IList<Category>? Cateogries { get; set; }

    }
}
