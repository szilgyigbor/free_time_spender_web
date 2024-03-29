﻿namespace FreeTimeSpenderWeb.Models
{
    public class CommentData
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public int PostId { get; set; }
        public string? Content { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostData? Post { get; set; }
    }
}
