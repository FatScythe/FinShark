using api.Data;
using api.Dto.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositores
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(c => c.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {

            var comment = await _context.Comments.Include(c => c.AppUser).FirstOrDefaultAsync(c => c.Id == id);

            if (comment is null)
                return null;

            return comment;
        }
        public async Task<Comment?> UpdateAsync(int id, Comment commentUpdate)
        {
            var commentModel = await _context.Comments.FindAsync(id);

            if (commentModel is null)
                return null;

            commentModel.Content = commentUpdate.Content;
            commentModel.Title = commentUpdate.Title;
            commentModel.UpdatedAt = DateTime.Now;

            if (await _context.SaveChangesAsync() < 1)
                return null;

            return commentModel;
        }
        public async Task<Comment?> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);

            if (await _context.SaveChangesAsync() < 1)
                return null;

            return commentModel;
        }
        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);

            if (commentModel is null)
                return null;

            _context.Remove(commentModel);
            if (await _context.SaveChangesAsync() < 1)
                return null;
            return commentModel;
        }
    }
}