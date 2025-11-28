using App.Application.Interfaces;
using App.Domain.Interfaces;
using App.Domain.ViewModels.CommentAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services
{
    public class CommentService(ICommentRepository commentRepository,IPostService postService) : ICommentService
    {
        public bool Add(CreateCommentViewModel model)
        {
            return commentRepository.Add(model);
        }

        public bool ApprovingComment(ApprovedCommentViewModel model)
        {
            return commentRepository.ApprovingComment(model);   
        }

        public List<ShowCommentInPostDetails> CommentsByPostId(int postId)
        {
            return commentRepository.CommentsByPostId(postId);
        }

        public GetCommentViewModel Get(int id)
        {
            return commentRepository.Get(id);
        }

        public List<GetCommentViewModel> GetAll(int userId)
        {
            List<int> postIds = postService.GetPostIdsByUserId(userId);
            return commentRepository.GetAll(postIds);
        }
    }
}
