using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ViewModels.Comment
{
    public class GetCommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CommentRegistererFullName { get; set; }
        public string CommentRegistererEmail { get; set; }
        public bool IsApproved { get; set; }
        public int Rate { get; set; }
        public int PostId { get; set; }
        //public PostAgg? Post { get; set; }
        //public NormalUser? CommentRegister { get; set; }
        public int? CommentRegisterId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }

    }
   
}
