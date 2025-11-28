using App.Domain.ViewModels.CommentAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface ICommentService
    {
        bool Add(CreateCommentViewModel model);
        List<GetCommentViewModel> GetAll(int userId);
        GetCommentViewModel Get(int id);

        bool ApprovingComment(ApprovedCommentViewModel model);
        List<ShowCommentInPostDetails> CommentsByPostId(int postId);
    }
}
