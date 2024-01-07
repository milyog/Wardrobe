namespace Wardrobe.Models
{
    public class PairOfShoes
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Size { get; set; } 
        public string Description { get; set; } = string.Empty;
        public List<WearCounter>? TimesUsed { get; set; }
    }
}
