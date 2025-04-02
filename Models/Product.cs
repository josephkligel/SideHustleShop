using System.Diagnostics;

namespace SideHustleShop.Models
{
    public class Product
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;

        public Category Category = Category.Unassigned;

        public string? Description { get; set; } = string.Empty;

        public decimal? Cost { get; set; } = default;

        public decimal? SalePrice { get; set; } = default;

        public string? UpcCode { get; set; } = string.Empty;

        public int? Serial { get; set; } = default;

        public int? ModelNumber { get; set; } = default;

        public Condition Condition = Condition.Used;

        public string LocationName = string.Empty;
    }
}
