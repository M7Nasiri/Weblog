using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.CategoryAgg
{
    public class DeleteModel(ICategoryService categoryService) : PageModel
    {
        [BindProperty]
        public Category? Category { get; set; }
        public void OnGet(int id)
        {
            Category = categoryService.Get(id);
        }

        public IActionResult OnPost(int id)
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (categoryService.Delete(id, userId))
                return RedirectToPage("/CategoryAgg/Index");
            else
            {
                ModelState.AddModelError("", "این دسته بندی یا مربوط به شما نیست یا پست مرتبط دارد.");
                return Page();
            }

        }
    }
}
