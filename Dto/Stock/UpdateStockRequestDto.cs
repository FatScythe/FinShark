using System.ComponentModel.DataAnnotations;
namespace api.Dto.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Symbol can must have at least 3 character")]
        [MaxLength(10, ErrorMessage = "Symbol can must have at most 10 character")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Company can must have at least 2 character")]
        [MaxLength(50, ErrorMessage = "Company can must have at most 50 character")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(0, 1000000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.0001, 100)]
        public decimal LastDiv { get; set; }
        [Required(ErrorMessage = "Please provide an industry")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(0, 5000000000000)]
        public long MarketCap { get; set; }
    }
}