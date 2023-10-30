namespace FreeTimeSpenderWeb.Models
{
    public class PostData
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public List<CommentData>? Comments { get; set; }
    }
}
