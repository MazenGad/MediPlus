using MediPlus.Data;
using MediPlus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Controllers
{
	public class BlogController : Controller
	{

		private IBlogPostRepository _blogPostRepository;
		private IBlogCategoryRepository _blogCategoryRepository;
		private ICommentRepository _commentRepository;

		public BlogController(
			IBlogPostRepository blogPostRepository ,
			IBlogCategoryRepository blogCategoryRepository ,
			ICommentRepository commentRepository
			)
		{
			_blogPostRepository = blogPostRepository;
			_blogCategoryRepository = blogCategoryRepository;
			_commentRepository = commentRepository;
		}
		public IActionResult Index()
		{
			return View();
		}

        [HttpGet("Blog/BlogPost/{id:int=1}")]
        public async Task<IActionResult> BlogPost(int id)
		{
			var post = await _blogPostRepository.GetPostByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            ViewData["Page"] = "Post Details";
			ViewBag.Categories = await _blogCategoryRepository.GetBlogCategoriesAsync();
			ViewBag.Recent = await _blogPostRepository.GetRecentBlogPostsAsync();

			return View("PostDetails", post);
		}

        [HttpGet]
        public async Task<IActionResult> AddPost()
		{
            ViewBag.Categories = await _blogCategoryRepository.GetBlogCategoriesAsync();

            return View("AddPost");
		}

        [HttpPost]
        public async Task<IActionResult> AddPost(BlogPost blogPost)
		{
			if(ModelState.IsValid)
			{
				await _blogPostRepository.AddBlogPost(blogPost);
				return RedirectToAction("BlogPost");
			}
            ViewBag.Categories = await _blogCategoryRepository.GetBlogCategoriesAsync();

            return View("AddPost", blogPost);
		}

		[HttpPost]

		public async Task<IActionResult> AddComment(Comment comment , int postId )
		{
			if (ModelState.IsValid)
			{
				var newComment = await _commentRepository.AddPostCommentAsync(comment, postId);
                return Json(newComment);

            }
            return BadRequest(ModelState);

        }

        [HttpGet]
		public async Task<IActionResult> GetComments(int postId, int page = 1)
		{
			int pageSize = 5;

			var comments = await _commentRepository.GetPostCommentsAsync(postId, page, pageSize);
			return Json(comments);

        }        
		


	}
}
