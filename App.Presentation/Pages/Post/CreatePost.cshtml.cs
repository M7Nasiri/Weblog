using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Entities;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Post
{
    public class CreatePostModel(IPostService postService,ICategoryService categoryService,IFileService fileService) : PageModel
    {
        [BindProperty]
        public CreatePostViewModel model { get; set; }
        public List<Category> Categories { get; set; }
        public IFormFile? ImageFile { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        public void OnGet()
        {
            UserId= Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Categories = categoryService.GetAll(UserId);
            model = new CreatePostViewModel() {
            };
            
        }

        public IActionResult OnPost()
        {
            //Upload Image
            var file = ImageFile;
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            string path = "";
            if (file != null)
            {
                try
                {
                    using var stream = file.OpenReadStream();
                    path = fileService.Upload(stream, file.FileName, "Posts");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"{ex.Message}");
                    Categories = categoryService.GetAll(UserId);
                    return Page();
                }

            }
            model.ImagePath = path;
            model.WriterUserId = UserId;
            
            postService.Create(model);

            return RedirectToPage("/Writer/Profile");
        }
    }
}
