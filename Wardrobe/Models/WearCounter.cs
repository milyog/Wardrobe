namespace Wardrobe.Models
{
    public class WearCounter
    {
        public int Counter { get; set; }

        public DateTime WearDate { get; }
         
        public WearCounter(int c) 
        {
            this.Counter = c; 
            WearDate = DateTime.Today;
        }

        public WearCounter() { }
    } 
}
