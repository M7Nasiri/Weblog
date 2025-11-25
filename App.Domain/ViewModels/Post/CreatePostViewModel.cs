using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePath { get; set; }
        public int WriterUserId { get; set; }
    }
}
