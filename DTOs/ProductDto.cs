using SideHustleShop.Models;

namespace SideHustleShop.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;

        public Category Category { get; set; } = Category.Unassigned;

        public string? Description { get; set; } = default;

        public decimal? SalesPrice { get; set; } = default;

        public int? ModelNumber { get; set; } = default;

        public Condition Condition { get; set; } = Condition.Used;
    }
}
