using App.Domain.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Interfaces
{
    public interface ICommentRepository
    {
        public bool Add(CreateCommentViewModel model);

        List<GetCommentViewModel> GetAll();
        List<GetCommentViewModel> GetAll(List<int> postIds);

        GetCommentViewModel Get(int id);
        bool ApprovingComment(ApprovedCommentViewModel model);
        List<ShowCommentInPostDetails> CommentsByPostId(int postId);
    }
}
