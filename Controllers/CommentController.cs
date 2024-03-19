using api.Dto.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(
            ICommentRepository commentRepository,
            IStockRepository stockRepository,
            UserManager<AppUser> userManager
            )
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("{id:int}")] // adding the int doesn't do anything in this current .NET version
        public async Task<ActionResult<CommentDto>> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment is null)
                return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentDto>> Create(CreateCommentRequestDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
                return BadRequest(ModelState);
            }

            if (commentDto is null)
                return BadRequest("Please provide a comment");

            if (!await _stockRepository.StockExists(commentDto.StockId))
                return BadRequest("Stock does not exist");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var commentModel = commentDto.ToCommentFromCreateDto();
            commentModel.AppUserId = appUser.Id;

            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentDto);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult<CommentDto>> Update(int id, [FromBody] UpdateCommentRequestDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (commentDto is null)
                return BadRequest("Please provide a comment!");

            var comment = await _commentRepository.UpdateAsync(id, commentDto.ToCommentFromUpdateDto());

            if (comment is null)
                return NotFound("Comment not found");

            return Ok(commentDto);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);

            if (comment is null)
                return NotFound("Comment does not exist");

            return NoContent();
        }
    }
}