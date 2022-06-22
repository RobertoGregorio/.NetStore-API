namespace Api.Json
{
    public class InsertProductDTO
    {
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public string CategoryCode { get; set; }

        public string ImageUrl { get; set; }
        
    }
}