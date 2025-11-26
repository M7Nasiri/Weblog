using App.Application.Interfaces;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Verifier
{
    [Authorize(Roles="Verifier")]
    public class PostApprovedModel(IPostService postService) : PageModel
    {
        [BindProperty]
        public PostDetailsViewModel model  { get; set; }
        public int UserId { get; set; }
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
                IsApproved = getPost.IsApproved,
                CategoryId = getPost.CategoryId,
                
            };
        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            postService.Approved(id, model.IsApproved,UserId);
            return RedirectToPage("/Verifier/Index");
        }
    }
}
