using App.Application.Interfaces;
using App.Domain.Enum;
using App.Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;

namespace App.Presentation.Pages.Account
{
    public class RegisterModel(IUserService userService) : PageModel
    {
        [BindProperty]
        public  RegisterUserViewModel model { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (userService.Register(model))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError("model.UserName", "نام کاربری قبلا انتخاب شده است.");
                return Page();
            }
        }
    }
}
