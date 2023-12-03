namespace Entities.DTOs
{
    public class ProductUpdateDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; } 
    }
}
