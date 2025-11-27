using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.ViewModels.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Admin
{
    public class UpdateModel(IUserService userService,IMapper mapper) : PageModel
    {
        [BindProperty]
        public UpdateUserByAdminViewModel model { get; set; }
        public void OnGet(int id)
        {
            var user = userService.GetUserById(id);
            model = mapper.Map<UpdateUserByAdminViewModel>(user);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(userService.UpdateUserByAdmin(userId,id, model))
            {
                return RedirectToPage("/Admin/Index");
            }
            return Page();
        }
    }
}
