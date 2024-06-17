using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Models
{
    //[Keyless]
    //[NotMapped]
    public class UsageLog
    {
        public int WearCounter {  get; set; }
        public DateTime WearDate { get; set; }
        public int PairOfShoesId { get; set; }

    }
}
