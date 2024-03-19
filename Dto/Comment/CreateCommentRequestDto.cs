using System.ComponentModel.DataAnnotations;

namespace api.Dto.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters")]
        [MaxLength(100, ErrorMessage = "Title cannot be over 100 characters")]
        public required string Title { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 5 characters")]
        [MaxLength(255, ErrorMessage = "Content cannot be over 255 characters")]
        public string Content { get; set; } = string.Empty;
        [Required]
        public int StockId { get; set; }
    }
}