using App.Application.Interfaces;
using App.Domain.Entities;
using App.Domain.ViewModels.Comment;
using App.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Presentation.Pages.Post
{
    public class DetailsModel(IPostService postService, ICommentService commentService) : PageModel
    {
        [BindProperty]
        public PostDetailsViewModel model { get; set; }
        [BindProperty]
        public List<CommentAgg> Comments { get; set; }
        [BindProperty]
        public CreateCommentViewModel addCommentModel { get; set; }
        [BindProperty]
        public List<ShowCommentInPostDetails>postComments { get; set; }
        int? UserId { get; set; }
        int PostId { get; set; }
        public void OnGet(int id)
        {
            //UserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) != null ?
            //    Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) : 0;

            UserId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var uId) ? uId : 0;
            PostId = id;
            addCommentModel = new CreateCommentViewModel
            {
                UserId = UserId,
                PostId = PostId
            };
            var getPost = postService.Get(id);
            model = new PostDetailsViewModel
            {
                CategoryName = getPost.CategoryName,
                CreatedAt = getPost.CreatedAt,
                Description = getPost.Description,
                Id = id,
                ImagePath = getPost.ImagePath,
                Title = getPost.Title,
                ViewCount = getPost.ViewCount,
                WriterUserName = getPost.WriterUserName,
                Comments = Comments
            };
            postComments = commentService.CommentsByPostId(id);
            model.ViewCount++;
            postService.UpdateViewCount(id, model.ViewCount);
        }

        public IActionResult OnPostCreateComment(int PostId,int UserId)
        {
            ModelState.Clear();

            TryValidateModel(addCommentModel, nameof(addCommentModel));

            if (!ModelState.IsValid)
            {
                var getPost = postService.Get(PostId);

                model = new PostDetailsViewModel
                {
                    CategoryName = getPost.CategoryName,
                    CreatedAt = getPost.CreatedAt,
                    Description = getPost.Description,
                    Id = PostId,
                    ImagePath = getPost.ImagePath,
                    Title = getPost.Title,
                    ViewCount = getPost.ViewCount,
                    WriterUserName = getPost.WriterUserName
                };

                // نظرات
                postComments = commentService.CommentsByPostId(PostId);

                // مدل کامنت را هم دوباره مقداردهی کن
                addCommentModel.PostId = PostId;
                addCommentModel.UserId = UserId;
                return Page();
            }
            if (commentService.Add(addCommentModel))
            {
                return RedirectToPage("/Post/Details", new { id = PostId });
            }
            return Page();
        }
    }
}
