using App.Application.Interfaces;
using App.Domain.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Writer
{
    public class CommentIndexModel(ICommentService commentService) : PageModel
    {
        [BindProperty]
        public List<GetCommentViewModel> Comments { get; set; }
        public void OnGet()
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Comments = commentService.GetAll(userId);
        }
    }
}
