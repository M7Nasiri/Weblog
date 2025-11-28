using App.Domain.ViewModels.PostAgg;

namespace App.Domain.Interfaces
{
    public interface IPostRepository
    {
        public bool Create(CreatePostViewModel model);
        public bool Update(int id, int userId, UpdatePostViewModel model);
        public bool Delete(int id, int userId, DeletePostViewModel model);
        public GetPostViewModel Get(int id);
        public List<GetPostViewModel> GetAll();
        public List<GetPostViewModel> GetAll(int userId);
        public List<GetPostViewModel> GetAll(bool isApproved);

        public string GetSummary(string description);
        bool UpdateViewCount(int id, int count);
        bool Approved(int id, bool isApproved, int userId);


        List<GetPostViewModel> GetBySearchAndSort(int userId, SearchAndSortViewModel sSModel);
        List<int> GetPostIdsByUserId(int userId);


    }
}
