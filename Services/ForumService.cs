using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreeTimeSpenderWeb.Services
{
    public class ForumService : IForumService
    {
        private readonly FreeTimeSpenderContext _context;

        public ForumService(FreeTimeSpenderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostData>> GetPosts()
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .ToListAsync();
        }

        public async Task<PostData> GetPostById(int postId)
        {
            return await _context.Posts
                .Where(p => p.Id == postId)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync() ?? new PostData();
        }

        public async Task AddPost(PostData post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddComment(CommentData comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostById(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            var comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();

            if (post != null) {
                _context.Posts.Remove(post);
                _context.Comments.RemoveRange(comments);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task DeleteCommentById (int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

    }
}
