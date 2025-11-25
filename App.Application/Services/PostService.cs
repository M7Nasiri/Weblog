using App.Application.Interfaces;
using App.Domain.Interfaces;
using App.Domain.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services
{
    public class PostService(IPostRepository postRepository,IFileService fileService,ICategoryService categoryService) : IPostService
    {
        public bool Create(CreatePostViewModel model)
        {
            model.Summary = postRepository.GetSummary(model.Description);
            model.CreatedAt = DateTime.Now;
            return postRepository.Create(model);
        }

        public bool Delete(int id, int userId, DeletePostViewModel model)
        {
            
            if(model.ImagePath != null)
            {
                fileService.Delete(model.ImagePath);
            }
            return postRepository.Delete(id,userId, model);
        }

        public GetPostViewModel Get(int id)
        {
            return postRepository.Get(id);
        }

        public List<GetPostViewModel> GetAll()
        {
            return postRepository.GetAll();
        }

        public List<GetPostViewModel> GetAll(int userId)
        {
            return postRepository.GetAll(userId);
        }

        public List<GetPostViewModel> GetBySearchAndSort(int userId, SearchAndSortViewModel sSModel)
        {
            return postRepository.GetBySearchAndSort(userId,sSModel);
        }

        public bool Update(int id, int userId,UpdatePostViewModel model)
        {
            var post = postRepository.Get(id);
            if (post.ImagePath != model.ImagePath && model.ImagePath != null)
            {
                fileService.Delete(post.ImagePath);
            }
            if (model.ImagePath == null)
                model.ImagePath = post.ImagePath;
            model.Summary = model.Description.Length >= 200 ?model.Description.Substring(0, 200):model.Description;
            return postRepository.Update(id,userId,model);
        }

        public bool UpdateViewCount(int id, int count)
        {
            return postRepository.UpdateViewCount(id, count);
        }
    }
}
