using App.Application.Interfaces;
using App.Domain.ViewModels.UserAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Admin
{
    [Authorize(Roles="Admin")]
    public class CreateModel(IUserService userService) : PageModel
    {
        [BindProperty]
        public CreateUserByAdmin model { get; set; }
        public int UserId { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(userService.CreateUserByAdmin(UserId, model) != 0)
            {
                return RedirectToPage("/Admin/Index");
            }
            ModelState.AddModelError("", "اشکالی در افزودن کاربر ، بوجود آمده است .");
            return Page();
        }
    }
}
