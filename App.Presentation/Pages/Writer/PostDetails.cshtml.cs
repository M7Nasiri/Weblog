using App.Application.Interfaces;
using App.Domain.ViewModels.PostAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Presentation.Pages.Writer
{
    public class PostDetailsModel(IPostService postService) : PageModel
    {
        [BindProperty]
        public PostDetailsViewModel model  { get; set; }
        public void OnGet(int id)
        {
            
            var getPost = postService.Get(id);
            model = new PostDetailsViewModel
            {
                CategoryName = getPost.CategoryName,
                CreatedAt = getPost.CreatedAt,
                Description = getPost.Description,
                Id = id,
                ImagePath = getPost.ImagePath,
                Title = getPost.Title,
                ViewCount = getPost.ViewCount,
                WriterUserName = getPost.WriterUserName,
            };
            model.ViewCount++;
            postService.UpdateViewCount(id, model.ViewCount);
        }
    }
}
