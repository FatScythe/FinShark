using api.Dto.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto()
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                StockId = comment.StockId,
                CreatedBy = comment.AppUser.UserName ?? "",
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt,
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto createDto)
        {
            return new Comment()
            {
                Title = createDto.Title,
                Content = createDto.Content,
                StockId = createDto.StockId,
            };
        }

        public static Comment ToCommentFromUpdateDto(this UpdateCommentRequestDto commentDto)
        {
            return new Comment()
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
            };
        }
    }
}