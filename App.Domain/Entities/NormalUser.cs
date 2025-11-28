using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class NormalUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
