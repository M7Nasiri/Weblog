using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IList<Post>? Posts { get; set; }
        public bool IsDelete { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }

    }
}
