using App.Application.Interfaces;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Presentation.Pages.CategoryAgg
{
    public class EditModel(ICategoryService categoryService) : PageModel
    {
        [BindProperty]
        public Category? Category { get; set; }
        public void OnGet(int id)
        {
            Category = categoryService.Get(id);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            categoryService.Update(id, Category);
            return RedirectToPage("/CategoryAgg/Index");

        }
    }
}
