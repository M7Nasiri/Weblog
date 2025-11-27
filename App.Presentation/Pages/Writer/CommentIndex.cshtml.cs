using App.Application.Interfaces;
using App.Domain.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Presentation.Pages.Writer
{
    public class CommentIndexModel(ICommentService commentService) : PageModel
    {
        [BindProperty]
        public List<GetCommentViewModel> Comments { get; set; }
        public void OnGet()
        {
            Comments = commentService.GetAll();
        }
    }
}
