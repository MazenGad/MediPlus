using MediPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace MediPlus.Repository.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private MediPlusContext _context;

        public CommentRepository(MediPlusContext context)
        {
            _context = context;
        }
        public async Task<Comment> AddPostCommentAsync(Comment comment, int PostId)
        {
            comment.BlogPostId = PostId;
            await _context.Comments.AddAsync(comment);
            _context.SaveChangesAsync();
            return comment;


        }

        public Task DeleteCommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId, int page, int pageSize)
        {
            var comments = await _context.Comments
                .Where(c => c.BlogPostId == postId)
                .OrderBy(c => c.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return comments;
        }

        public Task UpdateCommentAsync(Comment comment, int PostId)
        {
            throw new NotImplementedException();
        }
    }
}
