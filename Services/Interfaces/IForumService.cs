using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IForumService
    {
        Task<IEnumerable<PostData>> GetPosts();

        Task<IEnumerable<PostData>> GetPostById(int postId);

        Task AddPost(PostData post);

        Task AddComment(CommentData comment);

        Task DeletePostById(int postId);

        Task DeleteCommentById(int commentId);
    }
}
