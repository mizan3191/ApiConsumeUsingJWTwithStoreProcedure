namespace API.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public string Lenth { get; set; }
        public int ShirtId { get; set; }
        public TShirt Shirt { get; set; }
    }
}
