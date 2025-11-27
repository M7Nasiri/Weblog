using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App.Domain.Entities
{
    public class PostAgg
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsDelete { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePath { get; set; }
        public bool IsApproved { get; set; }

        public List<CommentAgg> Comments { get; set; }

        public int WriterUserId { get; set; }
        public int? VerifierUserId { get; set; }
        public AppUser? Writer { get; set; }
        public AppUser? Verifier { get; set; }
        public Category? Cateogry { get; set; }
    }
}
