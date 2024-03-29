using api.Extensions;
using api.Models;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(
            UserManager<AppUser> userManager,
            IStockRepository stockRepository,
            IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock is null)
                return BadRequest($"No stock matched {symbol}");

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            if (userPortfolio.Any(portfolio => portfolio.Symbol.ToLower() == symbol.ToLower()))
                return BadRequest("Srock already added");

            var portfolioModel = new Portfolio
            {
                AppUserId = appUser.Id,
                StockId = stock.Id
            };

            var portfolio = await _portfolioRepository.CreateAsync(portfolioModel);

            if (portfolio is null)
                return StatusCode(500, "Could Create Portfolio");

            return Created();
        }

        [HttpDelete]
        [Authorize]

        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(portfolio => portfolio.Symbol.ToLower() == symbol.ToLower()).ToList();

            if (filteredStock.Count() != 1)
                return BadRequest("No such Porfolio exist");

            var portfolio = await _portfolioRepository.DeleteAsync(appUser, symbol);

            if (portfolio is null)
                return BadRequest("Stock not in your portfolio");

            return Ok();
        }
    }
}