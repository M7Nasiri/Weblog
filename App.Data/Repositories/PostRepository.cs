using App.Data.Persistence;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.ViewModels.Post;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class PostRepository(AppDbContext context,IMapper mapper) : IPostRepository
    {
        public bool Create(CreatePostViewModel model)
        {
            var post = mapper.Map<Post>(model);
            context.Posts.Add(post);
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id,int userId, DeletePostViewModel model)
        {
            if (model.WriterUserId != userId)
                return false;
            return context.Posts.Where(p => p.Id == id).ExecuteUpdate(setters=>setters.SetProperty((p=>p.IsDelete),true)) > 0;
        }

        public GetPostViewModel Get(int id)
        {
            var post = context.Posts.Include(p => p.Cateogry).Include(p => p.Writer).Include(p => p.Verifier).FirstOrDefault(p => p.Id == id);
            return mapper.Map<GetPostViewModel>(post);
        }

        public List<GetPostViewModel> GetAll()
        {
            var posts = context.Posts.Include(p=>p.Writer).Include(p=>p.Cateogry).Include(p=>p.Verifier).OrderByDescending(p=>p.CreatedAt).ToList();
            return mapper.Map<List<GetPostViewModel>>(posts);
        }

        public List<GetPostViewModel> GetAll(int userId)
        {
            var posts = context.Posts.Where(p => p.WriterUserId == userId).Include(p => p.Cateogry)
                .Include(p => p.Writer).Include(p => p.Verifier).OrderByDescending(p=>p.CreatedAt)
               .ToList();
            return mapper.Map<List<GetPostViewModel>>(posts);
        }

        public bool Update(int id,int userId, UpdatePostViewModel model)
        {
            if (model.WriterUserId != userId)
                return false;
            return context.Posts.Where(c => c.Id == id).ExecuteUpdate(setters => setters.SetProperty((p => p.Title), model.Title)
            .SetProperty((p => p.Description), model.Description)
            .SetProperty((p => p.Summary), model.Summary)
            .SetProperty((p => p.CategoryId), model.CategoryId)
            .SetProperty((p => p.ImagePath), model.ImagePath)) > 0;
        }
        public string GetSummary(string description)
        {
            return description.Length > 200 ? description.Substring(0, 200) : description;
        }

        public bool UpdateViewCount(int id,int count)
        {
            return context.Posts.Where(p => p.Id == id).ExecuteUpdate(setters => setters.SetProperty((p => p.ViewCount), count)) > 0;
        }

        public List<GetPostViewModel> GetBySearchAndSort(int userId,SearchAndSortViewModel sSModel)
        {
            IQueryable<Post> iQres = context.Posts.Where(p => p.WriterUserId == userId).Include(p => p.Cateogry)
                .Include(p => p.Writer).Include(p => p.Verifier).OrderByDescending(p => p.CreatedAt); 
            if (!string.IsNullOrEmpty(sSModel.Title))
            {
                iQres = iQres.Where(p => p.Title.Contains(sSModel.Title));
            }
            if (sSModel.SortType != 0)
            {
                iQres = iQres.Where(p=>p.CategoryId ==sSModel.SortType);
            }
            return mapper.Map<List<GetPostViewModel>>(iQres);

        }

        public List<GetPostViewModel> GetAll(bool isApproved)
        {
            var posts = context.Posts.Where(p => p.IsApproved == isApproved ).Include(p => p.Cateogry)
               .Include(p => p.Writer).Include(p => p.Verifier).OrderByDescending(p => p.CreatedAt)
              .ToList();
            return mapper.Map<List<GetPostViewModel>>(posts);
        }

        public bool Approved(int id, bool isApproved,int userId)
        {

            return context.Posts.Where(p => p.Id == id).ExecuteUpdate(setters => setters
            .SetProperty((p => p.IsApproved), isApproved)
            .SetProperty((p => p.VerifierUserId), userId)) > 0;

        }
    }
}
