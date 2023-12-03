namespace Entities.DTOs
{
    public class MenuAddDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; } = 1;
    }
}
