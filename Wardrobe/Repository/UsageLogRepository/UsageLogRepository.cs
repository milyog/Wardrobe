
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

        public async Task AddUsageLog(int id)
        {
            var newUsageLogEntry = await _context.PairOfShoes
                       .Include(x => x.UsageLogs) // Ensure UsageLogs are included
                       .FirstOrDefaultAsync(v => v.Id == id);

            if (newUsageLogEntry is not null)
            {            
                int updatedUsageLogEntry = UpdateUsageLogEntry(newUsageLogEntry);

                newUsageLogEntry.UsageLogs.Add(
                    new UsageLog
                    {
                        WearDate = DateTime.Now,
                        WearCounter = updatedUsageLogEntry
                    });

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Ej funnen");
            }
        }

        private static int UpdateUsageLogEntry(PairOfShoes newEntry)
        {
            // var wearCounterTotal = newEntry.UsageLogs.Select(x => x.WearCounter).LastOrDefault();
            // Snabbare, men det gör inte någon skillad här.
            var wearCounterTotal = newEntry.UsageLogs.AsEnumerable().Reverse().Select(s => s.WearCounter).FirstOrDefault();
            var updatedWearCounterTotal = wearCounterTotal + 1;
            return updatedWearCounterTotal;
        }
    }
}
