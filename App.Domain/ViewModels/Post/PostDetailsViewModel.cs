using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.Post
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePath { get; set; }
        //public int WriterUserId { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string WriterUserName { get; set; }
        public bool IsApproved { get; set; }
        public List<CommentAgg> Comments { get; set; }
    }
}
