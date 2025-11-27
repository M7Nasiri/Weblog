using App.Application.Interfaces;
using App.Domain.ViewModels.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Admin
{
    public class DeleteModel(IUserService userService,IMapper mapper) : PageModel
    {
        public int UserId { get; set; }
        [BindProperty]
        public DeleteUserByAdmin model { get; set; }
        public void OnGet(int id)
        {
            var user = userService.GetUserById(id);
            model = mapper.Map<DeleteUserByAdmin>(user);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(userService.DeleteUserByAdmin(UserId, model))
            {
                return RedirectToPage("/Admin/Index");
            }
            return Page();
        }
    }
}
