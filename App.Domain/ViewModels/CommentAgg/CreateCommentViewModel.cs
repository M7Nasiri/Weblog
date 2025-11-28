using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Domain.ViewModels.CommentAgg
{
    public class CreateCommentViewModel
    {

        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        public string CommentRegistererFullName { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی است")]
        public string CommentRegistererEmail { get; set; }

        [Required(ErrorMessage = "امتیاز الزامی است")]
        [Range(1, 5, ErrorMessage = "امتیاز باید بین ۱ تا ۵ باشد")]
        public int Rate { get; set; }

        [Required(ErrorMessage = "متن کامنت الزامی است")]
        public string Text { get; set; }

        public int PostId { get; set; }
        public int? UserId { get; set; }

    }
}
