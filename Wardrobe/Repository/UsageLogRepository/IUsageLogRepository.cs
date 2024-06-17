using Wardrobe.Models;

namespace Wardrobe.Repository.UsageLogRepository
{
    public interface IUsageLogRepository
    {
        Task AddUsageLog(int id, UsageLog usageLog);
    }
}
