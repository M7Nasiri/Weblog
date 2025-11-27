using App.Application.Interfaces;
using App.Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Admin
{
    [Authorize(Roles ="Admin")]
    public class IndexModel(IUserService userService) : PageModel
    {
        [BindProperty]
        public List<UserInfoForAdmin> UserInfos { get; set; }
        public int UserId { get; set; }
        public void OnGet()
        {
            UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserInfos = userService.GetUserInfosForAdmin(UserId);
        }
    }
}
