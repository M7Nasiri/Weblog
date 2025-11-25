using App.Application.Interfaces;
using App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.CategoryAgg
{
    [Authorize(Roles ="Writer")]
    public class IndexModel(ICategoryService categoryService) : PageModel
    {
        public List<Category> Categories  { get; set; }
        public void OnGet()
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Categories = categoryService.GetAll(userId);

        }
       
    }
}
