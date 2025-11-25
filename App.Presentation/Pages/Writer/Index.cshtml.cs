using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Entities;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace App.Presentation.Pages.Writer
{
    [Authorize(Roles="Writer")]
    public class IndexModel(IPostService postService,ICategoryService categoryService) : PageModel
    {
        public List<GetPostViewModel> Posts { get; set; }
        public List<Category> Categories { get; set; }
        public int userId { get; set; }
        [BindProperty]
        public SearchAndSortViewModel SSModel { get; set; }
        public void OnGet()
        {
            userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            SSModel = new SearchAndSortViewModel
            {

            };
            Posts = postService.GetAll(userId);
            Categories = categoryService.GetAll(userId);
        }

        public IActionResult OnPostSearchAndSort()
        {
            userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Posts = postService.GetBySearchAndSort(userId,SSModel);
            Categories = categoryService.GetAll(userId);
            return Page();
        }
    }
}
