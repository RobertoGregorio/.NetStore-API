namespace Api.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public long CategoryId { get; set; }
    }
}