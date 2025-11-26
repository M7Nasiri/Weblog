using App.Domain.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface IPostService
    {
        public bool Create(CreatePostViewModel model);
        public bool Update(int id,int userId, UpdatePostViewModel model);
        public bool Delete(int id,int userId, DeletePostViewModel model);
        public GetPostViewModel Get(int id);
        public List<GetPostViewModel> GetAll();
        public List<GetPostViewModel> GetAll(int userId);
        public List<GetPostViewModel> GetAll(bool isApproved);

        bool UpdateViewCount(int id,int count);
        bool Approved(int id, bool isApproved,int userId);

        List<GetPostViewModel> GetBySearchAndSort(int userId,SearchAndSortViewModel sSModel);
    }
}
