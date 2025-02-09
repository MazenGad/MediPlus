using MediPlus.Data;

namespace MediPlus.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId, int page, int pageSize);
		Task<Comment> AddPostCommentAsync(Comment comment, int PostId);
    }
}
