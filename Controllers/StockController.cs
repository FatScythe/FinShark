using api.Data;
using api.Dto.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StockDto>>> GetStocks([FromQuery] QueryObject query)
        {
            var stocks = await _stockRepository.GetAllAsync(query);

            var stockDto = stocks.Select(stock => stock.ToStockDto());

            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockDto>> GetStockById(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
                return NotFound();

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<StockDto>> CreateStock([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (stockDto is null)
                return BadRequest();

            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateStockById(int id, [FromBody] UpdateStockRequestDto stockUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (stockUpdate == null)
                return BadRequest();

            var stockModel = await _stockRepository.UpdateAsync(id, stockUpdate);

            if (stockModel is null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteStockById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var stock = await _stockRepository.DeleteAsync(id);

            if (stock is null)
                return NotFound();

            return NoContent();
        }

    }
}