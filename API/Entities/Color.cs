namespace API.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public int ShirtId { get; set; }
        public TShirt Shirt { get; set; }
    }
}
