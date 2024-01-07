namespace Wardrobe.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<PairOfShoes>? AllPairsOfShoes { get; set; }  
        public List<Trousers>? AllTrousers { get; set;}
    }
}
