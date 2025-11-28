using App.Application.Interfaces;
using App.Domain.ViewModels.CommentAgg;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Presentation.Pages.Writer
{
    public class CommentApprovedModel(ICommentService commentService,IMapper mapper) : PageModel
    {
        [BindProperty]
        public GetCommentViewModel Comment { get; set; }
        public void OnGet(int id)
        {
            Comment = commentService.Get(id);
        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var model = mapper.Map<ApprovedCommentViewModel>(Comment);
            if (commentService.ApprovingComment(model))
            {
                return RedirectToPage("/Writer/CommentIndex");
            }
            return Page();
        }
    }
}
