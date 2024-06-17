
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;
using Wardrobe.Models;

namespace Wardrobe.Repository.UsageLogRepository
{
    public class UsageLogRepository : IUsageLogRepository
    {
        private readonly DataContext _context;

        public UsageLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddUsageLog(int id, UsageLog usageLog)
        {
            var newEntry = await _context.PairOfShoes
                       .Include(x => x.UsageLogs) // Ensure UsageLogs are included
                       .FirstOrDefaultAsync(v => v.Id == id);

            // var updateWearCounter = newEntry.UsageLogs.Select(x => x.WearCounter).LastOrDefault();
            // Snabbare, men det gör inte någon skillad här.
            var updatedEntryReverse = newEntry.UsageLogs.AsEnumerable().Reverse().Select(s => s.WearCounter).FirstOrDefault();
            var updatedEntry = updatedEntryReverse + 1;

            if (newEntry != null)
            {
                newEntry.UsageLogs.Add(
                    new UsageLog 
                    {   
                        WearDate = DateTime.Now,
                        WearCounter = updatedEntry 
                    });

                await _context.SaveChangesAsync();  
            }
            else
            {
                throw new ArgumentException("Ej funnen");
            }
        }
    }
}
