using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.CommentAgg
{
    public class ApprovedCommentViewModel
    {
        public int Id { get; set; }
        public string CommentRegistererFullName { get; set; }
        public string CommentRegistererEmail { get; set; }
        public bool IsApproved { get; set; }
        public int Rate { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
    }
}
