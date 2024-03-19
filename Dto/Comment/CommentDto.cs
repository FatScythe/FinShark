namespace api.Dto.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}