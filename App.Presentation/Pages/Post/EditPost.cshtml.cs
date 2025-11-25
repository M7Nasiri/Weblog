using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Entities;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Post
{
    public class EditPostModel(IPostService postService,ICategoryService categoryService,IFileService fileService) : PageModel
    {
        [BindProperty]
        public UpdatePostViewModel model { get; set; }
        public int UserId { get; set; }
        public IFormFile? ImageFile { get; set; }
        public List<Category> Categories { get; set; }
        public void OnGet(int id)
        {
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Categories = categoryService.GetAll(UserId);
            var getPost = postService.Get(id);
            model = new UpdatePostViewModel
            {
                Id = id,
                Title = getPost.Title,
                Description = getPost.Description,
                CategoryId = getPost.CategoryId,
                ImagePath = getPost.ImagePath,
            };
        }

        public IActionResult OnPost(int id)
        {
            Categories = categoryService.GetAll(UserId);
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string path = "";
            if (ImageFile != null)
            {
                try
                {
                    using var stream = ImageFile.OpenReadStream();
                    path = fileService.Upload(stream, ImageFile.FileName, "Posts");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"{ex.Message}");
                    Categories = categoryService.GetAll(UserId);
                    return Page();
                }            
                model.ImagePath = path;
            }

            model.WriterUserId = UserId;
            postService.Update(id, UserId, model);
            return RedirectToPage("/Writer/Profile");
        }
    }
}
