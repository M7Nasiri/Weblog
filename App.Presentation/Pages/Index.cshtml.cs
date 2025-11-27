using App.Application.Interfaces;
using App.Domain.Entities;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Presentation.Pages
{
    public class IndexModel(IPostService postService) : PageModel
    {
        [BindProperty]
        public List<GetPostViewModel> Posts { get; set; }

        public void OnGet()
        {
            Posts = postService.GetAll(true);
        }

        
    }
}
