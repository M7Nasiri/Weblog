using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.Post
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string Description { get; set; }
        public int CategoryId{ get; set; }
        public string? ImagePath { get; set; }
        public int WriterUserId { get; set; }
        public bool IsApproved { get; set; }
    }
}
