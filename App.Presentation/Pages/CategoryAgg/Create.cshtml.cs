using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.CategoryAgg
{
    public class CreateModel(ICategoryService categoryService) : PageModel
    {
        public int UserId { get; set; }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (ModelState.IsValid)
            {
                Category.UserId = UserId;
                categoryService.Create(Category);
                return RedirectToPage("/CategoryAgg/index");
            }
            return Page();
        }
    }
}
