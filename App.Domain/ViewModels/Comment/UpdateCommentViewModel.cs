using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.Comment
{
    public class UpdateCommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CommentRegistererFullName { get; set; }
        public int Rate { get; set; }
    }
}
