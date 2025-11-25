using App.Application.Interfaces;
using App.Domain.Entities;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Writer
{
    [Authorize(Roles ="Writer")]
    public class IndexModel(IPostService postService,ICategoryService catService) : PageModel
    {

        public List<GetPostViewModel> Posts { get; set; }
        public int UserId { get; set; }
        public void OnGet()
        {
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Posts = postService.GetAll(UserId);
        }

      

       
    }
}
