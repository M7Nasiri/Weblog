using App.Data.Persistence;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.ViewModels.Comment;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class CommentRepository(AppDbContext context,IMapper mapper) : ICommentRepository
    {
        public bool Add(CreateCommentViewModel model)
        {
            var comment = mapper.Map<CommentAgg>(model);
            context.Comments.Add(comment);
            return context.SaveChanges() > 0;
        }

        public bool ApprovingComment(ApprovedCommentViewModel model)
        {
           return  context.Comments.Where(c=>c.Id == model.Id).ExecuteUpdate(setters=>setters
            .SetProperty(c=>c.IsApproved,model.IsApproved)) > 0;
        }

        public List<ShowCommentInPostDetails> CommentsByPostId(int postId)
        {
            return mapper.Map<List<ShowCommentInPostDetails>>(context.Comments.Where(c => c.PostId == postId && c.IsApproved).ToList());
        }

        public GetCommentViewModel Get(int id)
        {
            return mapper.Map<GetCommentViewModel>(context.Comments.Include(c => c.Post)
                .Include(c => c.CommentRegister).Where(c=>c.Id == id).FirstOrDefault());
        }

        public List<GetCommentViewModel> GetAll(List<int> postIds)
        {
            var result = mapper.Map<List<GetCommentViewModel>>(context.Comments
                .Include(c => c.Post).Include(c => c.CommentRegister).Where(c => postIds.Contains(c.PostId)).ToList());
            return result;
        }

        public List<GetCommentViewModel> GetAll()
        {
            return mapper.Map<List<GetCommentViewModel>>(context.Comments
                .Include(c => c.Post).Include(c => c.CommentRegister).ToList());

        }
    }
}
