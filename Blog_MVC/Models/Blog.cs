namespace BlogMVC.Models
{
    public class Blog
    {
        public long BlogId { get; set; }
        public string? UserId { get; set; } // user email
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public DateTime StampTime { get; set; }
    }
}
