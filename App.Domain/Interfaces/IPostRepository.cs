using App.Domain.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Interfaces
{
    public interface IPostRepository
    {
        public bool Create(CreatePostViewModel model);
        public bool Update(int id,int userId, UpdatePostViewModel model);
        public bool Delete(int id,int userId,DeletePostViewModel model);
        public GetPostViewModel Get(int id);
        public List<GetPostViewModel> GetAll();
        public List<GetPostViewModel> GetAll(int userId);
        public string GetSummary(string description);
        bool UpdateViewCount(int id,int count);

    }
}
