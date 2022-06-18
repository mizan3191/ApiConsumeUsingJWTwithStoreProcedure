using System.Collections.Generic;

namespace API.Entities
{
    public class TShirt
    {
        public int Id { get; set; }
        public string TShirtName { get; set; }
        public IList<Color> Color { get; set; }
        public IList<Size> Size { get; set; }
    }
}
