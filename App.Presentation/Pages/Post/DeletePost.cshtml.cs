using App.Application.Interfaces;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Post
{
    public class DeletePostModel(IPostService postService) : PageModel
    {
        [BindProperty]
        public DeletePostViewModel model { get; set; }
        public int UserId { get; set; }
        public void OnGet(int id)
        {
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var deletedPost = postService.Get(id);
            model = new DeletePostViewModel
            {
                Id = id,
                CategoryId = deletedPost.CategoryId,
                CreatedAt = deletedPost.CreatedAt,
                ImagePath = deletedPost.ImagePath,
                Summary = deletedPost.Summary,
                Title = deletedPost.Title,
                ViewCount = deletedPost.ViewCount,
                WriterUserId = UserId,
                WriterUserName = deletedPost.WriterUserName,
                CategoryName = deletedPost.CategoryName,
            };
        }
        public IActionResult OnPost(int id)
        {
            
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!ModelState.IsValid)
            {
                return Page();
            }
            model.WriterUserId = UserId;
            postService.Delete(id, UserId, model);
            return RedirectToPage("/Writer/Index");
        }
    }
}
